using System;

namespace BE
{
    public enum EstadoMesa
    {
        Libre = 0,
        Reservada = 1,
        Ocupada = 2,
        Bloqueada = 3
    }

    public class BEMesa : BEEntidad
    {
        public string Codigo { get; set; }      // ej: M01
        public int Numero { get; set; }         // ej: 1
        public string Sector { get; set; }      // ej: Salon, Terraza
        public int Capacidad { get; set; }      // 2, 4, 6
        public EstadoMesa Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
