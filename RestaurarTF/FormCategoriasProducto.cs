using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormCategoriasProducto : Form
    {
        private readonly BLLCategoriaProducto _bll;
        private BECategoriaProducto _actual;

        public FormCategoriasProducto()
        {
            InitializeComponent();
            _bll = new BLLCategoriaProducto();
        }

        private void FormCategoriasProducto_Load(object sender, EventArgs e)
        {
            _bll.CrearXML();
            CargarGrilla();
            HabilitarEdicion(false);
        }

        private void CargarGrilla()
        {
            var lista = _bll.ListarTodo() ?? new System.Collections.Generic.List<BECategoriaProducto>();
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = lista;
            if (dgvCategorias.Rows.Count > 0)
                dgvCategorias.ClearSelection();
        }

        private void HabilitarEdicion(bool si)
        {
            txtNombre.Enabled = si;
            txtDescripcion.Enabled = si;
            chkActivo.Enabled = si;
            btnGuardar.Enabled = si;
            btnCancelar.Enabled = si;

            btnNuevo.Enabled = !si;
            btnEliminar.Enabled = !si;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkActivo.Checked = true;
            _actual = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarEdicion(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return;
            }

            if (_actual == null)
                _actual = new BECategoriaProducto();

            _actual.Nombre = txtNombre.Text.Trim();
            _actual.Descripcion = txtDescripcion.Text.Trim();
            _actual.Activo = chkActivo.Checked;

            _bll.Guardar(_actual);

            MessageBox.Show("Categoría guardada.");

            Limpiar();
            HabilitarEdicion(false);
            CargarGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarEdicion(false);
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            var cat = dgvCategorias.CurrentRow.DataBoundItem as BECategoriaProducto;
            if (cat == null) return;

            _actual = cat;
            txtNombre.Text = cat.Nombre;
            txtDescripcion.Text = cat.Descripcion;
            chkActivo.Checked = cat.Activo;

            HabilitarEdicion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            var cat = dgvCategorias.CurrentRow.DataBoundItem as BECategoriaProducto;
            if (cat == null) return;

            if (MessageBox.Show("¿Eliminar categoría?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _bll.Eliminar(cat);
                Limpiar();
                HabilitarEdicion(false);
                CargarGrilla();
            }
        }
    }
}
