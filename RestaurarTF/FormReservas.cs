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

        private bool _estoyCargandoFila = false;
        private bool _formCargado = false;
        private bool _rebindGrilla = false;
        private bool _modoNuevo = false;


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

            cmbMesa.DisplayMember = "Codigo";
            cmbMesa.ValueMember = "Id";

            HabilitarEdicion(false);
            CargarGrilla();
            RecalcularMesasDisponibles();

            _formCargado = true;
        }


        private void CargarGrilla()
        {
            var reservas = _bllReserva.ListarTodo() ?? new System.Collections.Generic.List<BEReserva>();

            var dia = dtpFechaHora.Value.Date;
            reservas = reservas
                .Where(r => r.FechaHora.Date == dia)
                .OrderBy(r => r.FechaHora)
                .ToList();

            dgvReservas.AutoGenerateColumns = false;

            _rebindGrilla = true;
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservas;
            if (dgvReservas.Rows.Count > 0)
                dgvReservas.ClearSelection();
            _rebindGrilla = false;
        }

        private void RecalcularMesasDisponibles()
        {
            var fecha = dtpFechaHora.Value;
            var duracion = (int)nudDuracion.Value;
            var cantidad = (int)nudPersonas.Value;

            var disponibles = _bllReserva.ConsultarDisponibilidad(fecha, duracion, cantidad);

            if (_actual != null && _actual.IdMesa.HasValue)
            {
                var yaEsta = disponibles.Any(m => m.Id == _actual.IdMesa.Value);
                if (!yaEsta)
                {
                    var mesaActual = _bllMesa.ListarTodo()
                                             .FirstOrDefault(m => m.Id == _actual.IdMesa.Value);
                    if (mesaActual != null)
                        disponibles.Add(mesaActual);
                }
            }

            cmbMesa.DataSource = null;
            cmbMesa.DataSource = disponibles;
            cmbMesa.DisplayMember = "Codigo";
            cmbMesa.ValueMember = "Id";

            btnTomarDeEspera.Enabled = (disponibles != null && disponibles.Count > 0);
        }

        private void HabilitarEdicion(bool si)
        {

            panelEdicion.Enabled = si;
            btnGuardar.Enabled = si;
            btnCancelar.Enabled = si;
            btnNuevo.Enabled = !si;

            btnMarcarAtendida.Enabled = si && _actual != null;

            dtpFechaHora.Enabled = si;
            nudDuracion.Enabled = si;
            nudPersonas.Enabled = si;
            cmbMesa.Enabled = si;
            cmbEstado.Enabled = si;

            txtObs.ReadOnly = !si;
            txtNombre.ReadOnly = !si;
            txtTelefono.ReadOnly = !si;
        }


        private void btnListaEspera_Click(object sender, EventArgs e)
        {
            var frm = new FormListaEspera();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoNuevo = true;    
            _actual = null;

            dgvReservas.ClearSelection();

            dtpFechaHora.Value = DateTime.Now;
            nudDuracion.Value = 90;
            nudPersonas.Value = 2;
            cmbEstado.SelectedItem = EstadoReserva.Pendiente;
            txtObs.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();

            RecalcularMesasDisponibles();
            HabilitarEdicion(true);

            _modoNuevo = false;     
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_actual == null)
                    _actual = new BEReserva();

                if (cmbMesa.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una mesa.");
                    return;
                }

                _actual.FechaHora = dtpFechaHora.Value;
                _actual.DuracionMinutos = (int)nudDuracion.Value;
                _actual.CantidadPersonas = (int)nudPersonas.Value;

                long? idMesa = null;
                if (cmbMesa.SelectedValue != null &&
                    long.TryParse(cmbMesa.SelectedValue.ToString(), out long temp))
                {
                    idMesa = temp;
                }
                _actual.IdMesa = idMesa;

                _actual.Estado = (EstadoReserva)cmbEstado.SelectedItem;
                _actual.Observaciones = txtObs.Text.Trim();
                _actual.UsuarioCreador = "admin"; 
                _actual.NombreCliente = txtNombre.Text.Trim();
                _actual.Telefono = txtTelefono.Text.Trim();

                _bllReserva.Guardar(_actual);

              
                if (_actual.IdMesa.HasValue)
                {
                    var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == _actual.IdMesa.Value);
                    if (mesa != null)
                    {
                        mesa.Estado = EstadoMesa.Reservada;
                        _bllMesa.Guardar(mesa);
                    }
                }

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
            if (_rebindGrilla) return;
            if (_modoNuevo) return;
            if (dgvReservas.CurrentRow == null) return;

            var res = dgvReservas.CurrentRow.DataBoundItem as BEReserva;
            if (res == null) return;

            _estoyCargandoFila = true;

            _actual = res;

            bool editable = (res.Estado == EstadoReserva.Pendiente);

            HabilitarEdicion(editable);

            dtpFechaHora.Value = res.FechaHora;
            nudDuracion.Value = res.DuracionMinutos;
            nudPersonas.Value = res.CantidadPersonas;

            RecalcularMesasDisponibles();

            if (res.IdMesa.HasValue)
                cmbMesa.SelectedValue = res.IdMesa.Value;

            cmbEstado.SelectedItem = res.Estado;
            txtObs.Text = res.Observaciones;
            txtNombre.Text = res.NombreCliente;
            txtTelefono.Text = res.Telefono;

            _estoyCargandoFila = false;
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null) return;

            var res = dgvReservas.CurrentRow.DataBoundItem as BEReserva;
            if (res == null) return;

            if (MessageBox.Show("¿Eliminar reserva?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if (res.IdMesa.HasValue)
                {
                    var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == res.IdMesa.Value);
                    if (mesa != null)
                    {
                        mesa.Estado = EstadoMesa.Libre;
                        _bllMesa.Guardar(mesa);
                    }
                }

              
                _bllReserva.Eliminar(res);

                _actual = null;
                CargarGrilla();
                HabilitarEdicion(false);
            }
        }

        private void dtpFechaHora_ValueChanged(object sender, EventArgs e)
        {
            if (!_formCargado)
                return;

            if (_estoyCargandoFila)
            {
                RecalcularMesasDisponibles();
                return;
            }

            RecalcularMesasDisponibles();
            CargarGrilla();
        }

        private void nudDuracion_ValueChanged(object sender, EventArgs e)
        {
            RecalcularMesasDisponibles();
        }

        private void nudPersonas_ValueChanged(object sender, EventArgs e)
        {
            RecalcularMesasDisponibles();
        }

        private void btnTomarDeEspera_Click(object sender, EventArgs e)
        {
            
            RecalcularMesasDisponibles();

            if (cmbMesa.DataSource == null || cmbMesa.Items.Count == 0 || cmbMesa.SelectedValue == null)
            {
                MessageBox.Show("No hay mesas libres para este horario. Anote al cliente en la lista de espera.");
                var frm = new FormListaEspera();
                frm.MdiParent = this.MdiParent;
                frm.Show();
                return;
            }

            int cantPersonas = (int)nudPersonas.Value;

            var bllLE = new BLL_Negocio.BLLListaEspera();
            var item = bllLE.ObtenerProximoPara(cantPersonas);

            if (item == null)
            {
                MessageBox.Show("No hay clientes en lista de espera para esa cantidad.");
                return;
            }

            long idMesa = Convert.ToInt64(cmbMesa.SelectedValue);
            DateTime fecha = dtpFechaHora.Value;
            int duracion = (int)nudDuracion.Value;

            var nuevaReserva = _bllReserva.CrearReservaDesdeLista(item.Id, idMesa, fecha, duracion);

            var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesa != null)
            {
                
                if (mesa.Estado == EstadoMesa.Bloqueada)
                {
                    MessageBox.Show("La mesa seleccionada está bloqueada y no puede asignarse.");
                    RecalcularMesasDisponibles();
                    return;
                }

                mesa.Estado = EstadoMesa.Ocupada;
                _bllMesa.Guardar(mesa);
            }

            MessageBox.Show($"Se creó la reserva {nuevaReserva.Id} para {item.NombreCliente}.");

            CargarGrilla();
            RecalcularMesasDisponibles();
        }


        
        private void btnMarcarAtendida_Click(object sender, EventArgs e)
        {
            if (_actual == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            _actual.Estado = EstadoReserva.Atendida;
            _bllReserva.Guardar(_actual);

            if (_actual.IdMesa.HasValue)
            {
                var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == _actual.IdMesa.Value);
                if (mesa != null)
                {
                    mesa.Estado = EstadoMesa.Ocupada;
                    _bllMesa.Guardar(mesa);
                }
            }

            MessageBox.Show("Reserva marcada como ATENDIDA y mesa ocupada.");
            CargarGrilla();
            HabilitarEdicion(false);
            _actual = null;
        }
    }
}
