using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace BLL_Negocio
{
    public class BLLProductoCarta : IGestor<BEProductoCarta>
    {
        private readonly MPPProductoCarta _mpp;

        public BLLProductoCarta()
        {
            _mpp = new MPPProductoCarta();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Guardar(BEProductoCarta o)
        {
            return _mpp.Guardar(o);
        }

        public bool Eliminar(BEProductoCarta o)
        {
            return _mpp.Eliminar(o);
        }

        public BEProductoCarta ListarObjeto(BEProductoCarta o)
        {
            return _mpp.ListarObjeto(o);
        }

        public List<BEProductoCarta> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public bool VerificarExistenciaObjeto(BEProductoCarta o)
        {
            return _mpp.VerificarExistenciaObjeto(o);
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }
    }
}
