using Abstraccion;
using Backup;
using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MPP
{
    public class MPPProductoCarta : IGestor<BEProductoCarta>
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPProductoCarta()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CrearXMLSiNoExiste()
        {
            if (!File.Exists(_ruta))
            {
                _doc = new XDocument(
                    new XElement("Root",
                        new XElement("ProductosCarta")
                    )
                );
                _doc.Save(_ruta);
            }
            else
            {
                _doc = XDocument.Load(_ruta);
                if (_doc.Root.Element("ProductosCarta") == null)
                {
                    _doc.Root.Add(new XElement("ProductosCarta"));
                    _doc.Save(_ruta);
                }
            }
        }

        public bool CrearXML()
        {
            CrearXMLSiNoExiste();
            return true;
        }

        public bool Guardar(BEProductoCarta o)
        {
            CrearXMLSiNoExiste();

            long catId = o.Categoria != null ? o.Categoria.Id : 0;
            string catNombre = o.Categoria != null ? o.Categoria.Nombre : "";

            if (o.Id == 0)
            {
                o.Id = ObtenerUltimoId() + 1;

                var xProd = new XElement("ProductoCarta",
                    new XAttribute("Id", o.Id),
                    new XElement("Nombre", o.Nombre ?? ""),
                    new XElement("CategoriaId", catId),
                    new XElement("Descripcion", o.Descripcion ?? "")
                );

                xProd.Add(new XElement("Precio", o.Precio.ToString(CultureInfo.InvariantCulture)));
                xProd.Add(new XElement("Activo", o.Activo));

                _doc.Root.Element("ProductosCarta").Add(xProd);
            }
            else
            {
                var xProd = _doc.Root.Element("ProductosCarta").Elements("ProductoCarta")
                    .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

                if (xProd == null)
                    throw new Exception("No se encontró el producto para modificar.");

                xProd.Element("Nombre").Value = o.Nombre ?? "";

                if (xProd.Element("CategoriaId") != null)
                    xProd.Element("CategoriaId").Value = catId.ToString();
                else
                    xProd.Add(new XElement("CategoriaId", catId));

                if (xProd.Element("CategoriaNombre") != null)
                    xProd.Element("CategoriaNombre").Value = catNombre;
                else
                    xProd.Add(new XElement("CategoriaNombre", catNombre));

                xProd.Element("Descripcion").Value = o.Descripcion ?? "";

                xProd.Element("Precio").Value = o.Precio.ToString(CultureInfo.InvariantCulture);
                xProd.Element("Activo").Value = o.Activo.ToString();
            }

            _doc.Save(_ruta);
            return true;
        }

        public bool Eliminar(BEProductoCarta o)
        {
            CrearXMLSiNoExiste();
            var xProd = _doc.Root.Element("ProductosCarta").Elements("ProductoCarta")
                .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

            if (xProd != null)
            {
                xProd.Remove();
                _doc.Save(_ruta);
            }
            return true;
        }

        public List<BEProductoCarta> ListarTodo()
        {
            CrearXMLSiNoExiste();

            return _doc.Root.Element("ProductosCarta").Elements("ProductoCarta")
                .Select(x =>
                {
                    var precioStr = (string)x.Element("Precio") ?? "0";
                    decimal precio;
                    if (!decimal.TryParse(precioStr, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
                        decimal.TryParse(precioStr, NumberStyles.Any, new CultureInfo("es-AR"), out precio);

                    long catId = 0;
                    long.TryParse((string)x.Element("CategoriaId") ?? "0", out catId);
                    string catNombre = (string)x.Element("CategoriaNombre") ?? "";

                    if (string.IsNullOrEmpty(catNombre) && x.Element("Categoria") != null)
                    {
                        catNombre = (string)x.Element("Categoria");
                    }

                    BECategoriaProducto cat = null;
                    if (catId > 0 || !string.IsNullOrEmpty(catNombre))
                    {
                        cat = new BECategoriaProducto
                        {
                            Id = catId,
                            Nombre = catNombre,
                            Activo = true
                        };
                    }

                    return new BEProductoCarta
                    {
                        Id = (long)x.Attribute("Id"),
                        Nombre = (string)x.Element("Nombre"),
                        Categoria = cat,
                        Descripcion = (string)x.Element("Descripcion"),
                        Precio = precio,
                        Activo = (bool)x.Element("Activo")
                    };
                })
                .ToList();
        }

        public BEProductoCarta ListarObjeto(BEProductoCarta o)
        {
            return ListarTodo().FirstOrDefault(p => p.Id == o.Id);
        }

        public bool VerificarExistenciaObjeto(BEProductoCarta o)
        {
            CrearXMLSiNoExiste();
            string catNombre = o.Categoria != null ? o.Categoria.Nombre : "";

            return _doc.Root.Element("ProductosCarta").Elements("ProductoCarta")
                .Any(x =>
                    string.Equals((string)x.Element("Nombre"), o.Nombre ?? "", StringComparison.OrdinalIgnoreCase) &&
                    string.Equals((string)x.Element("CategoriaNombre"), catNombre ?? "", StringComparison.OrdinalIgnoreCase)
                );
        }

        public long ObtenerUltimoId()
        {
            CrearXMLSiNoExiste();
            var nodos = _doc.Root.Element("ProductosCarta").Elements("ProductoCarta");
            return nodos.Any() ? nodos.Max(x => (long)x.Attribute("Id")) : 0;
        }
    }
}
