using System;

namespace BE
{
     public enum EstadoListaEspera
    {
        EnEspera = 0,
        Llamado = 1,
        Atendido = 2,
        Cancelado = 3,
        Salteado = 4
    }

    public class BEListaEspera : BEEntidad
    {
        public DateTime FechaHoraIngreso { get; set; }     
        public string NombreCliente { get; set; }         
        public int CantidadPersonas { get; set; }          
        public string Contacto { get; set; }              
        public DateTime? ETA { get; set; }           
        public EstadoListaEspera Estado { get; set; }
        public string Observaciones { get; set; }

        public int Posicion { get; set; }
    }
}
