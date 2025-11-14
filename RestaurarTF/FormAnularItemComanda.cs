using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormAnularItemComanda : Form
    {
        private readonly BLLComanda _bll;
        private BEComanda _comandaActual;

        public FormAnularItemComanda()
        {
            InitializeComponent();
            _bll = new BLLComanda();
        }

        private void FormAnularItemComanda_Load(object sender, EventArgs e)
        {
            CargarComandas();
        }

        private void CargarComandas()
        {
            var lista = _bll.Listar(DateTime.Today, null)
                .Where(c => c.Estado != BEComanda.Estados.Facturada &&
                            c.Estado != BEComanda.Estados.Cerrada)
                .OrderBy(c => c.FechaHora)
                .ToList();

            dgvComandas.AutoGenerateColumns = false;
            dgvComandas.DataSource = lista;

            dgvDetalles.DataSource = null;
            txtMotivo.Clear();
        }

        private void dgvComandas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComandas.CurrentRow == null)
            {
                _comandaActual = null;
                dgvDetalles.DataSource = null;
                return;
            }

            long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["colComId"].Value);
            _comandaActual = _bll.ObtenerPorId(idComanda);

            CargarDetalles();
        }

        private void CargarDetalles()
        {
            if (_comandaActual == null)
            {
                dgvDetalles.DataSource = null;
                return;
            }

            var detalles = _comandaActual.Detalles
                .Where(d => d.Preparado && !d.Anulado)
                .Select(d => new
                {
                    d.Linea,
                    d.Descripcion,
                    d.Cantidad,
                    d.PrecioUnitario,
                    Subtotal = d.Cantidad * d.PrecioUnitario,
                    d.MotivoAnulacion
                })
                .ToList();

            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.DataSource = detalles;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (_comandaActual == null)
            {
                MessageBox.Show("Seleccione una comanda.");
                return;
            }

            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un ítem preparado.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Debe ingresar un motivo de anulación.");
                txtMotivo.Focus();
                return;
            }

            int linea = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["colDetLinea"].Value);
            string motivo = txtMotivo.Text.Trim();

            try
            {
                _bll.AnularDetalle(_comandaActual.Id, linea, motivo);
                MessageBox.Show("Ítem anulado.");

                _comandaActual = _bll.ObtenerPorId(_comandaActual.Id);
                CargarDetalles();
                txtMotivo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo anular: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarComandas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
