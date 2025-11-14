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

            _comandaActual = _bllComanda.ObtenerAbiertaPorMesa(_idMesa);
            if (_comandaActual == null)
            {
                var nuevoId = _bllComanda.AbrirComanda(_idMesa, _mozo);
                _comandaActual = _bllComanda.ObtenerPorId(nuevoId);
            }

            CargarProductos();
            CargarDetalle();
        }
        private void btnSolicitarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (_comandaActual == null || _comandaActual.Id <= 0)
                {
                    MessageBox.Show("No hay una comanda abierta para esta mesa.");
                    return;
                }

                var ok = _bllComanda.SolicitarFactura(_comandaActual.Id);
                if (ok)
                    MessageBox.Show("Se solicitó la factura al cajero.");
                else
                    MessageBox.Show("No se pudo solicitar la factura.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
            
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
            _comandaActual = _bllComanda.ObtenerPorId(_comandaActual.Id);
            if (_comandaActual == null)
            {
                dgvDetalle.DataSource = null;
                lblTotal.Text = "Total: $0,00";
                return;
            }

            var pendientes = _comandaActual.Detalles
                .Where(d => !d.Preparado && !d.Anulado)
                .Select(d => new
                {
                    Linea = d.Linea, 
                    Producto = d.Descripcion,
                    Cant = d.Cantidad,
                    P_Unit = d.PrecioUnitario,
                    Subtotal = d.Cantidad * d.PrecioUnitario,
                    Estado = d.Enviado ? "Enviado" : "Agregado"
                });
            var listosAgrupados = _comandaActual.Detalles
                .Where(d => d.Preparado && !d.Anulado)
                .GroupBy(d => new { d.Descripcion, d.PrecioUnitario })
                .Select(g => new
                {
                    Linea = 0, 
                    Producto = g.Key.Descripcion,
                    Cant = g.Sum(x => x.Cantidad),
                    P_Unit = g.Key.PrecioUnitario,
                    Subtotal = g.Sum(x => x.Cantidad * x.PrecioUnitario),
                    Estado = "Listo"
                });

            var lista = pendientes
                .Concat(listosAgrupados)
                .OrderBy(x => x.Producto)
                .ThenBy(x => x.Estado)
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

                long idProd = Convert.ToInt64(dgvProductos.CurrentRow.Cells["colProdId"].Value);
                string nombre = dgvProductos.CurrentRow.Cells["colProdNombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["colProdPrecio"].Value);

                int cant = (int)nudCantidad.Value;

                _bllComanda.AgregarItem(_comandaActual.Id, idProd, nombre, cant, precio);

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
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un ítem.");
                return;
            }

            int linea = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["colDetLinea"].Value);

            if (linea == 0)
            {
                MessageBox.Show("Este ítem ya está listo. Debe anularlo el cajero.");
                return;
            }

            try
            {
                _bllComanda.QuitarDetalle(_comandaActual.Id, linea);
                CargarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_comandaActual == null)
                {
                    MessageBox.Show("No hay comanda.");
                    return;
                }

                _bllComanda.EnviarACocina(_comandaActual.Id);
                MessageBox.Show("Comanda enviada a cocina.");

                _comandaActual = _bllComanda.ObtenerPorId(_comandaActual.Id);
                CargarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
