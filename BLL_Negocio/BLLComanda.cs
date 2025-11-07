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

            var det = new BEDetalleComanda
            {
                Id_Producto = idProducto,
                Descripcion = descripcion,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            };

            _mpp.AgregarDetalle(idComanda, det);
        }

        public void EnviarACocina(long idComanda)
        {
            _mpp.CambiarEstado(idComanda, "Enviada");
        }

        public List<BEComanda> ListarPendientesDeCocina()
        {
            return _mpp.ListarPendientesDeCocina();
        }

        public void MarcarLista(long idComanda)
        {
            _mpp.CambiarEstado(idComanda, "Lista");
        }

        public void MarcarFacturada(long idComanda)
        {
            _mpp.CambiarEstado(idComanda, "Facturada");
        }

        public List<BEComanda> Listar(DateTime? fecha = null, string estado = null)
        {
            return _mpp.Listar(fecha, estado);
        }
        public BEComanda ObtenerAbiertaPorMesa(long idMesa)
        {
            var lista = _mpp.Listar(DateTime.Today, null);
            return lista
                .Where(c => c.Id_Mesa == idMesa && c.Estado != "Facturada" && c.Estado != "Cerrada")
                .OrderByDescending(c => c.FechaHora)
                .FirstOrDefault();
        }

        public BEComanda ObtenerPorId(long idComanda)
        {
            return _mpp.ObtenerPorId(idComanda);
        }
    }
}
