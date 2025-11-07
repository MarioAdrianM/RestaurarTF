using System;

namespace BE
{
    public class BECobroMozo
    {
        public long Id { get; set; }
        public long Id_Comanda { get; set; }
        public System.DateTime FechaHora { get; set; }
        public string Mozo { get; set; }
        public string Medio { get; set; }   // efectivo / tarjeta / qr
        public decimal Importe { get; set; }
        public bool Rendido { get; set; }
    }
}

