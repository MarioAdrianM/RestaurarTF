using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormCompras : Form
    {
        private readonly BLLCompra _bll;
        private BECompra _actual;
        private readonly BLLCategoriaProducto _bllCat;


        public FormCompras()
        {
            InitializeComponent();
            _bll = new BLLCompra();
            _bllCat = new BLLCategoriaProducto();

        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            _bll.CrearXML();
            _bllCat.CrearXML();

            var categorias = _bllCat.ListarTodo().Where(c => c.Activo).ToList();
            cboFamilia.DataSource = categorias;
            cboFamilia.DisplayMember = "Nombre";
            cboFamilia.ValueMember = "Id";

            dtpFecha.Value = DateTime.Today;

            CargarGrilla();
            ModoEdicion(false);
        }

        private void CargarGrilla()
        {
            var lista = _bll.ListarTodo();

            dgvCompras.AutoGenerateColumns = true;

            dgvCompras.DataSource = lista
                .Select(c => new
                {
                    c.Id,
                    c.Fecha,
                    c.Proveedor,
                    c.NumeroComprobante,
                    Categoria = c.Categoria != null ? c.Categoria.Nombre : "",
                    c.ImporteTotal,
                    c.Observaciones
                })
                .ToList();
        }


        private void ModoEdicion(bool editando)
        {
            txtProveedor.Enabled = editando;
            txtComprobante.Enabled = editando;
            dtpFecha.Enabled = editando;
            cboFamilia.Enabled = editando;
            nudImporte.Enabled = editando;
            txtObs.Enabled = editando;

            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;

            btnNuevo.Enabled = !editando;
            btnEliminar.Enabled = !editando;
        }

        private void Limpiar()
        {
            _actual = null;
            txtProveedor.Text = "";
            txtComprobante.Text = "";
            dtpFecha.Value = DateTime.Today;
            cboFamilia.SelectedIndex = 0;
            nudImporte.Value = 0;
            txtObs.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            ModoEdicion(true);
            txtProveedor.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_actual == null)
                    _actual = new BECompra();

                _actual.Proveedor = txtProveedor.Text.Trim();
                _actual.NumeroComprobante = txtComprobante.Text.Trim();
                _actual.Fecha = dtpFecha.Value;
                _actual.Categoria = cboFamilia.SelectedItem as BECategoriaProducto;

                _actual.ImporteTotal = nudImporte.Value;
                _actual.Observaciones = txtObs.Text.Trim();

                _bll.Guardar(_actual);

                MessageBox.Show("Compra registrada correctamente.");
                CargarGrilla();
                ModoEdicion(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ModoEdicion(false);
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null) return;

            var id = Convert.ToInt64(dgvCompras.CurrentRow.Cells["colId"].Value);
            var compra = _bll.ListarTodo().FirstOrDefault(c => c.Id == id);
            if (compra == null) return;

            _actual = compra;
            txtProveedor.Text = compra.Proveedor;
            txtComprobante.Text = compra.NumeroComprobante;
            dtpFecha.Value = compra.Fecha;
            if (compra.Categoria != null)
            {
                var listaCombo = (System.Collections.Generic.List<BECategoriaProducto>)cboFamilia.DataSource;
                var cat = listaCombo.FirstOrDefault(c => c.Id == compra.Categoria.Id);
                if (cat != null)
                    cboFamilia.SelectedValue = cat.Id;
            }
            else if (cboFamilia.Items.Count > 0)
            {
                cboFamilia.SelectedIndex = 0;
            }

            nudImporte.Value = compra.ImporteTotal;
            txtObs.Text = compra.Observaciones;

            ModoEdicion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;
            if (MessageBox.Show("¿Eliminar la compra seleccionada?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bll.Eliminar(_actual);
                CargarGrilla();
                Limpiar();
                ModoEdicion(false);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
