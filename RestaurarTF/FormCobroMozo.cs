using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormCobroMozo : Form
    {
        private readonly BLLCobroMozo _bll;
        private readonly BLLFactura _bllFactura;

        public FormCobroMozo()
        {
            InitializeComponent();
            _bll = new BLLCobroMozo();
            _bllFactura = new BLLFactura();
        }

        private void FormCobroMozo_Load(object sender, EventArgs e)
        {
            cmbMedio.Items.Clear();
            cmbMedio.Items.Add("Efectivo");
            cmbMedio.Items.Add("Tarjeta");
            cmbMedio.Items.Add("QR");
            cmbMedio.SelectedIndex = 0;

            CargarPendientes();
        }

        private void CargarPendientes()
        {
            try
            {
                var lista = _bll.ListarNoRendidos();
                dgvPendientes.AutoGenerateColumns = true;
                dgvPendientes.DataSource = lista
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txtComanda.Text, out long idComanda))
                {
                    MessageBox.Show("Ingrese un N° de comanda válido.");
                    return;
                }

                // 👇 validamos si hay factura
                var factura = _bllFactura.ObtenerUltimaPorComanda(idComanda);
                if (factura == null)
                {
                    var r = MessageBox.Show("La comanda no tiene factura. ¿Registrar igual el cobro?",
                                            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                        return;
                }

                if (!decimal.TryParse(txtImporte.Text, out decimal importe))
                {
                    MessageBox.Show("Ingrese un importe válido.");
                    return;
                }

                string mozo = txtMozo.Text.Trim();
                string medio = cmbMedio.SelectedItem?.ToString() ?? "Efectivo";

                _bll.RegistrarCobro(idComanda, mozo, medio, importe);

                MessageBox.Show("Cobro registrado. Queda pendiente de rendición.");
                txtImporte.Clear();
                CargarPendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // nuevo: buscar la factura de esa comanda y cargar el total
        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txtComanda.Text, out long idComanda))
                {
                    MessageBox.Show("Ingrese un N° de comanda válido.");
                    return;
                }

                var factura = _bllFactura.ObtenerUltimaPorComanda(idComanda);
                if (factura == null)
                {
                    MessageBox.Show("No hay factura para esa comanda. Puede cargar el importe manualmente.");
                    return;
                }

                txtImporte.Text = factura.Total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar factura: " + ex.Message);
            }
        }
    }
}
