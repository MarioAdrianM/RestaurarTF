using System.Collections.Generic;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLMesa
    {
        private readonly MPPMesa _mpp;

        public BLLMesa()
        {
            _mpp = new MPPMesa();
        }

        public List<BEMesa> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public long Guardar(BEMesa mesa)
        {
            return _mpp.Guardar(mesa);
        }

        public bool Eliminar(BEMesa mesa)
        {
            return _mpp.Eliminar(mesa);
        }

        // 👇 versión compatible con C# 7.3
        public long ObtenerUltimoId()
        {
            var lista = _mpp.ListarTodo();
            if (lista == null || lista.Count == 0)
                return 0;

            // tomamos el último con Count - 1, no con ^1
            return lista[lista.Count - 1].Id;
        }
    }
}
