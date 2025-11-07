using System;
using System.Collections.Generic;

namespace BE
{
    public class BEFactura
    {
        public long Id { get; set; }              // Id interno del XML
        public long Numero { get; set; }          // Nro de factura
        public DateTime Fecha { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCuit { get; set; }
        public long Id_Comanda { get; set; }
        public decimal Total { get; set; }
        public List<BEDetalleFactura> Detalles { get; set; }

        public BEFactura()
        {
            Detalles = new List<BEDetalleFactura>();
        }
    }
}
