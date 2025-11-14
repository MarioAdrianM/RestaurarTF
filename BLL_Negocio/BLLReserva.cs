using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLReserva : IGestor<BEReserva>
    {
        private readonly MPPReserva _mpp;

        public BLLReserva()
        {
            _mpp = new MPPReserva();
        }
        public bool TieneReservaVigente(long idMesa)
        {
            var ahora = DateTime.Now;
            var reservas = this.ListarTodo() ?? new List<BEReserva>();

            return reservas.Any(r =>
                r.Estado == EstadoReserva.Pendiente &&
                r.IdMesa.HasValue &&
                r.IdMesa.Value == idMesa &&
                r.FechaHora <= ahora &&
                r.FechaHora.AddMinutes(r.DuracionMinutos) > ahora
            );
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Guardar(BEReserva o)
        {
            
            if (o.Id > 0)
            {
                var actual = _mpp.ListarTodo().FirstOrDefault(r => r.Id == o.Id);
                if (actual != null && actual.Estado != EstadoReserva.Pendiente)
                    throw new Exception("Solo se pueden modificar reservas en estado PENDIENTE.");
            }

            return _mpp.Guardar(o);
        }


        public bool Eliminar(BEReserva o)
        {
            var actual = _mpp.ListarTodo().FirstOrDefault(r => r.Id == o.Id);
            if (actual != null && actual.Estado != EstadoReserva.Pendiente)
                throw new Exception("Solo se pueden eliminar reservas en estado PENDIENTE.");

            return _mpp.Eliminar(o);
        }

        public void MarcarAtendida(long idReserva)
        {
            var r = _mpp.ListarTodo().FirstOrDefault(x => x.Id == idReserva);
            if (r == null) throw new Exception("No se encontró la reserva");
            r.Estado = EstadoReserva.Atendida;
            _mpp.Guardar(r);
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
        public List<BEMesa> ConsultarDisponibilidad(DateTime fechaHora, int duracionMinutos, int cantidadPersonas)
        {
            var bllMesa = new BLLMesa();
            var todasLasMesas = bllMesa.ListarTodo() ?? new List<BEMesa>();

            var todasLasReservas = this.ListarTodo() ?? new List<BEReserva>();

            DateTime desde = fechaHora;
            DateTime hasta = fechaHora.AddMinutes(duracionMinutos);

            bool esFuturo = fechaHora > DateTime.Now.AddMinutes(1);   

            var candidatas = todasLasMesas
                .Where(m => m.Capacidad >= cantidadPersonas)
                .ToList();

            if (esFuturo)
            {
                candidatas = candidatas
                    .Where(m => m.Estado != EstadoMesa.Bloqueada)
                    .ToList();
            }
            else
            {
                candidatas = candidatas
                    .Where(m => m.Estado != EstadoMesa.Bloqueada &&
                                m.Estado != EstadoMesa.Ocupada)
                    .ToList();
            }

            candidatas = candidatas
                .Where(m =>
                    !todasLasReservas
                        .Where(r =>
                         
                               (r.Estado == EstadoReserva.Pendiente ||
                                r.Estado == EstadoReserva.Atendida) &&
                               r.IdMesa.HasValue &&
                               r.IdMesa.Value == m.Id)
                        .Any(r => SeSuperponen(desde, hasta,
                                               r.FechaHora,
                                               r.FechaHora.AddMinutes(r.DuracionMinutos)))
                )
                .OrderBy(m => m.Codigo)
                .ToList();


            return candidatas;
        }

        public BEReserva CrearReservaDesdeLista(long idListaEspera, long idMesa, DateTime fechaHora, int duracionMin)
        {

            var bllLE = new BLLListaEspera();
            var item = bllLE.ListarObjeto(new BEListaEspera { Id = idListaEspera });
            if (item == null)
                throw new Exception("No se encontró el registro de lista de espera.");

            var res = new BEReserva
            {
                FechaHora = fechaHora,
                DuracionMinutos = duracionMin,
                CantidadPersonas = item.CantidadPersonas,
                IdMesa = idMesa,
                Estado = EstadoReserva.Pendiente,
                UsuarioCreador = "sistema",  
                Observaciones = "Creada desde lista de espera: " + item.NombreCliente
            };

            this.Guardar(res);

            bllLE.MarcarAtendido(idListaEspera);

            return res;
        }
        public void CerrarUltimaReservaDeMesa(long idMesa)
        {
            var todas = _mpp.ListarTodo();
            var res = todas
                .Where(r => r.IdMesa.HasValue
                            && r.IdMesa.Value == idMesa
                            && (r.Estado == EstadoReserva.Atendida))
                .OrderByDescending(r => r.FechaHora)
                .FirstOrDefault();

            if (res != null)
            {
                res.Estado = EstadoReserva.Cerrada;
                _mpp.Guardar(res);
            }
        }

        private bool SeSuperponen(DateTime d1, DateTime h1, DateTime d2, DateTime h2)
        {
           
            return d1 < h2 && d2 < h1;
        }
    }
}
