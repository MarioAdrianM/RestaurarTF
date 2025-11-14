using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;  

namespace MPP
{
    public class MPPCategoriaProducto
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPCategoriaProducto()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CrearXMLSiNoExiste()
        {
            if (!File.Exists(_ruta))
            {
                _doc = new XDocument(
                    new XElement("Root",
                        new XElement("CategoriasProducto")
                    )
                );
                _doc.Save(_ruta);
            }
            else
            {
                _doc = XDocument.Load(_ruta);
                if (_doc.Root.Element("CategoriasProducto") == null)
                {
                    _doc.Root.Add(new XElement("CategoriasProducto"));
                    _doc.Save(_ruta);
                }
            }
        }

        public bool CrearXML()
        {
            CrearXMLSiNoExiste();
            return true;
        }

        private XDocument Cargar()
        {
            CrearXMLSiNoExiste();
            return _doc;
        }

        public List<BECategoriaProducto> ListarTodo()
        {
            var doc = Cargar();
            var lista = new List<BECategoriaProducto>();

            var nodoCat = doc.Root.Element("CategoriasProducto");
            if (nodoCat == null) return lista;

            foreach (var x in nodoCat.Elements("Categoria"))
            {
                lista.Add(new BECategoriaProducto
                {
                    Id = (long)x.Attribute("Id"),
                    Nombre = (string)x.Element("Nombre"),
                    Descripcion = (string)x.Element("Descripcion"),
                    Activo = (bool?)x.Element("Activo") ?? true
                });
            }

            return lista.OrderBy(c => c.Nombre).ToList();
        }

        public BECategoriaProducto ListarObjeto(long id)
        {
            var doc = Cargar();

            var nodoCat = doc.Root.Element("CategoriasProducto");
            if (nodoCat == null) return null;

            var x = nodoCat.Elements("Categoria")
                .FirstOrDefault(e => (long)e.Attribute("Id") == id);

            if (x == null) return null;

            return new BECategoriaProducto
            {
                Id = (long)x.Attribute("Id"),
                Nombre = (string)x.Element("Nombre"),
                Descripcion = (string)x.Element("Descripcion"),
                Activo = (bool?)x.Element("Activo") ?? true
            };
        }

        private long ObtenerNuevoId(XDocument doc)
        {
            var nodoCat = doc.Root.Element("CategoriasProducto");
            if (nodoCat == null || !nodoCat.Elements("Categoria").Any())
                return 1;

            return nodoCat.Elements("Categoria").Max(e => (long)e.Attribute("Id")) + 1;
        }

        public bool Guardar(BECategoriaProducto c)
        {
            var doc = Cargar();
            var nodoCat = doc.Root.Element("CategoriasProducto");
            if (nodoCat == null)
            {
                nodoCat = new XElement("CategoriasProducto");
                doc.Root.Add(nodoCat);
            }

            if (c.Id == 0)
            {
                c.Id = ObtenerNuevoId(doc);
                var nuevo = new XElement("Categoria",
                    new XAttribute("Id", c.Id),
                    new XElement("Nombre", c.Nombre),
                    new XElement("Descripcion", c.Descripcion ?? ""),
                    new XElement("Activo", c.Activo)
                );
                nodoCat.Add(nuevo);
            }
            else
            {
                var x = nodoCat.Elements("Categoria")
                    .FirstOrDefault(e => (long)e.Attribute("Id") == c.Id);
                if (x == null) throw new Exception("No se encontró la categoría.");

                x.Element("Nombre").Value = c.Nombre;
                x.Element("Descripcion").Value = c.Descripcion ?? "";
                if (x.Element("Activo") != null)
                    x.Element("Activo").Value = c.Activo.ToString();
                else
                    x.Add(new XElement("Activo", c.Activo));
            }

            doc.Save(_ruta);
            return true;
        }

        public bool Eliminar(BECategoriaProducto c)
        {
            var doc = Cargar();
            var nodoCat = doc.Root.Element("CategoriasProducto");
            if (nodoCat == null) return false;

            var x = nodoCat.Elements("Categoria")
                .FirstOrDefault(e => (long)e.Attribute("Id") == c.Id);
            if (x == null) return false;

            x.Remove();
            doc.Save(_ruta);
            return true;
        }
    }
}
