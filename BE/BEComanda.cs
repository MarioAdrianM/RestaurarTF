using System;
using System.Collections.Generic;

namespace BE
{
    public class BEComanda : BEEntidad
    {
        public static class Estados
        {
            public const string Abierta = "Abierta";
            public const string Enviada = "Enviada";
            public const string Lista = "Lista";
            public const string ParaFacturar = "ParaFacturar";
            public const string Facturada = "Facturada";
            public const string Cerrada = "Cerrada";
            public const string Cancelada = "Cancelada";
        }

        public long Id_Mesa { get; set; }
        public DateTime FechaHora { get; set; }
        public string Mozo { get; set; }
        public string Estado { get; set; }
        public List<BEDetalleComanda> Detalles { get; set; }
        public string MotivoCancelacion { get; set; }
        public string UsuarioCancelacion { get; set; }

        public BEComanda()
        {
            Detalles = new List<BEDetalleComanda>();
            Estado = Estados.Abierta;
        }
    }
}
