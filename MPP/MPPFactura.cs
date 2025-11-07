using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;   // GestorCarpeta

namespace MPP
{
    public class MPPFactura
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPFactura()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CargarXml()
        {
            if (!File.Exists(_ruta))
                throw new Exception("No se encontró BD.Xml");

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Facturas") == null)
            {
                _doc.Root.Add(new XElement("Facturas"));
                _doc.Save(_ruta);
            }
        }

        private long ObtenerUltimoId()
        {
            CargarXml();
            var facturas = _doc.Root.Element("Facturas").Elements("Factura");
            return facturas.Any() ? (long)facturas.Max(x => (long)x.Attribute("Id")) : 0;
        }

        private long ObtenerUltimoNumero()
        {
            CargarXml();
            var facturas = _doc.Root.Element("Facturas").Elements("Factura");
            return facturas.Any() ? (long)facturas.Max(x => (long)x.Element("Numero")) : 0;
        }

        public long Registrar(BEFactura fac)
        {
            CargarXml();

            long nuevoId = ObtenerUltimoId() + 1;
            long nuevoNumero = fac.Numero > 0 ? fac.Numero : ObtenerUltimoNumero() + 1;

            var nodoFactura = new XElement("Factura",
                new XAttribute("Id", nuevoId),
                new XElement("Numero", nuevoNumero),
                new XElement("Fecha", fac.Fecha),
                new XElement("ClienteNombre", fac.ClienteNombre ?? ""),
                new XElement("ClienteCuit", fac.ClienteCuit ?? ""),
                new XElement("Id_Comanda", fac.Id_Comanda),
                new XElement("Total", fac.Total),
                new XElement("Detalles")
            );

            foreach (var det in fac.Detalles)
            {
                nodoFactura.Element("Detalles").Add(
                    new XElement("Detalle",
                        new XElement("Descripcion", det.Descripcion ?? ""),
                        new XElement("Cantidad", det.Cantidad),
                        new XElement("PrecioUnitario", det.PrecioUnitario),
                        new XElement("Subtotal", det.Subtotal)
                    )
                );
            }

            _doc.Root.Element("Facturas").Add(nodoFactura);
            _doc.Save(_ruta);

            return nuevoNumero;
        }
        public BEFactura ObtenerUltimaPorComanda(long idComanda)
        {
            CargarXml();

            var facturas = _doc.Root.Element("Facturas")
                .Elements("Factura")
                .Where(x => (long)x.Element("Id_Comanda") == idComanda)
                .OrderByDescending(x => (long)x.Element("Numero"))
                .ToList();

            if (!facturas.Any())
                return null;

            var xFac = facturas.First();

            var fac = new BEFactura
            {
                Id = (long)xFac.Attribute("Id"),
                Numero = (long)xFac.Element("Numero"),
                Fecha = (DateTime)xFac.Element("Fecha"),
                ClienteNombre = (string)xFac.Element("ClienteNombre"),
                ClienteCuit = (string)xFac.Element("ClienteCuit"),
                Id_Comanda = (long)xFac.Element("Id_Comanda"),
                Total = (decimal)xFac.Element("Total"),
                Detalles = new System.Collections.Generic.List<BEDetalleFactura>()
            };

            var xDets = xFac.Element("Detalles");
            if (xDets != null)
            {
                foreach (var xd in xDets.Elements("Detalle"))
                {
                    fac.Detalles.Add(new BEDetalleFactura
                    {
                        Descripcion = (string)xd.Element("Descripcion"),
                        Cantidad = (int)xd.Element("Cantidad"),
                        PrecioUnitario = (decimal)xd.Element("PrecioUnitario"),
                        Subtotal = (decimal)xd.Element("Subtotal")
                    });
                }
            }

            return fac;
        }

    }
}
