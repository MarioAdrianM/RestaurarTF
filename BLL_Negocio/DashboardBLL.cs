using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using MPP;   


namespace BLL_Negocio
{
    public class DashboardBLL
    {
        private readonly BLLMesa _bllMesa = new BLLMesa();
        private readonly BLLComanda _bllComanda = new BLLComanda();
        private readonly BLLFactura _bllFactura = new BLLFactura();
        private readonly BLLCompra _bllCompra = new BLLCompra();
        private readonly MPPCobroMozo _mppCobro = new MPPCobroMozo();


        private static DateTime Day0(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
        }

        public void Rango(string preset, out DateTime desde, out DateTime hasta)
        {
            var key = (preset ?? "HOY").Trim().ToUpperInvariant();
            var hoy0 = Day0(DateTime.Now);

            if (key == "HOY")
            {
                desde = hoy0;
                hasta = hoy0.AddDays(1);
            }
            else if (key == "7D")
            {
                desde = hoy0.AddDays(-6);
                hasta = hoy0.AddDays(1);
            }
            else if (key == "30D")
            {
                desde = hoy0.AddDays(-29);
                hasta = hoy0.AddDays(1);
            }
            else
            {
                desde = hoy0;
                hasta = hoy0.AddDays(1);
            }
        }

        private List<BEComanda> ComandasEntre(DateTime desde, DateTime hasta, string estado = null)
        {
            var res = new List<BEComanda>();
            var dia = Day0(desde);
            var fin = Day0(hasta).AddDays(1);  

            while (dia < fin)
            {
                var lista = _bllComanda.Listar(dia, estado) ?? new List<BEComanda>();
                foreach (var c in lista)
                    if (c.FechaHora >= desde && c.FechaHora < hasta)
                        res.Add(c);

                dia = dia.AddDays(1);
            }
            return res;
        }

        private List<BEFactura> FacturasEntre(DateTime desde, DateTime hasta)
        {
            var res = new List<BEFactura>();
            var dia = Day0(desde);
            var fin = Day0(hasta).AddDays(1);  

            while (dia < fin)
            {
                var lista = _bllFactura.ListarPorFecha(dia) ?? new List<BEFactura>();
                foreach (var f in lista)
                    if (f.Fecha >= desde && f.Fecha < hasta)
                        res.Add(f);

                dia = dia.AddDays(1);
            }
            return res;
        }
        private List<BECobroMozo> CobrosEntre(DateTime desde, DateTime hasta)
        {
            var res = new List<BECobroMozo>();
            var dia = Day0(desde);
            var fin = Day0(hasta).AddDays(1); 

            while (dia < fin)
            {
                var lista = _mppCobro.ListarPorFecha(dia) ?? new List<BECobroMozo>();
                foreach (var c in lista)
                {
                    if (c.FechaHora >= desde && c.FechaHora < hasta)
                        res.Add(c);
                }
                dia = dia.AddDays(1);
            }

            return res;
        }

