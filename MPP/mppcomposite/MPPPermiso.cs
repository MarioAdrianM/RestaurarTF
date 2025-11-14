using Abstraccion;
using BE.BEComposite;
using Backup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MPP
{
    public class MPPPermiso : IGestor<BEPermiso>
    {
        private readonly string ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        private XDocument BDXML;

        public bool CrearXML()
        {
            if (!File.Exists(ruta))
            {
                var doc = new XDocument(
                    new XElement("Root",
                        new XElement("Usuarios"),
                        new XElement("Usuario_Roles"),
                        new XElement("Usuario_Permisos"),
                        new XElement("Roles"),
                        new XElement("Permisos"),
                        new XElement("Rol_Permisos")
                    )
                );
                doc.Save(ruta);
                return true;
            }
            else
            {
                var doc = XDocument.Load(ruta);
                if (doc.Root.Element("Permisos") == null)
                    doc.Root.Add(new XElement("Permisos"));
                doc.Save(ruta);
                return true;
            }
        }

        public bool Guardar(BEPermiso permiso)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            if (permiso.Id == 0)
            {
                if (VerificarExistenciaObjeto(permiso))
                    throw new Exception("Ya existe un permiso con ese nombre.");

                long nuevoId = ObtenerUltimoId() + 1;
                permiso.Id = nuevoId;

                BDXML.Root.Element("Permisos").Add(
                    new XElement("permiso",
                        new XAttribute("Id", permiso.Id.ToString().Trim()),
                        new XElement("Nombre", permiso.Nombre.Trim())
                    )
                );

                BDXML.Save(ruta);
                return true;
            }
            else
            {
                var nodo = BDXML.Root.Element("Permisos")
                    .Descendants("permiso")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == permiso.Id.ToString().Trim());

                if (nodo == null)
                    throw new Exception("No se encontró el permiso a modificar.");

                nodo.Element("Nombre").Value = permiso.Nombre.Trim();
                BDXML.Save(ruta);
                return true;
            }
        }

        public bool Eliminar(BEPermiso permiso)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            var nodo = BDXML.Root.Element("Permisos")
                .Descendants("permiso")
                .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == permiso.Id.ToString().Trim());

            if (nodo == null)
                throw new Exception("No se encontró el permiso.");

            var asocs = BDXML.Root.Element("Rol_Permisos")
                .Descendants("rol_permiso")
                .Where(x => x.Element("Id_Permiso").Value.Trim() == permiso.Id.ToString().Trim())
                .ToList();

            foreach (var a in asocs)
                a.Remove();

            var asocs2 = BDXML.Root.Element("Usuario_Permisos")
                .Descendants("usuario_permiso")
                .Where(x => x.Element("Id_Permiso").Value.Trim() == permiso.Id.ToString().Trim())
                .ToList();

            foreach (var a in asocs2)
                a.Remove();

            nodo.Remove();
            BDXML.Save(ruta);
            return true;
        }

        public BEPermiso ListarObjeto(BEPermiso permiso)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            var nodo = BDXML.Root.Element("Permisos")
                .Descendants("permiso")
                .FirstOrDefault(x => x.Element("Nombre").Value.Trim() == permiso.Nombre.Trim()
                                  || x.Attribute("Id").Value.Trim() == permiso.Id.ToString().Trim());

            if (nodo == null) return null;

            return new BEPermiso(
                long.Parse(nodo.Attribute("Id").Value.Trim()),
                nodo.Element("Nombre").Value.Trim()
            );
        }

        public List<BEPermiso> ListarTodo()
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            var lista = new List<BEPermiso>();
            foreach (var nodo in BDXML.Root.Element("Permisos").Descendants("permiso"))
            {
                lista.Add(new BEPermiso(
                    long.Parse(nodo.Attribute("Id").Value.Trim()),
                    nodo.Element("Nombre").Value.Trim()
                ));
            }
            return lista;
        }

        public long ObtenerUltimoId()
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            var ids = BDXML.Root.Element("Permisos")
                .Descendants("permiso")
                .Select(x => long.Parse(x.Attribute("Id").Value.Trim()));

            return ids.Any() ? ids.Max() : 0;
        }

        public bool VerificarExistenciaObjeto(BEPermiso permiso)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
            BDXML = XDocument.Load(ruta);

            return BDXML.Root.Element("Permisos")
                .Descendants("permiso")
                .Any(x => x.Element("Nombre").Value.Trim().ToLower() == permiso.Nombre.Trim().ToLower());
        }
    }
}
