using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormFacturasConsulta : Form
    {
        private readonly BLLFactura _bllFactura;
        private readonly BLLComanda _bllComanda;

        public FormFacturasConsulta()
        {
            InitializeComponent();
            _bllFactura = new BLLFactura();
            _bllComanda = new BLLComanda();
        }

        private void FormFacturasConsulta_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            CargarFacturas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (hasta < desde)
                hasta = desde;

            var lista = new List<BEFactura>();

            for (var f = desde; f <= hasta; f = f.AddDays(1))
            {
                var delDia = _bllFactura.ListarPorFecha(f);
                if (delDia != null && delDia.Count > 0)
                    lista.AddRange(delDia);
            }

            var listaMostrar = new List<dynamic>();

            foreach (var fac in lista.OrderBy(x => x.Fecha))
            {
                string mesaStr = "";
                string mozoStr = "";

                if (fac.Id_Comanda > 0)
                {
                    var comanda = _bllComanda.ObtenerPorId(fac.Id_Comanda);
                    if (comanda != null)
                    {
                        mesaStr = comanda.Id_Mesa.ToString();
                        mozoStr = comanda.Mozo;
                    }
                }

                listaMostrar.Add(new
                {
                    fac.Id,
                    fac.Numero,
                    fac.Tipo,
                    fac.Fecha,
                    Mesa = mesaStr,
                    Mozo = mozoStr,
                    fac.ClienteNombre,
                    fac.Total,
                    Id_Comanda = fac.Id_Comanda,
                    FacturaReal = fac   
                });
            }

            string mesaFiltro = txtMesa.Text.Trim();
            string mozoFiltro = txtMozo.Text.Trim();

            if (!string.IsNullOrEmpty(mesaFiltro))
                listaMostrar = listaMostrar
                    .Where(x => x.Mesa != null && x.Mesa.Equals(mesaFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (!string.IsNullOrEmpty(mozoFiltro))
                listaMostrar = listaMostrar
                    .Where(x => x.Mozo != null && x.Mozo.IndexOf(mozoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.DataSource = listaMostrar;
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una factura.");
                return;
            }
            dynamic fila = dgvFacturas.CurrentRow.DataBoundItem;
            BEFactura fac = fila.FacturaReal;
            if (fac == null)
            {
                MessageBox.Show("No se pudo recuperar la factura seleccionada.");
                return;
            }

            try
            {
                _bllFactura.Reimprimir(fac);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo reimprimir: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