        public List<(string medio, decimal total)> VentasPorMedioPago(DateTime desde, DateTime hasta)
        {
            var cobros = CobrosEntre(desde, hasta);

            var query = cobros
                .GroupBy(c => string.IsNullOrWhiteSpace(c.Medio) ? "Sin especificar" : c.Medio.Trim())
                .Select(g => new
                {
                    Medio = g.Key,
                    Total = g.Sum(x => x.Importe)
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            var lista = new List<(string medio, decimal total)>();
            foreach (var x in query)
                lista.Add((x.Medio, x.Total));

            return lista;
        }


        public (int libres, int ocupadas, int bloqueadas) EstadoMesas()
        {
            var mesas = _bllMesa.ListarTodo() ?? new List<BEMesa>();
            int libres = 0, ocupadas = 0, bloqueadas = 0;

            foreach (var m in mesas)
            {
                if (m.Estado == EstadoMesa.Libre) libres++;
                else if (m.Estado == EstadoMesa.Ocupada) ocupadas++;
                else if (m.Estado == EstadoMesa.Bloqueada) bloqueadas++;
            }
            return (libres, ocupadas, bloqueadas);
        }

        public (decimal total, decimal ticketPromedio, int cantidad) VentasDelDia()
        {
            var hoy0 = Day0(DateTime.Now);
            var facturas = _bllFactura.ListarPorFecha(hoy0) ?? new List<BEFactura>();
            decimal total = facturas.Sum(f => f.Total);
            int cantidad = facturas.Count;
            decimal ticket = cantidad > 0 ? Math.Round(total / cantidad, 2) : 0m;
            return (total, ticket, cantidad);
        }

        public (decimal total, int cantidad, decimal ticket) TicketPromedioRango(DateTime desde, DateTime hasta)
        {
            var facts = FacturasEntre(desde, hasta);
            var total = facts.Sum(f => f.Total);
            var cant = facts.Count;
            var ticket = cant > 0 ? Math.Round(total / cant, 2) : 0m;
            return (total, cant, ticket);
        }

        public List<(string producto, int cantidad, decimal monto)> TopProductos(DateTime desde, DateTime hasta, int topN)
        {
            var cmd = ComandasEntre(desde, hasta, null);
            var acc = new Dictionary<string, Tuple<int, decimal>>();

            foreach (var c in cmd)
            {
                if (c.Detalles == null) continue;
                foreach (var d in c.Detalles)
                {
                    if (d == null || d.Anulado) continue;
                    var nombre = string.IsNullOrWhiteSpace(d.Descripcion) ? "N/D" : d.Descripcion.Trim();
                    var cant = d.Cantidad;
                    var sub = d.Cantidad * d.PrecioUnitario;

                    Tuple<int, decimal> cur;
                    if (!acc.TryGetValue(nombre, out cur)) cur = Tuple.Create(0, 0m);
                    acc[nombre] = Tuple.Create(cur.Item1 + cant, cur.Item2 + sub);
                }
            }

            return acc
                .Select(kv => new { Producto = kv.Key, Cant = kv.Value.Item1, Monto = kv.Value.Item2 })
                .OrderByDescending(x => x.Cant)
                .ThenBy(x => x.Producto)
                .Take(topN > 0 ? topN : 5)
                .Select(x => (x.Producto, x.Cant, x.Monto))
                .ToList();
        }

        public List<(string mozo, decimal total, int cantidad)> MozosTop(DateTime desde, DateTime hasta, int topN)
        {
            var facts = FacturasEntre(desde, hasta);
            var acc = new Dictionary<string, Tuple<decimal, int>>();

            foreach (var f in facts)
            {
                var com = _bllComanda.ObtenerPorId(f.Id_Comanda);
                var mozo = (com != null && !string.IsNullOrWhiteSpace(com.Mozo)) ? com.Mozo.Trim() : "N/D";

                Tuple<decimal, int> cur;
                if (!acc.TryGetValue(mozo, out cur)) cur = Tuple.Create(0m, 0);
                acc[mozo] = Tuple.Create(cur.Item1 + f.Total, cur.Item2 + 1);
            }

            return acc
                .Select(kv => new { Mozo = kv.Key, Total = kv.Value.Item1, Cant = kv.Value.Item2 })
                .OrderByDescending(x => x.Total)
                .ThenBy(x => x.Mozo)
                .Take(topN > 0 ? topN : 5)
                .Select(x => (x.Mozo, x.Total, x.Cant))
                .ToList();
        }

        public List<(int hora, int cantidad)> ComandasPorHora(DateTime desde, DateTime hasta)
        {
            var cmd = ComandasEntre(desde, hasta, null);
            var acc = new Dictionary<int, int>();
            foreach (var c in cmd)
            {
                int h = c.FechaHora.Hour;
                int cur;
                acc[h] = acc.TryGetValue(h, out cur) ? cur + 1 : 1;
            }
            return acc.OrderBy(kv => kv.Key).Select(kv => (kv.Key, kv.Value)).ToList();
        }

        public List<(DateTime fecha, decimal total)> VentasPorDia(DateTime desde, DateTime hasta)
        {
            var facts = FacturasEntre(desde, hasta);
            var acc = new Dictionary<DateTime, decimal>();
            foreach (var f in facts)
            {
                var dia = Day0(f.Fecha);
                decimal cur;
                acc[dia] = acc.TryGetValue(dia, out cur) ? cur + f.Total : f.Total;
            }
            return acc.OrderBy(kv => kv.Key).Select(kv => (kv.Key, kv.Value)).ToList();
        }

        public (decimal total, int cantidad, decimal ticket) ComprasResumen(DateTime desde, DateTime hasta)
        {
            var compras = _bllCompra.ListarPorFiltro(desde, hasta, null, null) ?? new List<BECompra>();
            var total = compras.Sum(c => c.ImporteTotal);
            var cant = compras.Count;
            var ticket = cant > 0 ? Math.Round(total / cant, 2) : 0m;
            return (total, cant, ticket);
        }

        public List<(string familia, decimal total, double percent)> ComprasPorFamilia(DateTime desde, DateTime hasta)
        {
            try
            {
                var compras = _bllCompra.ListarPorFiltro(desde, hasta, null, null) ?? new List<BECompra>();
                if (compras.Count == 0)
                    return new List<(string, decimal, double)>();

                var grupos = compras
                    .GroupBy(c => c.Categoria != null && !string.IsNullOrWhiteSpace(c.Categoria.Nombre)
                                  ? c.Categoria.Nombre.Trim()
                                  : "Sin categoría")
                    .Select(g => new
                    {
                        Familia = g.Key,
                        Total = g.Sum(x => x.ImporteTotal)
                    })
                    .ToList();

                var totalGeneral = grupos.Sum(x => x.Total);
                if (totalGeneral <= 0)
                    return new List<(string, decimal, double)>();

                return grupos
                    .Select(x =>
                        (familia: x.Familia,
                         total: x.Total,
                         percent: Math.Round((double)(x.Total * 100m / totalGeneral), 2)))
                    .OrderByDescending(x => x.total)
                    .ToList();
            }
            catch
            {
                return new List<(string, decimal, double)>();
            }
        }

    }
}
