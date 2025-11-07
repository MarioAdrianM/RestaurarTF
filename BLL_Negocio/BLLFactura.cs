using System;
using System.Linq;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLFactura
    {
        private readonly MPPFactura _mppFactura;
        private readonly BLLComanda _bllComanda;

        public BLLFactura()
        {
            _mppFactura = new MPPFactura();
            _bllComanda = new BLLComanda();
        }

        public BEFactura GenerarFacturaDesdeComanda(long idComanda, string cliente, string cuit)
        {
            var comanda = _bllComanda.ObtenerPorId(idComanda);
            if (comanda == null)
                throw new Exception("No se encontró la comanda.");

            // 1) no facturar si la comanda no está lista
            // podés permitir "Lista" y también "Enviada" si tu cocina no marca
            if (comanda.Estado != "Lista" && comanda.Estado != "Enviada")
                throw new Exception("La comanda no está lista para facturar.");

            // 2) no facturar dos veces
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

            decimal total = 0;
            foreach (var detCom in comanda.Detalles)
            {
                decimal sub = detCom.Cantidad * detCom.PrecioUnitario;
                fac.Detalles.Add(new BEDetalleFactura
                {
                    Descripcion = detCom.Descripcion,
                    Cantidad = detCom.Cantidad,
                    PrecioUnitario = detCom.PrecioUnitario,
                    Subtotal = sub
                });
                total += sub;
            }

            fac.Total = total;

            return fac;
        }

        public long EmitirFactura(BEFactura factura)
        {
            // 3) por las dudas, volver a chequear acá que no exista (defensa doble)
            var existente = _mppFactura.ObtenerUltimaPorComanda(factura.Id_Comanda);
            if (existente != null)
                throw new Exception("La comanda ya tiene una factura.");

            long nro = _mppFactura.Registrar(factura);

            // marcar comanda como facturada
            _bllComanda.MarcarFacturada(factura.Id_Comanda);

            return nro;
        }

        public BEFactura ObtenerUltimaPorComanda(long idComanda)
        {
            return _mppFactura.ObtenerUltimaPorComanda(idComanda);
        }
    }
}
