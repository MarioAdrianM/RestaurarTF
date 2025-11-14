using System;
using System.Collections.Generic;

namespace BE
{
    public class BEFactura
    {
        public long Id { get; set; }          
        public long Numero { get; set; }       
        public DateTime Fecha { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCuit { get; set; }
        public long Id_Comanda { get; set; }
        public decimal Total { get; set; }
        public List<BEDetalleFactura> Detalles { get; set; }
        public string Tipo { get; set; }  


        public BEFactura()
        {
            Detalles = new List<BEDetalleFactura>();
        }
    }
}
