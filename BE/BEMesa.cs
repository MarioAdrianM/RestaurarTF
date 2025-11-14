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
        public string Codigo { get; set; }      
        public int Numero { get; set; }        
        public string Sector { get; set; }     
        public int Capacidad { get; set; }      
        public EstadoMesa Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
