using System;

namespace BE
{
    public class BECaja
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }          // día de la caja
        public DateTime Apertura { get; set; }
        public DateTime? Cierre { get; set; }
        public string Estado { get; set; }           // "Abierta" / "Cerrada"
        public decimal MontoInicial { get; set; }
        public decimal MontoFinal { get; set; }
    }
}
