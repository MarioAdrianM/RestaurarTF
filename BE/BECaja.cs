using System;

namespace BE
{
    public class BECaja
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }        
        public DateTime Apertura { get; set; }
        public DateTime? Cierre { get; set; }
        public string Estado { get; set; }           
        public decimal MontoInicial { get; set; }
        public decimal MontoFinal { get; set; }
    }
}
