using System;

namespace BE
{
    public enum EstadoReserva
    {
        Pendiente = 0,
        Cumplida = 1,
        Cancelada = 2
    }

    public class BEReserva : BEEntidad
    {
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; }
        public int CantidadPersonas { get; set; }
        public long? IdMesa { get; set; }
        public EstadoReserva Estado { get; set; }
        public string UsuarioCreador { get; set; }
        public string Observaciones { get; set; }
    }
}
