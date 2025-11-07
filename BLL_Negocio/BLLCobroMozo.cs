using System;
using System.Collections.Generic;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLCobroMozo
    {
        private readonly MPPCobroMozo _mpp;

        public BLLCobroMozo()
        {
            _mpp = new MPPCobroMozo();
        }

        public void RegistrarCobro(long idComanda, string mozo, string medio, decimal importe)
        {
            if (idComanda <= 0)
                throw new Exception("La comanda no es válida.");

            if (importe <= 0)
                throw new Exception("El importe debe ser mayor a cero.");

            var cobro = new BECobroMozo
            {
                Id_Comanda = idComanda,
                FechaHora = DateTime.Now,
                Mozo = mozo,
                Medio = medio,
                Importe = importe,
                Rendido = false
            };

            _mpp.Registrar(cobro);
        }

        public List<BECobroMozo> ListarNoRendidos()
        {
            return _mpp.ListarNoRendidos();
        }

        // lo usaremos más adelante desde el form de “rendición”
        public void MarcarComoRendido(long idCobro)
        {
            _mpp.MarcarComoRendido(idCobro);
        }
    }
}
