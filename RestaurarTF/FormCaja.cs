using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormCaja : Form
    {
        private readonly BLLCaja _bll;

        public FormCaja()
        {
            InitializeComponent();
            _bll = new BLLCaja();
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            RefrescarEstado();
            CargarCobrosPendientes();
            CargarMovimientos();
        }

        private void RefrescarEstado()
        {
            try
            {
                var caja = _bll.ObtenerCajaHoy();
                if (caja == null)
                {
                    lblEstado.Text = "Caja de hoy: NO ABIERTA";
                    btnAbrir.Enabled = true;
                    btnCerrar.Enabled = false;
                }
                else
                {
                    lblEstado.Text = $"Caja de hoy: {caja.Estado} - Apertura: {caja.Apertura}";
                    btnAbrir.Enabled = false;
                    btnCerrar.Enabled = (caja.Estado == "Abierta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCobrosPendientes()
        {
            try
            {
                var lista = _bll.ListarCobrosPendientesDeRendicion();
                dgvCobros.DataSource = lista
                    .Select(c => new
                    {
                        c.Id,
                        c.Id_Comanda,
                        c.FechaHora,
                        c.Mozo,
                        c.Medio,
                        c.Importe
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarMovimientos()
        {
            try
            {
                var movs = _bll.ListarMovimientosCajaHoy();
                dgvMovimientos.DataSource = movs
                    .Select(m => new
                    {
                        m.FechaHora,
                        m.Tipo,
                        m.Concepto,
                        m.Importe
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monto = 0;
                decimal.TryParse(txtMontoInicial.Text, out monto);
                _bll.AbrirCaja(monto);
                RefrescarEstado();
                CargarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCobros.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un cobro.");
                    return;
                }
                long idCobro = Convert.ToInt64(dgvCobros.CurrentRow.Cells["Id"].Value);
                _bll.RendirCobro(idCobro);
                CargarCobrosPendientes();
                CargarMovimientos(); // 👈 ahora ves el ingreso
                MessageBox.Show("Cobro rendido a caja.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                _bll.CerrarCaja();
                RefrescarEstado();
                CargarMovimientos();
                MessageBox.Show("Caja cerrada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
