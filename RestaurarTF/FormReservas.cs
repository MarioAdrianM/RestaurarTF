using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormReservas : Form
    {
        private readonly BLLReserva _bllReserva;
        private readonly BLLMesa _bllMesa;
        private BEReserva _actual;

        public FormReservas()
        {
            InitializeComponent();
            _bllReserva = new BLLReserva();
            _bllMesa = new BLLMesa();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            _bllReserva.CrearXML();

            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoReserva));

            var mesas = _bllMesa.ListarTodo();
            cmbMesa.DataSource = mesas;
            cmbMesa.DisplayMember = "Codigo";
            cmbMesa.ValueMember = "Id";

            HabilitarEdicion(false);
            CargarGrilla();
        }

        private void CargarGrilla()
        {
          
            var lista = _bllReserva.ListarTodo();

            // si querés que se creen las columnas solas
            dgvReservas.AutoGenerateColumns = true;

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = lista;
        
        }

        private void HabilitarEdicion(bool si)
        {
            panelEdicion.Enabled = si;
            btnGuardar.Enabled = si;
            btnCancelar.Enabled = si;
            btnNuevo.Enabled = !si;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _actual = null;
            dtpFechaHora.Value = DateTime.Now;
            nudDuracion.Value = 90;
            nudPersonas.Value = 2;
            if (cmbMesa.Items.Count > 0) cmbMesa.SelectedIndex = 0;
            cmbEstado.SelectedItem = EstadoReserva.Pendiente;
            txtObs.Clear();
            HabilitarEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (_actual == null)
                    _actual = new BEReserva();   // alta

                // datos básicos
                _actual.FechaHora = dtpFechaHora.Value;
                _actual.DuracionMinutos = (int)nudDuracion.Value;
                _actual.CantidadPersonas = (int)nudPersonas.Value;

                // mesa segura
                long? idMesa = null;
                if (cmbMesa.SelectedValue != null)
                {
                    if (long.TryParse(cmbMesa.SelectedValue.ToString(), out long temp))
                        idMesa = temp;
                }
                _actual.IdMesa = idMesa;


                // resto
                _actual.Estado = (EstadoReserva)cmbEstado.SelectedItem;
                _actual.Observaciones = txtObs.Text.Trim();
                _actual.UsuarioCreador = "admin";

                // guardar
                _bllReserva.Guardar(_actual);

                MessageBox.Show("Reserva guardada.");
                _actual = null;
                HabilitarEdicion(false);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

    
           

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _actual = null;
            HabilitarEdicion(false);
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null) return;

            // tomo el objeto que está enlazado a la fila
            var res = dgvReservas.CurrentRow.DataBoundItem as BEReserva;
            if (res == null) return;

            _actual = res;

            dtpFechaHora.Value = res.FechaHora;
            nudDuracion.Value = res.DuracionMinutos;
            nudPersonas.Value = res.CantidadPersonas;

            if (res.IdMesa.HasValue)
                cmbMesa.SelectedValue = res.IdMesa.Value;
            else if (cmbMesa.Items.Count > 0)
                cmbMesa.SelectedIndex = 0;

            cmbEstado.SelectedItem = res.Estado;
            txtObs.Text = res.Observaciones;

            HabilitarEdicion(true);


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null) return;

            var res = dgvReservas.CurrentRow.DataBoundItem as BEReserva;
            if (res == null) return;

            if (MessageBox.Show("¿Eliminar reserva?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _bllReserva.Eliminar(res);
                _actual = null;
                CargarGrilla();
                HabilitarEdicion(false);
            }
        }
    }
}
