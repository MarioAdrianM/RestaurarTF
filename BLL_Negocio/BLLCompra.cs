using System;
using System.Collections.Generic;
using System.Linq;
using Abstraccion;
using BE;
using MPP;

namespace BLL_Negocio
{
    public class BLLCompra : IGestor<BECompra>
    {
        private readonly MPPCompra _mpp;
        private readonly BLLCaja _bllCaja;

        public BLLCompra()
        {
            _mpp = new MPPCompra();
            _bllCaja = new BLLCaja();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }

        public bool Guardar(BECompra objeto)
        {
            
            if (objeto.Fecha.Date != DateTime.Today)
                throw new Exception("Solo se pueden registrar compras del día de hoy.");
            if (string.IsNullOrWhiteSpace(objeto.Proveedor))
                throw new Exception("El proveedor es obligatorio.");
            if (string.IsNullOrWhiteSpace(objeto.NumeroComprobante))
                throw new Exception("El número de comprobante es obligatorio.");
            if (objeto.Categoria == null)
                throw new Exception("La categoría es obligatoria.");

            if (objeto.ImporteTotal <= 0)
                throw new Exception("El importe debe ser mayor a 0.");

            var existente = _mpp.ListarTodo()
                .FirstOrDefault(x =>
                    x.Proveedor.Equals(objeto.Proveedor, StringComparison.OrdinalIgnoreCase) &&
                    x.NumeroComprobante.Equals(objeto.NumeroComprobante, StringComparison.OrdinalIgnoreCase) &&
                    x.Fecha.Date == objeto.Fecha.Date &&
                    x.Id != objeto.Id
                );

            if (existente != null)
                throw new Exception("Ya existe una compra con el mismo proveedor, fecha y número de comprobante.");
            var ok = _mpp.Guardar(objeto);
            if (ok)
            {
                string categoriaNombre = objeto.Categoria != null ? objeto.Categoria.Nombre : "";
                string concepto = $"Compra {objeto.Proveedor} ({categoriaNombre}) - Comp. {objeto.NumeroComprobante}";

                _bllCaja.RegistrarEgreso(concepto, objeto.ImporteTotal);
            }
            return ok;
        }

        public bool Eliminar(BECompra objeto)
        {
            return _mpp.Eliminar(objeto);
        }

        public bool VerificarExistenciaObjeto(BECompra objeto)
        {
            return _mpp.VerificarExistenciaObjeto(objeto);
        }

        public List<BECompra> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public BECompra ListarObjeto(BECompra objeto)
        {
            return _mpp.ListarObjeto(objeto);
        }


        public List<BECompra> ListarPorFiltro(DateTime? desde, DateTime? hasta, string categoriaNombre, string proveedor)
        {
            var lista = _mpp.ListarTodo();

            if (desde.HasValue)
                lista = lista.Where(c => c.Fecha.Date >= desde.Value.Date).ToList();

            if (hasta.HasValue)
                lista = lista.Where(c => c.Fecha.Date <= hasta.Value.Date).ToList();

            if (!string.IsNullOrWhiteSpace(categoriaNombre))
                lista = lista
                    .Where(c => c.Categoria != null &&
                                c.Categoria.Nombre.Equals(categoriaNombre, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (!string.IsNullOrWhiteSpace(proveedor))
                lista = lista
                    .Where(c => c.Proveedor.IndexOf(proveedor, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

            return lista;
        }
    }
}
