using Backup;  
using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
                        .Where(x => ((DateTime)x.Element("Fecha")).Date == fecha.Date)
                        .OrderByDescending(x => (long)x.Attribute("Id"))  
                        .FirstOrDefault();

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
        public void GenerarInformeCierrePDF(
       BECaja caja,
       List<BEMovimientoCaja> movimientos)
        {
            if (caja == null)
                throw new Exception("No se puede generar el cierre: caja nula.");

            string nombreArchivoPDF = $"Cierre_{caja.Fecha:yyyyMMdd}.pdf";
            string rutaPDF = GestorCarpeta.UbicacionPDFs(nombreArchivoPDF);

            if (File.Exists(rutaPDF))
                File.Delete(rutaPDF);

            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fontTitulo = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);
                var fontSub = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
                var fontText = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL);

            
                doc.Add(new Paragraph("CIERRE DE CAJA", fontTitulo));
                doc.Add(new Paragraph($"Fecha: {caja.Fecha:dd/MM/yyyy}", fontText));
                doc.Add(new Paragraph($"Apertura: {caja.Apertura:HH:mm} - Cierre: {caja.Cierre:HH:mm}", fontText));
                doc.Add(Chunk.NEWLINE);

                decimal totalEfectivo = movimientos
                    .Where(m => m.Tipo == "Ingreso" && m.Concepto.StartsWith("Rendición mozo"))
                    .Sum(m => m.Importe);

                decimal totalTarjeta = movimientos
                    .Where(m => m.Tipo == "Ingreso" && m.Concepto.Contains("Tarjeta"))
                    .Sum(m => m.Importe);

                decimal totalQR = movimientos
                    .Where(m => m.Tipo == "Ingreso" && m.Concepto.Contains("QR"))
                    .Sum(m => m.Importe);

                decimal totalGastos = movimientos
                    .Where(m => m.Tipo == "Egreso")
                    .Sum(m => m.Importe);

                doc.Add(new Paragraph($"Monto inicial: {caja.MontoInicial:N2}", fontText));
                doc.Add(new Paragraph($"Total efectivo rendido: {totalEfectivo:N2}", fontText));
                doc.Add(new Paragraph($"Total tarjeta rendido: {totalTarjeta:N2}", fontText));
                doc.Add(new Paragraph($"Total QR rendido: {totalQR:N2}", fontText));
                doc.Add(new Paragraph($"Total gastos: {totalGastos:N2}", fontText));
                doc.Add(new Paragraph($"Monto final: {caja.MontoFinal:N2}", fontSub));
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("Ventas por mozo:", fontSub));
                var porMozo = movimientos
                    .Where(m => m.Tipo == "Ingreso" && m.Concepto.StartsWith("Rendición mozo"))
                    .GroupBy(m =>
                    {
                        string cpto = m.Concepto;
                        if (cpto.Length >= 15)
                        {
                            string resto = cpto.Substring(15).Trim(); 
                            int idx = resto.IndexOf("(");
                            return idx > 0 ? resto.Substring(0, idx).Trim() : resto;
                        }
                        return "SIN MOZO";
                    })
                    .Select(g => new { Mozo = g.Key, Total = g.Sum(x => x.Importe) })
                    .OrderBy(x => x.Mozo);

                if (porMozo.Any())
                {
                    foreach (var item in porMozo)
                        doc.Add(new Paragraph($"- {item.Mozo}: {item.Total:N2}", fontText));
                }
                else
                {
                    doc.Add(new Paragraph("No hay rendiciones en esta caja.", fontText));
                }

                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("Movimientos de caja:", fontSub));
                PdfPTable tabla = new PdfPTable(4) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 25, 15, 40, 20 });

                tabla.AddCell(new PdfPCell(new Phrase("Fecha/Hora", fontSub)));
                tabla.AddCell(new PdfPCell(new Phrase("Tipo", fontSub)));
                tabla.AddCell(new PdfPCell(new Phrase("Concepto", fontSub)));
                tabla.AddCell(new PdfPCell(new Phrase("Importe", fontSub)));

                foreach (var m in movimientos.OrderBy(m => m.FechaHora))
                {
                    tabla.AddCell(new PdfPCell(new Phrase(m.FechaHora.ToString("dd/MM HH:mm"), fontText)));
                    tabla.AddCell(new PdfPCell(new Phrase(m.Tipo, fontText)));
                    tabla.AddCell(new PdfPCell(new Phrase(m.Concepto, fontText)));
                    tabla.AddCell(new PdfPCell(new Phrase(m.Importe.ToString("N2"), fontText)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                doc.Add(tabla);

                doc.Close();

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
        }

    }
}
