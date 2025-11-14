using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLProductoCarta : IGestor<BEProductoCarta>
    {
        private readonly MPPProductoCarta _mpp;
        private readonly BLLComanda _bllComanda;

        public BLLProductoCarta()
        {
            _mpp = new MPPProductoCarta();
            _bllComanda = new BLLComanda();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Guardar(BEProductoCarta o)
        {
            if (string.IsNullOrWhiteSpace(o.Nombre))
                throw new System.Exception("El nombre del producto es obligatorio.");

            var todos = _mpp.ListarTodo();
            bool existe = todos
                .Any(p =>
                    p.Id != o.Id &&                        
                    !string.IsNullOrWhiteSpace(p.Nombre) &&
                    p.Nombre.Trim().ToUpper() == o.Nombre.Trim().ToUpper());

            if (existe)
                throw new System.Exception("Ya existe un producto con ese nombre.");

            return _mpp.Guardar(o);
        }

       
        public bool Eliminar(BEProductoCarta o)
        {
            var comandas = _bllComanda.Listar(null, null); 
          
            var enUso = comandas
                .Where(c =>
                    c.Estado != BEComanda.Estados.Facturada &&
                    c.Estado != BEComanda.Estados.Cerrada)
                .Any(c =>
                    c.Detalles != null &&
                    c.Detalles.Any(d => d.Id_Producto == o.Id && !d.Anulado));

            if (enUso)
                throw new System.Exception("No se puede eliminar el producto porque está en una comanda aún no facturada.");

     
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
