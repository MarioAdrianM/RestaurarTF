using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;

namespace MPP
{
    public class MPPComanda
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPComanda()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CargarXml()
        {
            if (!File.Exists(_ruta))
                throw new Exception("No se encontró BD.Xml");

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Comandas") == null)
            {
                _doc.Root.Add(new XElement("Comandas"));
                _doc.Save(_ruta);
            }
        }

        private long ObtenerUltimoId()
        {
            CargarXml();
            var nodos = _doc.Root.Element("Comandas").Elements("Comanda");
            return nodos.Any() ? nodos.Max(x => (long)x.Attribute("Id")) : 0;
        }

        public long Registrar(BEComanda comanda)
        {
            CargarXml();
            long nuevoId = ObtenerUltimoId() + 1;

            var nodo = new XElement("Comanda",
                new XAttribute("Id", nuevoId),
                new XElement("Id_Mesa", comanda.Id_Mesa),
                new XElement("Fecha", comanda.FechaHora),
                new XElement("Mozo", comanda.Mozo ?? ""),
                new XElement("Estado", comanda.Estado ?? "Abierta"),
                new XElement("Detalles")
            );

            _doc.Root.Element("Comandas").Add(nodo);
            _doc.Save(_ruta);

            return nuevoId;
        }

        public void AgregarDetalle(long idComanda, BEDetalleComanda det)
        {
            CargarXml();

            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (nodoComanda == null)
                throw new Exception("No se encontró la comanda.");

            var nodoDetalles = nodoComanda.Element("Detalles");
            if (nodoDetalles == null)
            {
                nodoDetalles = new XElement("Detalles");
                nodoComanda.Add(nodoDetalles);
            }

            var nodoDet = new XElement("Detalle",
                new XElement("Id_Producto", det.Id_Producto),
                new XElement("Descripcion", det.Descripcion ?? ""),
                new XElement("Cantidad", det.Cantidad),
                new XElement("PrecioUnitario", det.PrecioUnitario)
            );

            nodoDetalles.Add(nodoDet);
            _doc.Save(_ruta);
        }

        public void CambiarEstado(long idComanda, string nuevoEstado)
        {
            CargarXml();

            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (nodoComanda == null)
                throw new Exception("No se encontró la comanda.");

            nodoComanda.Element("Estado").Value = nuevoEstado;
            _doc.Save(_ruta);
        }

        public List<BEComanda> ListarPendientesDeCocina()
        {
            CargarXml();

            var lista = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .Where(x => ((string)x.Element("Estado")) == "Enviada")
                .Select(x => new BEComanda
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Mesa = (long)x.Element("Id_Mesa"),
                    FechaHora = (DateTime)x.Element("Fecha"),
                    Mozo = (string)x.Element("Mozo"),
                    Estado = (string)x.Element("Estado"),
                    Detalles = x.Element("Detalles") == null
                        ? new List<BEDetalleComanda>()
                        : x.Element("Detalles").Elements("Detalle")
                            .Select(d => new BEDetalleComanda
                            {
                                Id_Producto = (long)d.Element("Id_Producto"),
                                Descripcion = (string)d.Element("Descripcion"),
                                Cantidad = (int)d.Element("Cantidad"),
                                PrecioUnitario = (decimal)d.Element("PrecioUnitario")
                            }).ToList()
                })
                .OrderBy(x => x.FechaHora)
                .ToList();

            return lista;
        }

        // 👇 NUEVO: para facturar
        public BEComanda ObtenerPorId(long idComanda)
        {
            CargarXml();

            var xCom = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (xCom == null) return null;

            var com = new BEComanda
            {
                Id = (long)xCom.Attribute("Id"),
                Id_Mesa = (long)xCom.Element("Id_Mesa"),
                FechaHora = (DateTime)xCom.Element("Fecha"),
                Mozo = (string)xCom.Element("Mozo"),
                Estado = (string)xCom.Element("Estado"),
                Detalles = new List<BEDetalleComanda>()
            };

            var xDet = xCom.Element("Detalles");
            if (xDet != null)
            {
                com.Detalles = xDet.Elements("Detalle")
                    .Select(d => new BEDetalleComanda
                    {
                        Id_Producto = (long)d.Element("Id_Producto"),
                        Descripcion = (string)d.Element("Descripcion"),
                        Cantidad = (int)d.Element("Cantidad"),
                        PrecioUnitario = (decimal)d.Element("PrecioUnitario")
                    }).ToList();
            }

            return com;
        }

        // 👇 ya lo teníamos en la versión anterior del listado, lo dejo por si lo usás en el FormComandas
        public List<BEComanda> Listar(DateTime? fechaFiltro = null, string estado = null)
        {
            CargarXml();

            var query = _doc.Root.Element("Comandas").Elements("Comanda");

            if (fechaFiltro.HasValue)
            {
                var f = fechaFiltro.Value.Date;
                query = query.Where(x => ((DateTime)x.Element("Fecha")).Date == f);
            }

            if (!string.IsNullOrEmpty(estado) && estado != "Todos")
            {
                query = query.Where(x => (string)x.Element("Estado") == estado);
            }

            var lista = query
                .Select(x => new BEComanda
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Mesa = (long)x.Element("Id_Mesa"),
                    FechaHora = (DateTime)x.Element("Fecha"),
                    Mozo = (string)x.Element("Mozo"),
                    Estado = (string)x.Element("Estado"),
                    Detalles = x.Element("Detalles") == null
                        ? new List<BEDetalleComanda>()
                        : x.Element("Detalles").Elements("Detalle")
                            .Select(d => new BEDetalleComanda
                            {
                                Id_Producto = (long)d.Element("Id_Producto"),
                                Descripcion = (string)d.Element("Descripcion"),
                                Cantidad = (int)d.Element("Cantidad"),
                                PrecioUnitario = (decimal)d.Element("PrecioUnitario")
                            }).ToList()
                })
                .OrderByDescending(c => c.FechaHora)
                .ToList();

            return lista;
        }
    }
}
