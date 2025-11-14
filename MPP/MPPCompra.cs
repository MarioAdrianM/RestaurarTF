using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Abstraccion;
using BE;
using Backup;

namespace MPP
{
    public class MPPCompra : IGestor<BECompra>
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPCompra()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CargarXml()
        {
            if (!File.Exists(_ruta))
                throw new FileNotFoundException("No se encontró el archivo de base de datos: " + _ruta);

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Compras") == null)
            {
                _doc.Root.Add(new XElement("Compras"));
                _doc.Save(_ruta);
            }
        }

        public bool CrearXML()
        {
            CargarXml();
            return true;
        }

        private long ObtenerUltimoIdInterno()
        {
            var compras = _doc.Root.Element("Compras").Elements("Compra");
            return compras.Any() ? compras.Max(x => (long)x.Attribute("Id")) : 0;
        }

        public long ObtenerUltimoId()
        {
            CargarXml();
            return ObtenerUltimoIdInterno();
        }

        public bool Guardar(BECompra o)
        {
            CargarXml();
            var contenedor = _doc.Root.Element("Compras");

            if (o.Id == 0)
            {
                o.Id = ObtenerUltimoIdInterno() + 1;
                contenedor.Add(ToXElement(o));
            }
            else
            {
                var nodo = contenedor.Elements("Compra")
                    .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);
                if (nodo == null)
                    throw new Exception("No se encontró la compra a actualizar.");

                nodo.ReplaceWith(ToXElement(o));
            }

            _doc.Save(_ruta);
            return true;
        }

        private XElement ToXElement(BECompra c)
        {
            long catId = c.Categoria != null ? c.Categoria.Id : 0;
            string catNombre = c.Categoria != null ? c.Categoria.Nombre : string.Empty;

            return new XElement("Compra",
                new XAttribute("Id", c.Id),
                new XElement("Fecha", c.Fecha),
                new XElement("Proveedor", c.Proveedor ?? string.Empty),
                new XElement("NumeroComprobante", c.NumeroComprobante ?? string.Empty),
                new XElement("CategoriaId", catId),
                new XElement("CategoriaNombre", catNombre),
                new XElement("ImporteTotal", c.ImporteTotal),
                new XElement("Observaciones", c.Observaciones ?? string.Empty)
            );
        }


        public bool Eliminar(BECompra o)
        {
            CargarXml();
            var contenedor = _doc.Root.Element("Compras");
            var nodo = contenedor.Elements("Compra")
                .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);
            if (nodo != null)
            {
                nodo.Remove();
                _doc.Save(_ruta);
                return true;
            }
            return false;
        }

        public bool VerificarExistenciaObjeto(BECompra o)
        {
            CargarXml();
            var contenedor = _doc.Root.Element("Compras");

            return contenedor.Elements("Compra")
                .Any(x =>
                    ((string)x.Element("Proveedor")).Equals(o.Proveedor, StringComparison.OrdinalIgnoreCase) &&
                    ((string)x.Element("NumeroComprobante")).Equals(o.NumeroComprobante, StringComparison.OrdinalIgnoreCase) &&
                    ((DateTime)x.Element("Fecha")).Date == o.Fecha.Date &&
                    (long)x.Attribute("Id") != o.Id
                );
        }

        public List<BECompra> ListarTodo()
        {
            CargarXml();
            var contenedor = _doc.Root.Element("Compras");

            return contenedor.Elements("Compra")
                .Select(x =>
                {
                    long catId = 0;
                    long.TryParse((string)x.Element("CategoriaId") ?? "0", out catId);
                    string catNombre = (string)x.Element("CategoriaNombre") ?? string.Empty;

                    if (string.IsNullOrEmpty(catNombre) && x.Element("Familia") != null)
                    {
                        catNombre = (string)x.Element("Familia");
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

                    return new BECompra
                    {
                        Id = (long)x.Attribute("Id"),
                        Fecha = (DateTime)x.Element("Fecha"),
                        Proveedor = (string)x.Element("Proveedor"),
                        NumeroComprobante = (string)x.Element("NumeroComprobante"),
                        Categoria = cat,
                        ImporteTotal = (decimal)x.Element("ImporteTotal"),
                        Observaciones = (string)x.Element("Observaciones")
                    };
                })
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }


        public BECompra ListarObjeto(BECompra o)
        {
            CargarXml();
            return ListarTodo().FirstOrDefault(c => c.Id == o.Id);
        }
    }
}
