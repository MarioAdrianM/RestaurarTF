using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLCobroMozo
    {
        private readonly MPPCobroMozo _mppCobro;
        private readonly MPPComanda _mppComanda;
        private readonly MPPFactura _mppFactura;

        public BLLCobroMozo()
        {
            _mppCobro = new MPPCobroMozo();
            _mppComanda = new MPPComanda();
            _mppFactura = new MPPFactura();
        }

        public List<BECobroMozo> ListarNoRendidos()
        {
            return _mppCobro.ListarNoRendidos();
        }
        
        public List<BEComandaFacturadaMozo> ListarFacturadasPendientesDeCobro(string mozo)
        {
            if (string.IsNullOrWhiteSpace(mozo))
                throw new Exception("No se indicó el mozo.");

            mozo = mozo.Trim();

            //cpomandas de hoy facturadas y del mozo
            var comandasFacturadas = _mppComanda
                .Listar(DateTime.Today, BEComanda.Estados.Facturada)
                .Where(c => string.Equals(c.Mozo, mozo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //  cobro ese mozo 
            var cobrosDelDiaDelMozo = _mppCobro
                .ListarPorFecha(DateTime.Today)                   
                .Where(c => string.Equals(c.Mozo, mozo, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Id_Comanda)
                .ToHashSet();

            var resultado = new List<BEComandaFacturadaMozo>();

            foreach (var com in comandasFacturadas)
            {
                // sihay cobro no la muestro
                if (cobrosDelDiaDelMozo.Contains(com.Id))
                    continue;

                // busco la factura para saber el total
                var fac = _mppFactura.ObtenerUltimaPorComanda(com.Id);
                if (fac == null)
                    continue;

                resultado.Add(new BEComandaFacturadaMozo
                {
                    IdComanda = com.Id,
                    Mesa = com.Id_Mesa,
                    Fecha = com.FechaHora,
                    Total = fac.Total
                });
            }

            return resultado
                .OrderByDescending(x => x.Fecha)
                .ToList();
        }

        public void RegistrarCobro(string mozo, long idComanda, string medio)
        {
            if (idComanda <= 0) throw new Exception("La comanda no es válida.");
            if (string.IsNullOrWhiteSpace(mozo)) throw new Exception("No se indicó el mozo.");

            var fac = _mppFactura.ObtenerUltimaPorComanda(idComanda);
            if (fac == null)
                throw new Exception("La comanda no tiene factura emitida.");

            var cobro = new BECobroMozo
            {
                Id_Comanda = idComanda,
                FechaHora = DateTime.Now,
                Mozo = mozo.Trim(),
                Medio = medio ?? "Efectivo",
                Importe = fac.Total,
                Rendido = false
            };

            _mppCobro.Registrar(cobro);
        }
    }
}
