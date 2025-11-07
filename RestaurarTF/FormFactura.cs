using System;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormFactura : Form
    {
        private readonly long _idComanda;
        private readonly BLLComanda _bllComanda;
        private readonly BLLFactura _bllFactura;
        private BEComanda _comandaActual;

        public FormFactura(long idComanda)
        {
            InitializeComponent();
            _idComanda = idComanda;
            _bllComanda = new BLLComanda();
            _bllFactura = new BLLFactura();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            try
            {
                _comandaActual = _bllComanda.ObtenerPorId(_idComanda);
                if (_comandaActual == null)
                {
                    MessageBox.Show("No se encontró la comanda.");
                    this.Close();
                    return;
                }

                lblComanda.Text = "Comanda: " + _comandaActual.Id + " - Mesa: " + _comandaActual.Id_Mesa;

                // importante: las columnas ya están en el designer
                dgvDetalle.AutoGenerateColumns = false;

                var detalleMostrar = _comandaActual.Detalles
                    .Select(d => new
                    {
                        d.Descripcion,
                        d.Cantidad,
                        d.PrecioUnitario,
                        Subtotal = d.Cantidad * d.PrecioUnitario
                    })
                    .ToList();

                dgvDetalle.DataSource = detalleMostrar;

                decimal total = detalleMostrar.Sum(x => x.Subtotal);
                lblTotal.Text = $"Total: ${total:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar factura: " + ex.Message);
            }
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = txtCliente.Text.Trim();
                string cuit = txtCuit.Text.Trim();

                // validaciones las hace la BLLFactura
                var factura = _bllFactura.GenerarFacturaDesdeComanda(_idComanda, cliente, cuit);
                long nro = _bllFactura.EmitirFactura(factura);

                MessageBox.Show("Factura emitida. Nro: " + nro);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
