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

        public FormComandas()
        {
            InitializeComponent();
            _bll = new BLLComanda();
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

        private void CargarGrilla()
        {
            string estado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";
            DateTime fecha = dtpFecha.Value.Date;

            var lista = _bll.Listar(fecha, estado);

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

            var frm = new FormFactura(idComanda);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
