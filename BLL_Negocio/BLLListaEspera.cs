using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLListaEspera : IGestor<BEListaEspera>
    {
        private readonly MPPListaEspera _mpp;

        public BLLListaEspera()
        {
            _mpp = new MPPListaEspera();
        }

        public bool Guardar(BEListaEspera o)
        {
            if (o.FechaHoraIngreso == DateTime.MinValue)
                o.FechaHoraIngreso = DateTime.Now;

            if (string.IsNullOrWhiteSpace(o.NombreCliente))
                throw new Exception("Debe indicar el nombre del cliente.");

            if (o.CantidadPersonas <= 0)
                o.CantidadPersonas = 2;

            return _mpp.Guardar(o);
        }

        public bool Eliminar(BEListaEspera o) => _mpp.Eliminar(o);
        public bool VerificarExistenciaObjeto(BEListaEspera o) => _mpp.VerificarExistenciaObjeto(o);
        public List<BEListaEspera> ListarTodo() => _mpp.ListarTodo();
        public BEListaEspera ListarObjeto(BEListaEspera o) => _mpp.ListarObjeto(o);
        public bool CrearXML() => _mpp.CrearXML();
        public long ObtenerUltimoId() => _mpp.ObtenerUltimoId();

   
        public BEListaEspera ObtenerProximoPara(int cantidadPersonas)
        {
            var todos = _mpp.ListarTodo();
            return todos
                .Where(x => x.Estado == EstadoListaEspera.EnEspera
                            && x.CantidadPersonas <= cantidadPersonas)
                .OrderBy(x => x.Posicion)
                .FirstOrDefault();
        }

        public void MarcarAtendido(long id)
        {
            var obj = ListarObjeto(new BEListaEspera { Id = id });
            if (obj == null) return;
            obj.Estado = EstadoListaEspera.Atendido;
            Guardar(obj);
        }

        public void MarcarSalteado(long id)
        {
            var obj = ListarObjeto(new BEListaEspera { Id = id });
            if (obj == null) return;
            obj.Estado = EstadoListaEspera.Salteado;
            Guardar(obj);
        }

        public void MarcarLlamado(long id)
        {
            var obj = ListarObjeto(new BEListaEspera { Id = id });
            if (obj == null) return;
            obj.Estado = EstadoListaEspera.Llamado;
            Guardar(obj);
        }
    }
}
