using System.Collections.Generic;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLCategoriaProducto
    {
        private readonly MPPCategoriaProducto _mpp;

        public BLLCategoriaProducto()
        {
            _mpp = new MPPCategoriaProducto();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public List<BECategoriaProducto> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public BECategoriaProducto ListarObjeto(long id)
        {
            return _mpp.ListarObjeto(id);
        }

        public bool Guardar(BECategoriaProducto c)
        {
            return _mpp.Guardar(c);
        }

        public bool Eliminar(BECategoriaProducto c)
        {
            return _mpp.Eliminar(c);
        }
    }
}
