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
    public class MPPRol : IGestor<BERol>
    {
        private readonly string ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        private XDocument BDXML;

        public bool CrearXML()
        {
            try
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
                    if (doc.Root.Element("Roles") == null)
                        doc.Root.Add(new XElement("Roles"));
                    if (doc.Root.Element("Permisos") == null)
                        doc.Root.Add(new XElement("Permisos"));
                    if (doc.Root.Element("Rol_Permisos") == null)
                        doc.Root.Add(new XElement("Rol_Permisos"));
                    doc.Save(ruta);
                    return true;
                }
            }
            catch { throw; }
        }

        public bool Guardar(BERol rol)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                if (rol.Id == 0)
                {
                    // alta
                    if (VerificarExistenciaObjeto(rol))
                        throw new Exception("Ya existe un rol con ese nombre.");

                    long nuevoId = ObtenerUltimoId() + 1;
                    rol.Id = nuevoId;

                    BDXML.Root.Element("Roles").Add(
                        new XElement("rol",
                            new XAttribute("Id", rol.Id.ToString().Trim()),
                            new XElement("Nombre", rol.Nombre.Trim())
                        )
                    );

                    BDXML.Save(ruta);
                    return true;
                }
                else
                {
                    // modificación de nombre
                    var nodo = BDXML.Root.Element("Roles")
                        .Descendants("rol")
                        .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == rol.Id.ToString().Trim());

                    if (nodo == null)
                        throw new Exception("No se encontró el rol a modificar.");

                    // no permitir cambiar el nombre de admin
                    if (nodo.Element("Nombre").Value.Trim().ToLower() == "admin")
                        throw new Exception("No se puede modificar el rol admin.");

                    nodo.Element("Nombre").Value = rol.Nombre.Trim();

                    BDXML.Save(ruta);
                    return true;
                }
            }
            catch { throw; }
        }

        public bool Eliminar(BERol rol)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                var nodo = BDXML.Root.Element("Roles")
                    .Descendants("rol")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == rol.Id.ToString().Trim());

                if (nodo == null)
                    throw new Exception("No se encontró el rol indicado.");

                // no borrar admin
                if (nodo.Element("Nombre").Value.Trim().ToLower() == "admin")
                    throw new Exception("No se puede eliminar el rol admin.");

                // no borrar si está asociado a algún usuario
                bool usadoPorUsuario = BDXML.Root.Element("Usuario_Roles")
                    .Descendants("usuario_rol")
                    .Any(x => x.Element("Id_Rol_Padre").Value.Trim() == rol.Id.ToString().Trim());

                if (usadoPorUsuario)
                    throw new Exception("No se puede eliminar un rol asociado a un usuario.");

                // borrar también sus asociaciones de permisos
                var asociaciones = BDXML.Root.Element("Rol_Permisos")
                    .Descendants("rol_permiso")
                    .Where(x => x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim())
                    .ToList();

                foreach (var a in asociaciones)
                    a.Remove();

                nodo.Remove();
                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        public BERol ListarObjeto(BERol rol)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                var nodo = BDXML.Root.Element("Roles")
                    .Descendants("rol")
                    .FirstOrDefault(x => x.Element("Nombre").Value.Trim() == rol.Nombre.Trim() ||
                                         x.Attribute("Id").Value.Trim() == rol.Id.ToString().Trim());

                if (nodo == null) return null;

                return new BERol(long.Parse(nodo.Attribute("Id").Value.Trim()),
                                 nodo.Element("Nombre").Value.Trim());
            }
            catch { throw; }
        }

        public List<BERol> ListarTodo()
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                var lista = new List<BERol>();

                foreach (var nodo in BDXML.Root.Element("Roles").Descendants("rol"))
                {
                    lista.Add(new BERol(
                        long.Parse(nodo.Attribute("Id").Value.Trim()),
                        nodo.Element("Nombre").Value.Trim()
                    ));
                }

                return lista;
            }
            catch { throw; }
        }

        public long ObtenerUltimoId()
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                var ids = BDXML.Root.Element("Roles")
                    .Descendants("rol")
                    .Select(x => long.Parse(x.Attribute("Id").Value.Trim()));

                return ids.Any() ? ids.Max() : 0;
            }
            catch { throw; }
        }

        public bool VerificarExistenciaObjeto(BERol rol)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML de roles.");
                BDXML = XDocument.Load(ruta);

                return BDXML.Root.Element("Roles")
                    .Descendants("rol")
                    .Any(x => x.Element("Nombre").Value.Trim().ToLower() == rol.Nombre.Trim().ToLower());
            }
            catch { throw; }
        }

        // ========== PERMISOS RELACIONADOS ==========

        public List<BEPermiso> ListarPermisos()
        {
            if (!CrearXML()) return new List<BEPermiso>();
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

        public List<BEPermiso> ListarPermisosDeRol(BERol rol)
        {
            var lista = new List<BEPermiso>();
            if (!CrearXML()) return lista;
            BDXML = XDocument.Load(ruta);

            var permisosDelRol = BDXML.Root.Element("Rol_Permisos")
                .Descendants("rol_permiso")
                .Where(x => x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim());

            foreach (var pr in permisosDelRol)
            {
                string idPermiso = pr.Element("Id_Permiso").Value.Trim();
                var nodoPermiso = BDXML.Root.Element("Permisos")
                    .Descendants("permiso")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == idPermiso);

                if (nodoPermiso != null)
                {
                    lista.Add(new BEPermiso(
                        long.Parse(idPermiso),
                        nodoPermiso.Element("Nombre").Value.Trim()
                    ));
                }
            }

            return lista;
        }

        public bool AsociarRolaPermiso(BERol rol, BEPermiso permiso)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                // no duplicar
                bool existe = BDXML.Root.Element("Rol_Permisos")
                    .Descendants("rol_permiso")
                    .Any(x =>
                        x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim() &&
                        x.Element("Id_Permiso").Value.Trim() == permiso.Id.ToString().Trim()
                    );

                if (existe)
                    throw new Exception("Ese permiso ya está en el rol.");

                BDXML.Root.Element("Rol_Permisos").Add(
                    new XElement("rol_permiso",
                        new XElement("Id_Rol", rol.Id.ToString().Trim()),
                        new XElement("Id_Permiso", permiso.Id.ToString().Trim())
                    )
                );

                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        public bool DesasociarRolaPermiso(BERol rol, BEPermiso permiso)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var nodo = BDXML.Root.Element("Rol_Permisos")
                    .Descendants("rol_permiso")
                    .FirstOrDefault(x =>
                        x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim() &&
                        x.Element("Id_Permiso").Value.Trim() == permiso.Id.ToString().Trim()
                    );

                if (nodo == null)
                    throw new Exception("El permiso no estaba asociado a ese rol.");

                nodo.Remove();
                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }
        public List<BEPermiso> ListarPermisosDelRol(BERol rol)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar XML");
            BDXML = XDocument.Load(ruta);

            List<BEPermiso> lista = new List<BEPermiso>();

            // filas de Rol_Permisos de ese rol
            var filas = BDXML.Root.Element("Rol_Permisos")
                .Descendants("rol_permiso")
                .Where(x => x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim())
                .ToList();

            foreach (var f in filas)
            {
                string idPermiso = f.Element("Id_Permiso").Value.Trim();

                var nodoPermiso = BDXML.Root.Element("Permisos")
                    .Descendants("permiso")
                    .FirstOrDefault(p => p.Attribute("Id").Value.Trim() == idPermiso);

                if (nodoPermiso != null)
                {
                    lista.Add(new BEPermiso(
                        long.Parse(idPermiso),
                        nodoPermiso.Element("Nombre").Value.Trim()
                    ));
                }
            }

            return lista;
        }
    }
}
