using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormCocina : Form
    {
        private readonly BLLComanda _bll;

        public FormCocina()
        {
            InitializeComponent();
            _bll = new BLLComanda();
        }

        private void FormCocina_Load(object sender, EventArgs e)
        {
            CargarComandas();
        }

        private void CargarComandas()
        {
            var lista = _bll.ListarPendientesDeCocina();
            dgvComandas.AutoGenerateColumns = true;
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

            // limpiar detalle
            dgvDetalles.DataSource = null;
        }

        private void dgvComandas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvComandas.CurrentRow == null) return;

                long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["Id"].Value);

                // traemos la comanda completa para ver sus detalles
                var com = _bll.ObtenerPorId(idComanda);
                if (com == null)
                {
                    dgvDetalles.DataSource = null;
                    return;
                }

                var det = com.Detalles
                    .Select(d => new
                    {
                        d.Descripcion,
                        d.Cantidad,
                        d.PrecioUnitario,
                        Subtotal = d.Cantidad * d.PrecioUnitario
                    })
                    .ToList();

                dgvDetalles.AutoGenerateColumns = true;
                dgvDetalles.DataSource = det;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        private void btnMarcarLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComandas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una comanda.");
                    return;
                }

                long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["Id"].Value);
                _bll.MarcarLista(idComanda);
                CargarComandas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar como lista: " + ex.Message);
            }
        }
    }
}
