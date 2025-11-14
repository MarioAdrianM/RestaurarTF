using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLComanda
    {
        private readonly MPPComanda _mpp;

        public BLLComanda()
        {
            _mpp = new MPPComanda();
        }

        public long AbrirComanda(long idMesa, string mozo)
        {
            var comanda = new BEComanda
            {
                Id_Mesa = idMesa,
                FechaHora = DateTime.Now,
                Mozo = mozo,
                Estado = "Abierta"
            };

            return _mpp.Registrar(comanda);
        }

        public void AgregarItem(long idComanda, long idProducto, string descripcion, int cantidad, decimal precioUnitario)
        {
            if (cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");

            var com = _mpp.ObtenerPorId(idComanda);
            if (com == null) throw new Exception("No se encontró la comanda.");

            if (com.Estado == BEComanda.Estados.Facturada
                || com.Estado == BEComanda.Estados.Cerrada
                || com.Estado == BEComanda.Estados.ParaFacturar)
            {
                throw new Exception("No se pueden agregar productos: la comanda ya está cerrada o con factura solicitada.");
            }

            var det = new BEDetalleComanda
            {
                Id_Producto = idProducto,
                Descripcion = descripcion,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario,
                Enviado = false,
                Preparado = false
            };

            _mpp.AgregarDetalle(idComanda, det);
        }


        public void EnviarACocina(long idComanda)
        {
            var com = _mpp.ObtenerPorId(idComanda);
            if (com == null)
                throw new Exception("No se encontró la comanda.");

            
            var noEnviados = com.Detalles.Where(d => !d.Enviado).ToList();
            if (!noEnviados.Any())
                throw new Exception("No hay productos nuevos para enviar a cocina.");

           
            _mpp.MarcarDetallesEnviados(idComanda);

             if (com.Estado != BEComanda.Estados.Facturada && com.Estado != BEComanda.Estados.Cerrada)
             {
                _mpp.CambiarEstado(idComanda, BEComanda.Estados.Enviada);
             }
        }
        public void QuitarDetalle(long idComanda, int linea)
        {
            var com = _mpp.ObtenerPorId(idComanda);
            if (com == null) throw new Exception("No se encontró la comanda.");

            if (com.Estado == BEComanda.Estados.Facturada
                || com.Estado == BEComanda.Estados.Cerrada
                || com.Estado == BEComanda.Estados.ParaFacturar)
            {
                throw new Exception("No se pueden modificar los ítems: la comanda ya está cerrada o con factura solicitada.");
            }

            var det = com.Detalles.FirstOrDefault(d => d.Linea == linea);
            if (det == null) throw new Exception("No se encontró el ítem.");

           
            if (det.Preparado)
                throw new Exception("Este ítem ya fue preparado. Debe anularlo el cajero.");

          
            if (det.Anulado)
                throw new Exception("Este ítem ya fue anulado.");

           
            _mpp.EliminarDetalle(idComanda, linea);
        }
        public void AnularDetalle(long idComanda, int linea, string motivo)
        {
            var com = _mpp.ObtenerPorId(idComanda);
            if (com == null) throw new Exception("No se encontró la comanda.");

            var det = com.Detalles.FirstOrDefault(d => d.Linea == linea);
            if (det == null) throw new Exception("No se encontró el ítem.");

            
            if (!det.Preparado)
                throw new Exception("Solo se anulan ítems ya preparados.");

            _mpp.AnularDetalle(idComanda, linea, motivo);
        }


        public List<BEComanda> ListarPendientesDeCocina()
        {
            var lista = _mpp.ListarPendientesDeCocina();

            
            foreach (var c in lista)
            {
                foreach (var d in c.Detalles)
                {
                    if (d.Linea == 0)
                        d.Linea = c.Detalles.IndexOf(d) + 1;
                }
            }

            return lista;
        }
        public bool SolicitarFactura(long idComanda)
        {
            try
            {
                var com = _mpp.ObtenerPorId(idComanda);
                if (com == null)
                    return false;

               
                if (com.Estado == BEComanda.Estados.Facturada)
                    return false;

               
                if (com.Estado == BEComanda.Estados.ParaFacturar)
                    return true;

               if (com.Estado != BEComanda.Estados.Lista)
                    throw new Exception("La comanda todavía no fue marcada como LISTA en cocina.");

                _mpp.CambiarEstado(idComanda, BEComanda.Estados.ParaFacturar);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<BEComanda> ListarParaFacturar()
        {
            return _mpp.Listar(null, BEComanda.Estados.ParaFacturar);
        }
        public void MarcarLista(long idComanda)
        {
            _mpp.CambiarEstado(idComanda, "Lista");
        }

        public void MarcarFacturada(long idComanda)
        {
            var com = _mpp.ObtenerPorId(idComanda);
            if (com == null) return;
            _mpp.CambiarEstado(idComanda, BEComanda.Estados.Facturada);

            if (com.Id_Mesa > 0)
            {
                var mppMesa = new MPPMesa(); 
                var mesa = mppMesa.ListarTodo().FirstOrDefault(m => m.Id == com.Id_Mesa);
                if (mesa != null)
                {
                    mesa.Estado = EstadoMesa.Libre;
                    mppMesa.Guardar(mesa);
                }
            }
        }

        public List<BEComanda> Listar(DateTime? fecha = null, string estado = null)
        {
            return _mpp.Listar(fecha, estado);
        }
        public BEComanda ObtenerAbiertaPorMesa(long idMesa)
        {
            var lista = _mpp.Listar(DateTime.Today, null);
            return lista
                .Where(c => c.Id_Mesa == idMesa
                         && c.Estado != BEComanda.Estados.Facturada
                         && c.Estado != BEComanda.Estados.Cerrada
                         && c.Estado != BEComanda.Estados.Cancelada)  
                .OrderByDescending(c => c.FechaHora)
                .FirstOrDefault();
        }


        public BEComanda ObtenerPorId(long idComanda)
        {
            return _mpp.ObtenerPorId(idComanda);
        }
        public void MarcarDetallePreparado(long idComanda, int linea)
        {
            _mpp.MarcarDetallePreparado(idComanda, linea);

            var com = _mpp.ObtenerPorId(idComanda);
            if (com != null && com.Detalles.Where(d => !d.Anulado).All(d => d.Preparado))
            {
                _mpp.CambiarEstado(idComanda, BEComanda.Estados.Lista);
            }
        }
        public void LiberarMesaSinConsumo(long idMesa, string usuario, string motivo)
        {
            var mppMesa = new MPPMesa();

            var mesaActual = mppMesa.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesaActual == null)
                throw new Exception("No se encontró la mesa.");

            if (mesaActual.Estado == EstadoMesa.Bloqueada)
                throw new Exception("La mesa está bloqueada y solo puede ser gestionada por el encargado.");

            var com = _mpp.Listar(DateTime.Today, null)
                          .Where(c => c.Id_Mesa == idMesa
                                   && c.Estado != BEComanda.Estados.Facturada
                                   && c.Estado != BEComanda.Estados.Cerrada
                                   && c.Estado != BEComanda.Estados.Cancelada)
                          .OrderByDescending(c => c.FechaHora)
                          .FirstOrDefault();

            if (com == null)
            {
                mesaActual.Estado = EstadoMesa.Libre;
                mppMesa.Guardar(mesaActual);

                 var bllReservaSinCom = new BLLReserva();
                bllReservaSinCom.CerrarUltimaReservaDeMesa(idMesa);

                return;
            }

            bool tienePedidosActivosEnCocina = com.Detalles
                .Any(d => (d.Enviado || d.Preparado) && !d.Anulado);

            if (tienePedidosActivosEnCocina)
                throw new Exception("No se puede liberar: hay productos enviados a cocina o preparados.");

           _mpp.CancelarComanda(com.Id, usuario, motivo);

           mesaActual.Estado = EstadoMesa.Libre;
            mppMesa.Guardar(mesaActual);

            var bllReserva = new BLLReserva();
            bllReserva.CerrarUltimaReservaDeMesa(idMesa);
        }


        public void MarcarTodosPreparados(long idComanda)
        {
            _mpp.MarcarTodosPreparados(idComanda);
            _mpp.CambiarEstado(idComanda, BEComanda.Estados.Lista);
        }

        public class AnulacionItemDTO
        {
            public DateTime FechaHora { get; set; }
            public long IdComanda { get; set; }
            public long IdMesa { get; set; }
            public string Mozo { get; set; }

            public string Producto { get; set; }
            public int Cantidad { get; set; }

            public string Motivo { get; set; }
            public string UsuarioAnula { get; set; }  
        }

        public List<AnulacionItemDTO> ListarAnulaciones(DateTime desde, DateTime hasta)
        {
            var todas = _mpp.Listar(null, null)
                            .Where(c => c.FechaHora.Date >= desde.Date
                                     && c.FechaHora.Date <= hasta.Date)
                            .ToList();

            var resultado = new List<AnulacionItemDTO>();

            foreach (var c in todas)
            {
                var anulados = c.Detalles
                                .Where(d => d.Anulado && !string.IsNullOrEmpty(d.MotivoAnulacion));

                foreach (var d in anulados)
                {
                    resultado.Add(new AnulacionItemDTO
                    {
                        FechaHora = c.FechaHora,
                        IdComanda = c.Id,
                        IdMesa = c.Id_Mesa,
                        Mozo = c.Mozo,
                        Producto = d.Descripcion,
                        Cantidad = d.Cantidad,
                        Motivo = d.MotivoAnulacion,
                    });
                }
            }

            return resultado
                .OrderBy(x => x.FechaHora)
                .ThenBy(x => x.IdComanda)
                .ToList();
        }


        public class CancelacionComandaDTO
        {
            public DateTime FechaHora { get; set; }
            public long IdComanda { get; set; }
            public long IdMesa { get; set; }
            public string Mozo { get; set; }
            public string MotivoCancelacion { get; set; }
            public string UsuarioCancelacion { get; set; }
        }

        public List<CancelacionComandaDTO> ListarCancelaciones(DateTime desde, DateTime hasta)
        {
            var todas = _mpp.Listar(null, null)
                            .Where(c => c.FechaHora.Date >= desde.Date
                                     && c.FechaHora.Date <= hasta.Date
                                     && c.Estado == BEComanda.Estados.Cancelada)
                            .ToList();

            var resultado = todas
                .Select(c => new CancelacionComandaDTO
                {
                    FechaHora = c.FechaHora,
                    IdComanda = c.Id,
                    IdMesa = c.Id_Mesa,
                    Mozo = c.Mozo,
                    MotivoCancelacion = c.MotivoCancelacion,
                    UsuarioCancelacion = c.UsuarioCancelacion
                })
                .OrderBy(x => x.FechaHora)
                .ToList();

            return resultado;
        }




    }
}
