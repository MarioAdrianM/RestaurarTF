using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormPlanoMesas : Form
    {
        private readonly BLLMesa _bllMesa;
        private BEMesa _mesaActual;

        public FormPlanoMesas()
        {
            InitializeComponent();
            _bllMesa = new BLLMesa();
        }

        private void FormPlanoMesas_Load(object sender, EventArgs e)
        {
            cboEstado.DataSource = Enum.GetValues(typeof(EstadoMesa));
            CargarGrilla();
            ModoEdicion(false);
        }

        private void CargarGrilla()
        {
            dgvMesas.AutoGenerateColumns = true;
            dgvMesas.DataSource = null;
            dgvMesas.DataSource = _bllMesa.ListarTodo();

            if (dgvMesas.Columns["Id"] != null)
                dgvMesas.Columns["Id"].Visible = false;
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
            _mesaActual = null;
            long ultimoId = _bllMesa.ObtenerUltimoId();
            long nuevoId = ultimoId + 1;

            txtCodigo.Text = $"M{nuevoId:00}";
            txtNumero.Text = nuevoId.ToString();
            txtSector.Text = "";
            txtCapacidad.Text = "4";
            txtObservaciones.Text = "";
            cboEstado.SelectedItem = EstadoMesa.Libre;
            txtCodigo.ReadOnly = true;

            ModoEdicion(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNumero.Text, out int numero))
                {
                    MessageBox.Show("Número inválido.");
                    return;
                }

                if (!int.TryParse(txtCapacidad.Text, out int capacidad))
                {
                    MessageBox.Show("Capacidad inválida.");
                    return;
                }

                var mesa = _mesaActual ?? new BEMesa();
                mesa.Codigo = txtCodigo.Text.Trim();
                mesa.Numero = numero;
                mesa.Sector = txtSector.Text.Trim();
                mesa.Capacidad = capacidad;
                mesa.Observaciones = txtObservaciones.Text.Trim();
                mesa.Estado = (EstadoMesa)cboEstado.SelectedItem;

                _bllMesa.Guardar(mesa);

                ModoEdicion(false);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar mesa: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicion(false);
        }

        private void dgvMesas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null) return;
            var mesa = dgvMesas.CurrentRow.DataBoundItem as BEMesa;
            if (mesa == null) return;

            _mesaActual = mesa;
            txtCodigo.Text = mesa.Codigo;
            txtNumero.Text = mesa.Numero.ToString();
            txtSector.Text = mesa.Sector;
            txtCapacidad.Text = mesa.Capacidad.ToString();
            txtObservaciones.Text = mesa.Observaciones;
            cboEstado.SelectedItem = mesa.Estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_mesaActual == null) return;
            if (MessageBox.Show("¿Eliminar mesa?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bllMesa.Eliminar(_mesaActual);
                _mesaActual = null;
                CargarGrilla();
            }
        }

        private void dgvMesas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null) return;
            var mesa = dgvMesas.CurrentRow.DataBoundItem as BEMesa;
            if (mesa == null) return;

            if (mesa.Estado == EstadoMesa.Ocupada)
            {
                var frmComanda = new FormComandaMesa(mesa.Id, "mozo");
                frmComanda.MdiParent = this.MdiParent;
                frmComanda.Show();
            }
        }
    }
}
