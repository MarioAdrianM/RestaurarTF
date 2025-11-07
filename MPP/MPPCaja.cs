using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;    // donde tenés GestorCarpeta

namespace MPP
{
    public class MPPCaja
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPCaja()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CargarXml()
        {
            if (!File.Exists(_ruta))
                throw new Exception("No se encontró el archivo BD.Xml");

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Cajas") == null)
            {
                _doc.Root.Add(new XElement("Cajas"));
            }

            if (_doc.Root.Element("MovimientosCaja") == null)
            {
                _doc.Root.Add(new XElement("MovimientosCaja"));
            }
        }

        private long ObtenerUltimoIdCaja()
        {
            var cajas = _doc.Root.Element("Cajas").Elements("Caja");
            return cajas.Any() ? (long)cajas.Max(x => (long)x.Attribute("Id")) : 0;
        }

        private long ObtenerUltimoIdMovimiento()
        {
            var movs = _doc.Root.Element("MovimientosCaja").Elements("MovimientoCaja");
            return movs.Any() ? (long)movs.Max(x => (long)x.Attribute("Id")) : 0;
        }

        public BECaja ObtenerCajaDeFecha(DateTime fecha)
        {
            CargarXml();

            var nodo = _doc.Root.Element("Cajas")
                        .Elements("Caja")
                        .FirstOrDefault(x => ((DateTime)x.Element("Fecha")).Date == fecha.Date);

            if (nodo == null) return null;

            return new BECaja
            {
                Id = (long)nodo.Attribute("Id"),
                Fecha = (DateTime)nodo.Element("Fecha"),
                Apertura = (DateTime)nodo.Element("Apertura"),
                Cierre = string.IsNullOrEmpty((string)nodo.Element("Cierre")) ? (DateTime?)null : (DateTime)nodo.Element("Cierre"),
                Estado = (string)nodo.Element("Estado"),
                MontoInicial = (decimal)nodo.Element("MontoInicial"),
                MontoFinal = (decimal)nodo.Element("MontoFinal")
            };
        }

        public void AbrirCaja(BECaja caja)
        {
            CargarXml();

            long nuevoId = ObtenerUltimoIdCaja() + 1;

            var nodo = new XElement("Caja",
                new XAttribute("Id", nuevoId),
                new XElement("Fecha", caja.Fecha),
                new XElement("Apertura", caja.Apertura),
                new XElement("Cierre", ""),
                new XElement("Estado", caja.Estado),
                new XElement("MontoInicial", caja.MontoInicial),
                new XElement("MontoFinal", caja.MontoFinal)
            );

            _doc.Root.Element("Cajas").Add(nodo);
            _doc.Save(_ruta);
        }

        public void CerrarCaja(long idCaja, decimal montoFinal)
        {
            CargarXml();

            var nodo = _doc.Root.Element("Cajas")
                        .Elements("Caja")
                        .FirstOrDefault(x => (long)x.Attribute("Id") == idCaja);

            if (nodo == null)
                throw new Exception("No se encontró la caja a cerrar.");

            nodo.Element("Cierre").Value = DateTime.Now.ToString("s");
            nodo.Element("Estado").Value = "Cerrada";
            nodo.Element("MontoFinal").Value = montoFinal.ToString(System.Globalization.CultureInfo.InvariantCulture);

            _doc.Save(_ruta);
        }

        public void RegistrarMovimiento(BEMovimientoCaja mov)
        {
            CargarXml();

            long nuevoId = ObtenerUltimoIdMovimiento() + 1;

            var nodo = new XElement("MovimientoCaja",
                new XAttribute("Id", nuevoId),
                new XElement("Id_Caja", mov.Id_Caja),
                new XElement("FechaHora", mov.FechaHora),
                new XElement("Tipo", mov.Tipo),
                new XElement("Concepto", mov.Concepto ?? ""),
                new XElement("Importe", mov.Importe),
                new XElement("Id_Comanda", mov.Id_Comanda.HasValue ? mov.Id_Comanda.Value : 0)
            );

            _doc.Root.Element("MovimientosCaja").Add(nodo);
            _doc.Save(_ruta);
        }

        public List<BEMovimientoCaja> ListarMovimientos(long idCaja)
        {
            CargarXml();

            var lista = _doc.Root.Element("MovimientosCaja")
                .Elements("MovimientoCaja")
                .Where(x => (long)x.Element("Id_Caja") == idCaja)
                .Select(x => new BEMovimientoCaja
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Caja = (long)x.Element("Id_Caja"),
                    FechaHora = (DateTime)x.Element("FechaHora"),
                    Tipo = (string)x.Element("Tipo"),
                    Concepto = (string)x.Element("Concepto"),
                    Importe = (decimal)x.Element("Importe"),
                    Id_Comanda = (long)x.Element("Id_Comanda") == 0 ? (long?)null : (long)x.Element("Id_Comanda")
                })
                .OrderBy(x => x.FechaHora)
                .ToList();

            return lista;
        }
    }
}
