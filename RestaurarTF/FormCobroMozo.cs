using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormCobroMozo : Form
    {
        private readonly string _mozoActual;
        private readonly BLLComanda _bllComanda;
        private readonly BLLFactura _bllFactura;
        private readonly BLLCobroMozo _bllCobro;

        public FormCobroMozo(string mozoActual)
        {
            InitializeComponent();
            _mozoActual = mozoActual;
            _bllComanda = new BLLComanda();
            _bllFactura = new BLLFactura();
            _bllCobro = new BLLCobroMozo();
        }

        public FormCobroMozo() : this("")
        {
        }

        private void FormCobroMozo_Load(object sender, EventArgs e)
        {
            if (cmbMedio.Items.Count == 0)
            {
                cmbMedio.Items.Add("Efectivo");
                cmbMedio.Items.Add("Tarjeta");
                cmbMedio.Items.Add("QR");
                cmbMedio.SelectedIndex = 0;
            }

            if (!string.IsNullOrWhiteSpace(_mozoActual))
                lblMozo.Text = "Mozo: " + _mozoActual;
            else
                lblMozo.Text = "Mozo: (no indicado)";

            CargarComandasFacturadasDelMozo();
        }

        private void CargarComandasFacturadasDelMozo()
        {
            try
            {
                var lista = _bllCobro.ListarFacturadasPendientesDeCobro(_mozoActual);

                dgvPendientes.AutoGenerateColumns = false;
                dgvPendientes.DataSource = lista
                    .Select(x => new
                    {
                        Id_Comanda = x.IdComanda,
                        Mesa = x.Mesa,
                        Fecha = x.Fecha,
                        Total = x.Total
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar comandas facturadas: " + ex.Message);
            }
        }
        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPendientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una comanda.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_mozoActual))
                {
                    MessageBox.Show("No se conoce el mozo logueado. Abra este formulario desde el menú después de loguearse.");
                    return;
                }
                long idComanda = Convert.ToInt64(dgvPendientes.CurrentRow.Cells["colIdComanda"].Value);

                string medio = cmbMedio.SelectedItem?.ToString() ?? "Efectivo";

                _bllCobro.RegistrarCobro(_mozoActual, idComanda, medio);

                MessageBox.Show("Cobro registrado. Queda pendiente de rendición.");
                CargarComandasFacturadasDelMozo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cobro: " + ex.Message);
            }
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarComandasFacturadasDelMozo();
        }
    }
}
