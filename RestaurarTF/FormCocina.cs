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
        private void CargarDetalleComanda(long idComanda)
        {
            var com = _bll.ObtenerPorId(idComanda);
            if (com == null)
            {
                dgvDetalles.DataSource = null;
                return;
            }

            var pendientes = com.Detalles
                .Where(d => d.Enviado && !d.Preparado)
                .ToList();
            var det = pendientes
        .GroupBy(d => new { d.Descripcion, d.PrecioUnitario })
        .Select(g => new
        {
            Producto = g.Key.Descripcion,
            Cantidad = g.Sum(x => x.Cantidad),
            P_Unit = g.Key.PrecioUnitario,
            Subtotal = g.Sum(x => x.Cantidad * x.PrecioUnitario)
        })
        .OrderBy(x => x.Producto)
        .ToList();

            dgvDetalles.AutoGenerateColumns = true;
            dgvDetalles.DataSource = det;
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
            if (dgvComandas.Rows.Count > 0)
            {
                var id = Convert.ToInt64(dgvComandas.Rows[0].Cells["Id"].Value);
                CargarDetalleComanda(id);
            }
            else
            {
                dgvDetalles.DataSource = null;
            }
        }

        private void dgvComandas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvComandas.CurrentRow == null) return;

                long idComanda = Convert.ToInt64(dgvComandas.CurrentRow.Cells["Id"].Value);
                CargarDetalleComanda(idComanda);
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
                _bll.MarcarTodosPreparados(idComanda);
                CargarComandas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar como lista: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarComandas();
        }
    }
}
