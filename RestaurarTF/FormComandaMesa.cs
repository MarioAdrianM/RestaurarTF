using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormComandaMesa : Form
    {
        private readonly long _idMesa;
        private readonly string _mozo;

        private readonly BLLComanda _bllComanda;
        private readonly BLLProductoCarta _bllProductos;

        private BEComanda _comandaActual;

        public FormComandaMesa(long idMesa, string mozo)
        {
            InitializeComponent();
            _idMesa = idMesa;
            _mozo = mozo;

            _bllComanda = new BLLComanda();
            _bllProductos = new BLLProductoCarta();
        }

        private void FormComandaMesa_Load(object sender, EventArgs e)
        {
            lblMesa.Text = "Mesa: " + _idMesa;
            txtMozo.Text = _mozo;

            // 1) busco si ya hay comanda abierta de esta mesa
            _comandaActual = _bllComanda.ObtenerAbiertaPorMesa(_idMesa);
            if (_comandaActual == null)
            {
                // no hay, la abro
                var nuevoId = _bllComanda.AbrirComanda(_idMesa, _mozo);
                _comandaActual = _bllComanda.ObtenerPorId(nuevoId);
            }

            CargarProductos();
            CargarDetalle();
        }

        private void CargarProductos()
        {
            try
            {
                var lista = _bllProductos
                    .ListarTodo()
                    .Where(p => p.Activo)
                    .Select(p => new
                    {
                        p.Id,
                        Nombre = p.Nombre,
                        Categoria = p.Categoria,
                        Precio = p.Precio
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void CargarDetalle()
        {
            // mostramos el detalle actual de la comanda
            var lista = _comandaActual.Detalles
                .Select(d => new
                {
                    d.Descripcion,
                    d.Cantidad,
                    d.PrecioUnitario,
                    Subtotal = d.Cantidad * d.PrecioUnitario
                })
                .ToList();

            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.DataSource = lista;

            decimal total = lista.Sum(x => x.Subtotal);
            lblTotal.Text = $"Total: ${total:N2}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un producto.");
                    return;
                }

                if (nudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.");
                    return;
                }

                // datos del producto
                long idProd = Convert.ToInt64(dgvProductos.CurrentRow.Cells["colProdId"].Value);
                string nombre = dgvProductos.CurrentRow.Cells["colProdNombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["colProdPrecio"].Value);

                int cant = (int)nudCantidad.Value;

                // guardamos en la comanda (XML) usando la BLL
                _bllComanda.AgregarItem(_comandaActual.Id, idProd, nombre, cant, precio);

                // volvemos a traer la comanda para refrescar la lista
                _comandaActual = _bllComanda.ObtenerPorId(_comandaActual.Id);
                CargarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            // Nota: tu MPPComanda actual NO tiene "QuitarDetalle".
            // Para no tocar tu MPP, acá simplemente avisamos.
            MessageBox.Show("Quitar ítem todavía no está implementado en el XML. Si querés, después lo agregamos en MPPComanda.");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                _bllComanda.EnviarACocina(_comandaActual.Id);
                MessageBox.Show("Comanda enviada a cocina.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar: " + ex.Message);
            }
        }
    }
}
