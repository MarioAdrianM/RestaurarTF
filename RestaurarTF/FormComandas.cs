using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormComandas : Form
    {
        private readonly BLLComanda _bll;
        private readonly BLLFactura _bllFactura;

        public FormComandas()
        {
            InitializeComponent();
            _bll = new BLLComanda();
            _bllFactura = new BLLFactura();
        }

        private void FormComandas_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Todos");
            cboEstado.Items.Add("Abierta");
            cboEstado.Items.Add("Enviada");
            cboEstado.Items.Add("Lista");
            cboEstado.Items.Add("Facturada");
            cboEstado.SelectedIndex = 0;

            CargarGrilla();
        }
        private void btnPendientes_Click(object sender, EventArgs e)
        {
            var lista = _bll.ListarParaFacturar();
            dgvComandas.AutoGenerateColumns = false;
            dgvComandas.DataSource = lista
                .Select(c => new
                {
                    c.Id,
                    c.Id_Mesa,
                    c.FechaHora,
                    c.Mozo,
                    c.Estado
                })
                .ToList();
        }

        private void CargarGrilla()
        {
            string estado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";
            DateTime fecha = dtpFecha.Value.Date;

            var lista = _bll.Listar(fecha, estado);

            lista = lista.Where(c => c.Estado != BEComanda.Estados.Cancelada).ToList();
            dgvComandas.AutoGenerateColumns = false;
            dgvComandas.DataSource = lista
                .Select(c => new
                {
                    c.Id,
                    c.Id_Mesa,
                    c.FechaHora,
                    c.Mozo,
                    c.Estado
                })
                .ToList();
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dgvComandas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una comanda.");
                return;
            }


            string estado = dgvComandas.CurrentRow.Cells["colEstado"].Value?.ToString();
            long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["colId"].Value);

            if (estado == "Facturada")
            {
                var fac = _bllFactura.ObtenerUltimaPorComanda(idComanda);
                if (fac != null)
                {
                    MessageBox.Show(
                        $"Esta comanda ya está facturada.\nFactura N°: {fac.Numero}\nFecha: {fac.Fecha:dd/MM/yyyy HH:mm}\nTotal: {fac.Total:N2}",
                        "Comanda facturada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show("Esta comanda figura facturada pero no se encontró la factura en el XML.");
                }
                return;
            }

            long idMesa = Convert.ToInt64(dgvComandas.CurrentRow.Cells["colMesa"].Value);
            string mozo = dgvComandas.CurrentRow.Cells["colMozo"].Value?.ToString() ?? "";

            var frm = new FormComandaMesa(idMesa, mozo);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvComandas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una comanda.");
                return;
            }

            long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["colId"].Value);
            string estado = dgvComandas.CurrentRow.Cells["colEstado"].Value?.ToString();

            if (estado == "Facturada")
            {
                var fac = _bllFactura.ObtenerUltimaPorComanda(idComanda);
                if (fac != null)
                {
                    MessageBox.Show(
                        $"Comanda ya facturada.\nFactura N°: {fac.Numero}\nTotal: {fac.Total:N2}",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show("La comanda está en estado FACTURADA pero no se encontró la factura.");
                }

                CargarGrilla();
                return;
            }

            var frm = new FormFactura(idComanda);
            frm.MdiParent = this.MdiParent;

            frm.FormClosed += (s, args) => CargarGrilla();

            frm.Show();
        }
    }
}
