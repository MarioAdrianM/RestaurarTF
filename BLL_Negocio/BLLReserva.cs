using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace BLL_Negocio
{
    public class BLLReserva : IGestor<BEReserva>
    {
        private readonly MPPReserva _mpp;

        public BLLReserva()
        {
            _mpp = new MPPReserva();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Guardar(BEReserva o)
        {
            return _mpp.Guardar(o);
        }

        public bool Eliminar(BEReserva o)
        {
            return _mpp.Eliminar(o);
        }

        public BEReserva ListarObjeto(BEReserva o)
        {
            return _mpp.ListarObjeto(o);
        }

        public List<BEReserva> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public bool VerificarExistenciaObjeto(BEReserva o)
        {
            return _mpp.VerificarExistenciaObjeto(o);
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }
    }
}
