using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora: BEEntidad
    {
        #region "Propiedades"

        public DateTime FechaRegistro { get; set; }

        public string Detalle { get; set; }

        public BEUsuario oBEUsuario { get; set; }
        
        #endregion

        #region "Constructor"

        public BEBitacora() { }

        public BEBitacora(long pId, DateTime pFechaRegistro, string pDetalle)
        {
            Id = pId;
            FechaRegistro = pFechaRegistro;
            Detalle = pDetalle;
        }

        #endregion


        #region "Métodos"



        #endregion
    }
}
