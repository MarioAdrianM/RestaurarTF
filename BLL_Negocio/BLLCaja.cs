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
        private readonly MPPFactura _mppFactura;

        public BLLCaja()
        {
            _mppCaja = new MPPCaja();
            _mppCobro = new MPPCobroMozo();
            _mppFactura = new MPPFactura();
        }

        public BECaja ObtenerCajaHoy()
        {
            return _mppCaja.ObtenerCajaDeFecha(DateTime.Today);
        }

        public void AbrirCaja(decimal montoInicial)
        {
            var cajaHoy = _mppCaja.ObtenerCajaDeFecha(DateTime.Today);

            if (cajaHoy == null)
            {
                var cajaNueva = new BECaja
                {
                    Fecha = DateTime.Today,
                    Apertura = DateTime.Now,
                    Estado = "Abierta",
                    MontoInicial = montoInicial,
                    MontoFinal = 0
                };
                _mppCaja.AbrirCaja(cajaNueva);
                return;
            }

            if (cajaHoy.Estado == "Abierta")
                throw new Exception("La caja de hoy ya está abierta.");

            var otraCaja = new BECaja//si esta cerrada
            {
                Fecha = DateTime.Today,
                Apertura = DateTime.Now,
                Estado = "Abierta",
                MontoInicial = montoInicial,
                MontoFinal = 0
            };
            _mppCaja.AbrirCaja(otraCaja);
        }

        public void CerrarCaja()
        {
            var caja = ObtenerCajaHoy();
            if (caja == null)
                throw new Exception("No hay caja abierta.");

            var movimientos = _mppCaja.ListarMovimientos(caja.Id);//de hoy

            decimal totalIngresos = movimientos
                .Where(m => m.Tipo == "Ingreso")
                .Sum(m => m.Importe);

            decimal totalEgresos = movimientos
                .Where(m => m.Tipo == "Egreso")
                .Sum(m => m.Importe);

            decimal montoFinal = caja.MontoInicial + totalIngresos - totalEgresos;

            _mppCaja.CerrarCaja(caja.Id, montoFinal);//a la bbd

            var cajaCerrada = _mppCaja.ObtenerCajaDeFecha(caja.Fecha);

            _mppCaja.GenerarInformeCierrePDF(cajaCerrada, movimientos);
        }


        public List<BECobroMozo> ListarCobrosPendientesDeRendicion()
        {
            return _mppCobro.ListarNoRendidos();
        }
        public void RendirCobro(long idCobro)
        {
            var caja = ObtenerCajaHoy();
            if (caja == null || caja.Estado != "Abierta")
                throw new Exception("No hay caja abierta.");

            var cobro = _mppCobro.ListarNoRendidos()
                                 .FirstOrDefault(c => c.Id == idCobro);

            if (cobro == null)
                throw new Exception("El cobro no existe o ya fue rendido.");

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

            _mppCobro.MarcarComoRendido(cobro.Id);
        }
        public (List<BECobroMozo> cobrosNoRendidos, List<BEFactura> facturasSinCobro)
            GetPendientesDeCierreHoy()
        {
            var hoy = DateTime.Today;

            var cobrosNoRendidos = _mppCobro.ListarNoRendidos();

            var facturasHoy = _mppFactura.ListarPorFecha(hoy);

            var cobrosHoy = _mppCobro.ListarPorFecha(hoy);
            //TODO
          
            var facturasSinCobro = facturasHoy
                .Where(f => !cobrosHoy.Any(c => c.Id_Comanda == f.Id_Comanda))
                .ToList();

            return (cobrosNoRendidos, facturasSinCobro);
        }
        public List<BEMovimientoCaja> ListarMovimientosCajaHoy()
        {
            var caja = ObtenerCajaHoy();
            if (caja == null)
                return new List<BEMovimientoCaja>();

            return _mppCaja.ListarMovimientos(caja.Id);
        }
        public void RegistrarEgreso(string concepto, decimal importe)
        {
            var caja = ObtenerCajaHoy();
            if (caja == null || caja.Estado != "Abierta")
                throw new Exception("No hay caja abierta. Abra la caja para registrar gastos.");

            var mov = new BEMovimientoCaja
            {
                Id_Caja = caja.Id,
                FechaHora = DateTime.Now,
                Tipo = "Egreso",
                Concepto = concepto ?? "Compra",
                Importe = importe,
                Id_Comanda = null
            };
            _mppCaja.RegistrarMovimiento(mov);
        }

    }
}
