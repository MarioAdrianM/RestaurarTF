using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormSalonMozo : Form
    {
        private readonly string _mozo;
        private readonly BLLMesa _bllMesa;
        private readonly BLLComanda _bllComanda;
        private readonly BLLReserva _bllReserva;

        public FormSalonMozo(string mozo)
        {
            InitializeComponent();
            _mozo = mozo;
            _bllMesa = new BLLMesa();
            _bllComanda = new BLLComanda();
            _bllReserva = new BLLReserva();
        }

        private void FormSalonMozo_Load(object sender, EventArgs e)
        {
            lblMozo.Text = "Mozo: " + _mozo;
            CargarMesas();
        }

        private void CargarMesas()
        {
            var mesas = _bllMesa.ListarTodo();

            var lista = mesas
                .Select(m =>
                {
                    var com = _bllComanda.ObtenerAbiertaPorMesa(m.Id);
                    string estadoVisual;

                    if (com != null)
                    {
                        switch (com.Estado)
                        {
                            case BEComanda.Estados.Enviada:
                                estadoVisual = "Con pedido";
                                break;
                            case BEComanda.Estados.Lista:
                                estadoVisual = "Pedido listo";
                                break;
                            case BEComanda.Estados.ParaFacturar:
                                estadoVisual = "Pidiendo factura";
                                break;
                            default:
                                estadoVisual = "Ocupada";
                                break;
                        }
                    }
                    else
                    {
                        if (m.Estado == EstadoMesa.Bloqueada)
                        {
                            estadoVisual = "Bloqueada";
                        }
                        else if (m.Estado == EstadoMesa.Ocupada)
                        {
                            estadoVisual = "Ocupada";
                        }
                        else if (_bllReserva.TieneReservaVigente(m.Id))
                        {
                            estadoVisual = "Reservada";
                        }
                        else
                        {
                            estadoVisual = "Libre";
                        }
                    }

                    return new
                    {
                        Id = m.Id,
                        Codigo = m.Codigo,
                        Numero = m.Numero,
                        Sector = m.Sector,
                        Capacidad = m.Capacidad,
                        Estado = estadoVisual
                    };
                })
                .OrderBy(x => x.Numero)
                .ToList();

            dgvMesas.AutoGenerateColumns = false;
            dgvMesas.DataSource = lista;
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarMesas();
        }

        private void dgvMesas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirMesaSeleccionada();
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            AbrirMesaSeleccionada();
        }

        private void AbrirMesaSeleccionada()
        {
            if (dgvMesas.CurrentRow == null) return;

            long idMesa = Convert.ToInt64(dgvMesas.CurrentRow.Cells["colIdMesa"].Value);

            var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesa == null)
            {
                MessageBox.Show("No se encontró la mesa.");
                return;
            }
            if (mesa.Estado == EstadoMesa.Bloqueada)
            {
                MessageBox.Show("La mesa está bloqueada. Consulte al encargado.");
                return;
            }

            var com = _bllComanda.ObtenerAbiertaPorMesa(idMesa);
            if (com != null)
            {
                var frm = new FormComandaMesa(idMesa, _mozo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
                CargarMesas();
                return;
            }
            if (mesa.Estado == EstadoMesa.Ocupada)
            {
                var frm = new FormComandaMesa(idMesa, _mozo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
                CargarMesas();
                return;
            }

            
            MessageBox.Show("Esta mesa todavía no fue asignada desde recepción.",
                "Mesa no asignada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarMesas();
        }
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una mesa.");
                return;
            }

            long idMesa = Convert.ToInt64(dgvMesas.CurrentRow.Cells["colIdMesa"].Value);

            var mesa = _bllMesa.ListarTodo().FirstOrDefault(m => m.Id == idMesa);
            if (mesa == null)
            {
                MessageBox.Show("No se encontró la mesa.");
                return;
            }

            if (mesa.Estado == EstadoMesa.Bloqueada)
            {
                MessageBox.Show("La mesa está bloqueada por el encargado. No puede ser liberada desde salón.",
                    "Mesa bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var fm = new FormMotivoCancelacion())
            {
                if (fm.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    _bllComanda.LiberarMesaSinConsumo(idMesa, _mozo, fm.Motivo);
                    MessageBox.Show("La mesa fue liberada.");
                    CargarMesas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo liberar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}
