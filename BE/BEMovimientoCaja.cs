using System;

namespace BE
{
    public class BEMovimientoCaja
    {
        public long Id { get; set; }
        public long Id_Caja { get; set; }
        public DateTime FechaHora { get; set; }
        public string Tipo { get; set; }          // "Ingreso" / "Egreso"
        public string Concepto { get; set; }
        public decimal Importe { get; set; }

        // opcional, porque vos lo usabas
        public long? Id_Comanda { get; set; }
    }
}
