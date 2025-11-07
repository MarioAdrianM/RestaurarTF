using Abstraccion;
using BE.BEComposite;
using MPP;
using System.Collections.Generic;

namespace BLL_Negocio
{
    public class BLLPermiso : IGestor<BEPermiso>
    {
        private readonly MPPPermiso _mpp;

        public BLLPermiso()
        {
            _mpp = new MPPPermiso();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Eliminar(BEPermiso oBEPermiso)
        {
            return _mpp.Eliminar(oBEPermiso);
        }

        public bool Guardar(BEPermiso oBEPermiso)
        {
            return _mpp.Guardar(oBEPermiso);
        }

        public BEPermiso ListarObjeto(BEPermiso oBEPermiso)
        {
            return _mpp.ListarObjeto(oBEPermiso);
        }

        public List<BEPermiso> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }

        public bool VerificarExistenciaObjeto(BEPermiso objeto)
        {
            return _mpp.VerificarExistenciaObjeto(objeto);
        }
    }
}
