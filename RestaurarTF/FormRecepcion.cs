using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormRecepcion : Form
    {
        private readonly BLLReserva _bllReserva;
        private readonly BLLListaEspera _bllLista;
        private readonly BLLMesa _bllMesa;

        public FormRecepcion()
        {
            InitializeComponent();
            _bllReserva = new BLLReserva();
            _bllLista = new BLLListaEspera();
            _bllMesa = new BLLMesa();
        }

        private void FormRecepcion_Load(object sender, EventArgs e)
        {
            CargarReservasHoy();
            CargarListaEspera();
        }

        private void CargarReservasHoy()
        {
            var hoy = DateTime.Today;
            var lista = _bllReserva.ListarTodo()
                .Where(r => r.FechaHora.Date == hoy && r.Estado == EstadoReserva.Pendiente)
                .OrderBy(r => r.FechaHora)
                .ToList();

            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.DataSource = lista
                .Select(r => new
                {
                    r.Id,
                    Hora = r.FechaHora.ToString("HH:mm"),
                    r.NombreCliente,
                    r.CantidadPersonas,
                    Mesa = r.IdMesa,
                    r.Observaciones
                })
                .ToList();
        }

        private void CargarListaEspera()
        {
            var lista = _bllLista.ListarTodo()
                .Where(x => x.Estado == EstadoListaEspera.EnEspera || x.Estado == EstadoListaEspera.Llamado)
                .OrderBy(x => x.Posicion)
                .ToList();

            dgvEspera.AutoGenerateColumns = false;
            dgvEspera.DataSource = lista
                .Select(x => new
                {
                    x.Id,
                    x.NombreCliente,
                    x.CantidadPersonas,
                    Llegó = x.FechaHoraIngreso.ToString("HH:mm"),
                    x.Estado,
                    x.Observaciones
                })
                .ToList();
        }
        private void btnMarcarLlegadaReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            long idRes = Convert.ToInt64(dgvReservas.CurrentRow.Cells["colResId"].Value);

            _bllReserva.MarcarAtendida(idRes);

            var reserva = _bllReserva.ListarTodo().First(r => r.Id == idRes);
            if (reserva.IdMesa.HasValue)
            {
                var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == reserva.IdMesa.Value);
                if (mesa != null)
                {
                    mesa.Estado = EstadoMesa.Ocupada;
                    _bllMesa.Guardar(mesa);
                }
            }

            CargarReservasHoy();
            MessageBox.Show("Reserva marcada como atendida.");
        }

        private void btnLlamarEspera_Click(object sender, EventArgs e)
        {
            if (dgvEspera.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente en espera.");
                return;
            }

            long id = Convert.ToInt64(dgvEspera.CurrentRow.Cells["colEspId"].Value);
            _bllLista.MarcarLlamado(id);
            CargarListaEspera();
        }

        private void btnAtenderEspera_Click(object sender, EventArgs e)
        {
            if (dgvEspera.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente en espera.");
                return;
            }

            long id = Convert.ToInt64(dgvEspera.CurrentRow.Cells["colEspId"].Value);
            var espera = _bllLista.ListarTodo().First(x => x.Id == id);

            var disponibles = _bllReserva.ConsultarDisponibilidad(
                DateTime.Now,
                90,
                espera.CantidadPersonas
            );

            if (disponibles == null || disponibles.Count == 0)
            {
                MessageBox.Show("No hay mesas libres ahora mismo para esa cantidad.");
                return;
            }

            var mesa = disponibles.First();

            var res = _bllReserva.CrearReservaDesdeLista(
                id,
                mesa.Id,
                DateTime.Now,
                90
            );

            mesa.Estado = EstadoMesa.Ocupada;
            _bllMesa.Guardar(mesa);

            MessageBox.Show($"Se asignó la mesa {mesa.Codigo} al cliente {espera.NombreCliente}.");

            CargarReservasHoy();
            CargarListaEspera();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
