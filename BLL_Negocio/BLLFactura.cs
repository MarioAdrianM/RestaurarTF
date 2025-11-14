using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_Negocio
{
    public class BLLFactura
    {
        private readonly MPPFactura _mppFactura;
        private readonly BLLComanda _bllComanda;
        private readonly BLLCaja _bllCaja;   

        public BLLFactura()
        {
            _mppFactura = new MPPFactura();
            _bllComanda = new BLLComanda();
            _bllCaja = new BLLCaja();        
        }

        public BEFactura GenerarFacturaDesdeComanda(long idComanda, string cliente, string cuit)
        {
            var comanda = _bllComanda.ObtenerPorId(idComanda);
            if (comanda == null)
                throw new Exception("No se encontró la comanda.");

            if (comanda.Estado != BEComanda.Estados.ParaFacturar)
                throw new Exception("La comanda debe haber sido solicitada para facturar (estado: PARAFACTURAR).");

            var facturaExistente = _mppFactura.ObtenerUltimaPorComanda(idComanda);
            if (facturaExistente != null)
                throw new Exception("La comanda ya tiene una factura emitida.");

            var fac = new BEFactura
            {
                Fecha = DateTime.Now,
                ClienteNombre = cliente,
                ClienteCuit = cuit,
                Id_Comanda = comanda.Id
            };
            fac.Tipo = string.IsNullOrWhiteSpace(cliente) && string.IsNullOrWhiteSpace(cuit) ? "TICKET": "FACTURA";


            var detallesValidos = comanda.Detalles
                .Where(d => !d.Anulado)
                .ToList();

            var grupos = detallesValidos
                .GroupBy(d => new { d.Descripcion, d.PrecioUnitario })
                .Select(g => new
                {
                    Descripcion = g.Key.Descripcion,
                    PrecioUnitario = g.Key.PrecioUnitario,
                    Cantidad = g.Sum(x => x.Cantidad)
                });

            decimal total = 0;
            foreach (var g in grupos)
            {
                decimal sub = g.Cantidad * g.PrecioUnitario;
                fac.Detalles.Add(new BEDetalleFactura
                {
                    Descripcion = g.Descripcion,
                    Cantidad = g.Cantidad,
                    PrecioUnitario = g.PrecioUnitario,
                    Subtotal = sub
                });
                total += sub;
            }

            fac.Total = total;
            return fac;
        }


        public long EmitirFactura(BEFactura factura)
        {
            
            var cajaHoy = _bllCaja.ObtenerCajaHoy();  
            if (cajaHoy == null)
                throw new Exception("No hay caja de hoy. Abra la caja antes de emitir una factura.");
            if (cajaHoy.Estado != "Abierta")
                throw new Exception("La caja de hoy no está abierta. No se puede emitir una factura.");

            var existente = _mppFactura.ObtenerUltimaPorComanda(factura.Id_Comanda);
            if (existente != null)
                throw new Exception("La comanda ya tiene una factura.");

            
            long nro = _mppFactura.Registrar(factura);
            factura.Numero = nro;

            var comanda = _bllComanda.ObtenerPorId(factura.Id_Comanda);
            
            _mppFactura.GenerarTicketPDF(factura, comanda, cajaHoy);

            _bllComanda.MarcarFacturada(factura.Id_Comanda);
            var comandaActual = _bllComanda.ObtenerPorId(factura.Id_Comanda);
            var bllReserva = new BLLReserva();

            bllReserva.CerrarUltimaReservaDeMesa(comandaActual.Id_Mesa);

            return nro;
        }


        public BEFactura ObtenerUltimaPorComanda(long idComanda)
        {
            return _mppFactura.ObtenerUltimaPorComanda(idComanda);
        }
        public List<BEFactura> ListarPorFecha(DateTime fecha)
        {
            return _mppFactura.ListarPorFecha(fecha);
        }
 
        public void Reimprimir(BEFactura factura)
        {
            if (factura == null)
                throw new Exception("No se indicó factura.");

            var comanda = _bllComanda.ObtenerPorId(factura.Id_Comanda);
            if (comanda == null)
                throw new Exception("No se encontró la comanda asociada.");

            _mppFactura.GenerarTicketPDF(factura, comanda, null);
        }
    }
}
