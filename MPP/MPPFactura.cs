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

 
        private long ObtenerUltimoNumeroPorTipo(string tipo)
        {
            CargarXml();

            var facturas = _doc.Root.Element("Facturas").Elements("Factura");

            var filtradas = facturas
                .Where(x => ((string)x.Element("Tipo"))?.ToUpper() == tipo.ToUpper())
                .Where(x => long.TryParse((string)x.Element("Numero"), out _)) 
                .Select(x => long.Parse((string)x.Element("Numero")))
                .ToList();

            if (!filtradas.Any())
                return 0;

            return filtradas.Max();
        }


        public long Registrar(BEFactura fac)
        {
            CargarXml();

            string tipo = string.IsNullOrWhiteSpace(fac.Tipo) ? "TICKET" : fac.Tipo;

            long nuevoId = ObtenerUltimoId() + 1;
            long ultimoNumero = ObtenerUltimoNumeroPorTipo(tipo);
            long nuevoNumero = fac.Numero > 0 ? fac.Numero : ultimoNumero + 1;

            fac.Id = nuevoId;
            fac.Numero = nuevoNumero;

            var nodoFactura = new XElement("Factura",
                new XAttribute("Id", nuevoId),
                new XElement("Tipo", tipo),
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

        public bool GenerarTicketPDF(BEFactura oBEFactura, BEComanda oBEComanda, BECaja oBECaja)
        {
            try
            {
                if (oBEFactura == null) throw new Exception("Error: La Factura no puede ser nula!");
                if (oBEComanda == null) throw new Exception("Error: La Comanda no puede ser nula!");
                if (oBEFactura.Detalles == null || oBEFactura.Detalles.Count == 0) throw new Exception("Error: La factura no tiene ítems.");

                string ts = DateTime.Now.ToString("dd_MM_yyyy_HHmmss");
                string tipoArchivo = string.IsNullOrWhiteSpace(oBEFactura.Tipo) ? "ticket" : oBEFactura.Tipo.ToLower();
                string baseName = $"{tipoArchivo}_{oBEFactura.Numero}_{ts}";
                if (oBECaja == null) baseName += "_COPIA";  
                string nombreArchivoPDF = baseName + ".pdf";

                string rutaPDF = GestorCarpeta.UbicacionPDFs(nombreArchivoPDF);
                if (string.IsNullOrEmpty(rutaPDF)) throw new Exception("La ruta del archivo PDF no puede ser nula o vacía.");
                if (File.Exists(rutaPDF)) File.Delete(rutaPDF);

                using (FileStream fileStream = new FileStream(rutaPDF, FileMode.Create))
                {
                    var ticketSize = new Rectangle(226f, 800f);
                    Document documento = new Document(ticketSize, 5, 5, 5, 5);

                    PdfWriter writer = PdfWriter.GetInstance(documento, fileStream);
                    documento.Open();

                    var fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    var fuenteBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                    // ===== ENCABEZADO =====
                    documento.Add(new Paragraph("RESTAURANTE Rest Aurar", fuenteBold));
                    documento.Add(new Paragraph("CUIT: 30-00000000-0", fuente));
                    documento.Add(new Paragraph("Av. UAI 123 - Ciudad", fuente));
                    documento.Add(new Paragraph("Tel: 4444-4444", fuente));
                    documento.Add(Chunk.NEWLINE);

               
                    if (oBECaja == null)                            
                    {                                               
                        var pCopia = new Paragraph("REIMPRESIÓN / COPIA", fuenteBold); 
                        pCopia.Alignment = Element.ALIGN_CENTER;    
                        documento.Add(pCopia);                      
                        documento.Add(Chunk.NEWLINE);              
                    }                                               

                    documento.Add(new Paragraph($"Fecha: {oBEFactura.Fecha:dd/MM/yyyy HH:mm}", fuente));
                    string ptoVta = oBECaja != null ? oBECaja.Id.ToString("0000") : "0000";
                    documento.Add(new Paragraph($"Pto.Vta: {ptoVta}", fuente));
                    string tipoComp = string.IsNullOrWhiteSpace(oBEFactura.Tipo) ? "TICKET" : oBEFactura.Tipo;
                    documento.Add(new Paragraph($"Comp.: {tipoComp}", fuente));
                    documento.Add(new Paragraph($"Nro: {oBEFactura.Numero:000000}", fuente));
                    if (!string.IsNullOrWhiteSpace(oBEFactura.ClienteNombre))
                        documento.Add(new Paragraph($"Cliente: {oBEFactura.ClienteNombre}", fuente));
                    if (!string.IsNullOrWhiteSpace(oBEFactura.ClienteCuit))
                        documento.Add(new Paragraph($"CUIT: {oBEFactura.ClienteCuit}", fuente));
                    documento.Add(Chunk.NEWLINE);

                    documento.Add(new Paragraph($"Mesa: {oBEComanda.Id_Mesa}", fuente));
                    if (!string.IsNullOrWhiteSpace(oBEComanda.Mozo))
                        documento.Add(new Paragraph($"Mozo: {oBEComanda.Mozo}", fuente));
                    documento.Add(Chunk.NEWLINE);

                    PdfPTable tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 50f, 10f, 20f, 20f });

                    tabla.AddCell(new PdfPCell(new Phrase("Desc.", fuenteBold)) { BorderWidth = 0, BorderWidthBottom = 0.5f });
                    tabla.AddCell(new PdfPCell(new Phrase("Cant", fuenteBold)) { BorderWidth = 0, BorderWidthBottom = 0.5f });
                    tabla.AddCell(new PdfPCell(new Phrase("P.Unit", fuenteBold)) { BorderWidth = 0, BorderWidthBottom = 0.5f });
                    tabla.AddCell(new PdfPCell(new Phrase("Importe", fuenteBold)) { BorderWidth = 0, BorderWidthBottom = 0.5f });

                    decimal total = 0;
                    foreach (var det in oBEFactura.Detalles)
                    {
                        tabla.AddCell(new PdfPCell(new Phrase(det.Descripcion, fuente)) { BorderWidth = 0 });
                        tabla.AddCell(new PdfPCell(new Phrase(det.Cantidad.ToString(), fuente)) { BorderWidth = 0 });
                        tabla.AddCell(new PdfPCell(new Phrase(det.PrecioUnitario.ToString("N2"), fuente)) { BorderWidth = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tabla.AddCell(new PdfPCell(new Phrase(det.Subtotal.ToString("N2"), fuente)) { BorderWidth = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        total += det.Subtotal;
                    }

                    documento.Add(tabla);
                    documento.Add(Chunk.NEWLINE);

                    bool hayCliente = !string.IsNullOrWhiteSpace(oBEFactura.ClienteNombre) || !string.IsNullOrWhiteSpace(oBEFactura.ClienteCuit);
                    if (hayCliente)
                    {
                        decimal neto = Math.Round(total / 1.21m, 2);
                        decimal iva = Math.Round(total - neto, 2);
                        documento.Add(new Paragraph($"Neto gravado: {neto:N2}", fuente));
                        documento.Add(new Paragraph($"IVA 21%:     {iva:N2}", fuente));
                        documento.Add(new Paragraph($"TOTAL:       {total:N2}", fuenteBold));
                        documento.Add(new Paragraph("Cond. IVA: Responsable Inscripto", fuente));
                    }
                    else
                    {
                        documento.Add(new Paragraph($"TOTAL: {total:N2}", fuenteBold));
                        documento.Add(new Paragraph("Cond. IVA: Consumidor Final", fuente));
                        documento.Add(new Paragraph("Precios finales. IVA incluido.", fuente));
                    }

                    documento.Add(Chunk.NEWLINE);
                    documento.Add(new Paragraph("Gracias por su visita", fuente));

                    documento.Close();

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = rutaPDF,
                        UseShellExecute = true
                    });

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                Tipo = (string)xFac.Element("Tipo") ?? "TICKET",
                Numero = (long)xFac.Element("Numero"),
                Fecha = (DateTime)xFac.Element("Fecha"),
                ClienteNombre = (string)xFac.Element("ClienteNombre"),
                ClienteCuit = (string)xFac.Element("ClienteCuit"),
                Id_Comanda = (long)xFac.Element("Id_Comanda"),
                Total = (decimal)xFac.Element("Total"),
                Detalles = new List<BEDetalleFactura>()
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

        public List<BEFactura> ListarPorFecha(DateTime fecha)
        {
            CargarXml();

            var facturas = _doc.Root.Element("Facturas")
                .Elements("Factura")
                .Where(x => ((DateTime)x.Element("Fecha")).Date == fecha.Date)
                .Select(x => new BEFactura
                {
                    Id = (long)x.Attribute("Id"),
                    Tipo = (string)x.Element("Tipo") ?? "TICKET",
                    Numero = (long)x.Element("Numero"),
                    Fecha = (DateTime)x.Element("Fecha"),
                    ClienteNombre = (string)x.Element("ClienteNombre"),
                    ClienteCuit = (string)x.Element("ClienteCuit"),
                    Id_Comanda = (long)x.Element("Id_Comanda"),
                    Total = (decimal)x.Element("Total"),
                    Detalles = x.Element("Detalles") == null
                        ? new List<BEDetalleFactura>()
                        : x.Element("Detalles").Elements("Detalle")
                            .Select(d => new BEDetalleFactura
                            {
                                Descripcion = (string)d.Element("Descripcion"),
                                Cantidad = (int)d.Element("Cantidad"),
                                PrecioUnitario = (decimal)d.Element("PrecioUnitario"),
                                Subtotal = (decimal)d.Element("Subtotal")
                            }).ToList()
                })
                .ToList();

            return facturas;
        }
    }
}
