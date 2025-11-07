using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLCaja
    {
        private readonly MPPCaja _mppCaja;
        private readonly MPPCobroMozo _mppCobro;

        public BLLCaja()
        {
            _mppCaja = new MPPCaja();
            _mppCobro = new MPPCobroMozo();
        }

        public BECaja ObtenerCajaHoy()
        {
            return _mppCaja.ObtenerCajaDeFecha(DateTime.Today);
        }

        public void AbrirCaja(decimal montoInicial)
        {
            // no abrir 2 veces el mismo día
            var cajaHoy = ObtenerCajaHoy();
            if (cajaHoy != null)
                throw new Exception("La caja de hoy ya existe.");

            var caja = new BECaja
            {
                Fecha = DateTime.Today,
                Apertura = DateTime.Now,
                Estado = "Abierta",
                MontoInicial = montoInicial,
                MontoFinal = 0
            };

            _mppCaja.AbrirCaja(caja);
        }

        public void CerrarCaja()
        {
            var caja = ObtenerCajaHoy();
            if (caja == null)
                throw new Exception("No hay caja abierta.");

            // podemos calcular el total como: monto inicial + ingresos - egresos
            var movimientos = _mppCaja.ListarMovimientos(caja.Id);

            decimal totalIngresos = movimientos
                .Where(m => m.Tipo == "Ingreso")
                .Sum(m => m.Importe);

            decimal totalEgresos = movimientos
                .Where(m => m.Tipo == "Egreso")
                .Sum(m => m.Importe);

            decimal montoFinal = caja.MontoInicial + totalIngresos - totalEgresos;

            _mppCaja.CerrarCaja(caja.Id, montoFinal);
        }

        // esto es lo que usa tu FormCaja para llenar el grid
        public List<BECobroMozo> ListarCobrosPendientesDeRendicion()
        {
            return _mppCobro.ListarNoRendidos();
        }

        // esto es lo que hace el botón "Rendir seleccionado"
        public void RendirCobro(long idCobro)
        {
            var caja = ObtenerCajaHoy();
            if (caja == null || caja.Estado != "Abierta")
                throw new Exception("No hay caja abierta.");

            // buscamos el cobro dentro de los pendientes
            var cobro = _mppCobro.ListarNoRendidos()
                                 .FirstOrDefault(c => c.Id == idCobro);

            if (cobro == null)
                throw new Exception("El cobro no existe o ya fue rendido.");

            // 1) registramos movimiento en caja
            var mov = new BEMovimientoCaja
            {
                Id_Caja = caja.Id,
                FechaHora = DateTime.Now,
                Tipo = "Ingreso",
                Concepto = $"Rendición mozo {cobro.Mozo} (comanda {cobro.Id_Comanda})",
                Importe = cobro.Importe,
                Id_Comanda = cobro.Id_Comanda
            };
            _mppCaja.RegistrarMovimiento(mov);

            // 2) marcamos el cobro como rendido
            _mppCobro.MarcarComoRendido(cobro.Id);
        }
        public List<BEMovimientoCaja> ListarMovimientosCajaHoy()
        {
            var caja = ObtenerCajaHoy();
            if (caja == null)
                return new List<BEMovimientoCaja>();

            return _mppCaja.ListarMovimientos(caja.Id);
        }

    }
}
