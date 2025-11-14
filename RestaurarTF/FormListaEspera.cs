using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormListaEspera : Form
    {
        private readonly BLLListaEspera _bll;
        private BEListaEspera _actual;

        public FormListaEspera()
        {
            InitializeComponent();
            _bll = new BLLListaEspera();
        }

        private void FormListaEspera_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            HabilitarEdicion(false);
        }

        private void CargarGrilla()
        {
            var datos = _bll.ListarTodo();
            dgvLista.DataSource = null;
            dgvLista.DataSource = datos;
        }

        private void HabilitarEdicion(bool si)
        {
            txtNombre.Enabled = si;
            nudPersonas.Enabled = si;
            txtContacto.Enabled = si;
            dtpETA.Enabled = si;
            txtObs.Enabled = si;
            btnGuardar.Enabled = si;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _actual = null;
            txtNombre.Clear();
            nudPersonas.Value = 2;
            txtContacto.Clear();
            dtpETA.Value = DateTime.Now.AddMinutes(15);
            txtObs.Clear();
            HabilitarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe indicar el nombre del cliente.");
                return;
            }

            var le = _actual ?? new BEListaEspera();
            le.NombreCliente = txtNombre.Text.Trim();
            le.CantidadPersonas = (int)nudPersonas.Value;
            le.Contacto = txtContacto.Text.Trim();
            le.ETA = dtpETA.Value;
            le.Observaciones = txtObs.Text.Trim();

            if (_actual == null)
            {
                le.FechaHoraIngreso = DateTime.Now;
                le.Estado = EstadoListaEspera.EnEspera;
            }

            _bll.Guardar(le);
            CargarGrilla();
            HabilitarEdicion(false);
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            var item = dgvLista.CurrentRow.DataBoundItem as BEListaEspera;
            if (item == null) return;

            _actual = item;
            txtNombre.Text = item.NombreCliente;
            nudPersonas.Value = item.CantidadPersonas;
            txtContacto.Text = item.Contacto;
            dtpETA.Value = item.ETA ?? DateTime.Now;
            txtObs.Text = item.Observaciones;
            HabilitarEdicion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;
            if (MessageBox.Show("¿Eliminar de la lista de espera?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _bll.Eliminar(_actual);
                _actual = null;
                CargarGrilla();
                HabilitarEdicion(false);
            }
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;
            _actual.Estado = EstadoListaEspera.Llamado;
            _bll.Guardar(_actual);
            CargarGrilla();
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;
            _actual.Estado = EstadoListaEspera.Atendido;
            _bll.Guardar(_actual);
            CargarGrilla();
        }

        private void btnSaltear_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;
            _actual.Estado = EstadoListaEspera.Salteado;
            _bll.Guardar(_actual);
            CargarGrilla();
        }
    }
}
