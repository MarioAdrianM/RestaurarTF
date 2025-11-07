using System;
using System.Collections.Generic;

namespace BE
{
    public class BEComanda
    {
        public long Id { get; set; }
        public long Id_Mesa { get; set; }
        public DateTime FechaHora { get; set; }
        public string Mozo { get; set; }          // podés guardar el nombre del mozo logueado
        public string Estado { get; set; }        // "Abierta", "Enviada", "Lista", "Facturada", "Cerrada"
        public List<BEDetalleComanda> Detalles { get; set; }

        public BEComanda()
        {
            Detalles = new List<BEDetalleComanda>();
        }
    }
}
