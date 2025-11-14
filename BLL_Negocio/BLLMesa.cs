using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLMesa
    {
        private readonly MPPMesa _mpp;
        private readonly BLLReserva _bllReserva;
        private readonly BLLComanda _bllComanda;


        public BLLMesa()
        {
            _mpp = new MPPMesa();
            _bllReserva = new BLLReserva();
            _bllComanda = new BLLComanda();
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
            return false;
        }
        public bool BloquearMesa(long idMesa)
        {
            var mesa = _mpp.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesa == null)
                throw new Exception("No se encontró la mesa.");

            if (mesa.Estado == EstadoMesa.Bloqueada)
                throw new Exception("La mesa ya está bloqueada.");

            if (mesa.Estado == EstadoMesa.Ocupada || mesa.Estado == EstadoMesa.Reservada)
                throw new Exception("La mesa está en uso (ocupada o reservada) y no puede bloquearse.");

            if (_bllReserva.TieneReservaVigente(idMesa))
                throw new Exception("La mesa tiene una reserva vigente y no puede bloquearse.");

            var com = _bllComanda.ObtenerAbiertaPorMesa(idMesa);
            if (com != null)
            {
 
                if (com.Estado != BEComanda.Estados.Facturada &&
                    com.Estado != BEComanda.Estados.Cerrada &&
                    com.Estado != BEComanda.Estados.Cancelada)
                {
                    throw new Exception("La mesa tiene una comanda en curso y no puede bloquearse.");
                }
            }

            mesa.Estado = EstadoMesa.Bloqueada;
            _mpp.Guardar(mesa);
            return true;
        }

        public bool DesbloquearMesa(long idMesa)
        {
            var mesa = _mpp.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesa == null)
                throw new Exception("No se encontró la mesa.");

            mesa.Estado = EstadoMesa.Libre;
            _mpp.Guardar(mesa);
            return true;
        }
        public long ObtenerUltimoId()
        {
            var lista = _mpp.ListarTodo();
            if (lista == null || lista.Count == 0)
                return 0;
            return lista[lista.Count - 1].Id;
        }
    }
}
