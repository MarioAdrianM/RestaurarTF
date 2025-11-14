using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormProductosCarta : Form
    {
        private readonly BLLProductoCarta _bll;
        private readonly BLLCategoriaProducto _bllCat;
        private BEProductoCarta _actual;
        public FormProductosCarta()
        {
            InitializeComponent();
            _bll = new BLLProductoCarta();
            _bllCat = new BLLCategoriaProducto();
        }

        private void FormProductosCarta_Load(object sender, EventArgs e)
        {
            _bll.CrearXML();
            _bllCat.CrearXML();

            var categorias = _bllCat.ListarTodo().Where(c => c.Activo).ToList();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";

            CargarGrilla();
            ModoEdicion(false);
        }

        private void CargarGrilla()
        {
            List<BEProductoCarta> lista = _bll.ListarTodo();

            dgvProductos.AutoGenerateColumns = true; 
            dgvProductos.DataSource = lista
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    Categoria = p.Categoria != null ? p.Categoria.Nombre : "",
                    p.Descripcion,
                    p.Precio,
                    p.Activo
                })
                .ToList();

            this.Text = $"Productos de la carta ({lista.Count})";
        }


        private void ModoEdicion(bool edicion)
        {
            panelEdicion.Enabled = edicion;
            btnGuardar.Enabled = edicion;
            btnCancelar.Enabled = edicion;

            btnNuevo.Enabled = !edicion;
            btnEliminar.Enabled = !edicion;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _actual = null;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "0";
            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;

            chkActivo.Checked = true;
            ModoEdicion(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese un nombre.");
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out precio))
                {
                    if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
                    {
                        MessageBox.Show("Precio inválido.");
                        return;
                    }
                }

                var prod = _actual ?? new BEProductoCarta();
                prod.Nombre = txtNombre.Text.Trim();
                prod.Descripcion = txtDescripcion.Text.Trim();
                prod.Precio = precio;
                prod.Activo = chkActivo.Checked;

                var catSel = cboCategoria.SelectedItem as BECategoriaProducto;
                prod.Categoria = catSel;

                _bll.Guardar(prod);

                CargarGrilla();
                ModoEdicion(false);
                MessageBox.Show("Producto guardado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            long id = Convert.ToInt64(dgvProductos.CurrentRow.Cells["colId"].Value);
            var prod = _bll.ListarTodo().FirstOrDefault(p => p.Id == id);
            if (prod == null) return;

            _actual = prod;

            txtNombre.Text = prod.Nombre;
            txtDescripcion.Text = prod.Descripcion;
            txtPrecio.Text = prod.Precio.ToString("0.##");
            chkActivo.Checked = prod.Activo;

            if (prod.Categoria != null)
            {
                var listaCombo = (List<BECategoriaProducto>)cboCategoria.DataSource;
                var cat = listaCombo.FirstOrDefault(c => c.Id == prod.Categoria.Id);
                if (cat != null)
                {
                    cboCategoria.SelectedValue = cat.Id;
                }
            }

            ModoEdicion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            long id = Convert.ToInt64(dgvProductos.CurrentRow.Cells["colId"].Value);
            var prod = _bll.ListarTodo().FirstOrDefault(p => p.Id == id);
            if (prod == null) return;

            if (MessageBox.Show("¿Eliminar producto?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(prod);
                    _actual = null;
                    CargarGrilla();
                    ModoEdicion(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
