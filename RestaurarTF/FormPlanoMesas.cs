using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormPlanoMesas : Form
    {
        private readonly BLLMesa _bllMesa;
        private readonly BLLComanda _bllComanda;
        private readonly BLLReserva _bllReserva;

        private BEMesa _mesaActual;

        private class MesaVista
        {
            public long Id { get; set; }
            public string Codigo { get; set; }
            public int Numero { get; set; }
            public string Sector { get; set; }
            public int Capacidad { get; set; }
            public string Observaciones { get; set; }
            public string Estado { get; set; }
        }

        public FormPlanoMesas()
        {
            InitializeComponent();
            _bllMesa = new BLLMesa();
            _bllComanda = new BLLComanda();
            _bllReserva = new BLLReserva();
        }

        private void FormPlanoMesas_Load(object sender, EventArgs e)
        {
            txtNumero.ReadOnly = true;
            txtCodigo.ReadOnly = true;

            CargarGrilla();
            ModoEdicion(false);
        }

        private void CargarGrilla()
        {
            var mesas = _bllMesa.ListarTodo() ?? new List<BEMesa>();

            var vista = mesas.Select(m =>
            {
                string estadoTexto;

                if (m.Estado == EstadoMesa.Bloqueada)
                {
                    estadoTexto = "Bloqueada";
                }
                else if (m.Estado == EstadoMesa.Ocupada)
                {
                    estadoTexto = "Ocupada";
                }
                else if (_bllReserva.TieneReservaVigente(m.Id))
                {
                    estadoTexto = "Reservada";
                }
                else
                {
                    var com = _bllComanda.ObtenerAbiertaPorMesa(m.Id);
                    if (com != null)
                    {
                        if (com.Estado == BEComanda.Estados.ParaFacturar)
                            estadoTexto = "Para facturar";
                        else
                            estadoTexto = "Ocupada";
                    }
                    else
                    {
                        estadoTexto = "Libre";
                    }
                }

                return new MesaVista
                {
                    Id = m.Id,
                    Codigo = m.Codigo,
                    Numero = m.Numero,
                    Sector = m.Sector,
                    Capacidad = m.Capacidad,
                    Observaciones = m.Observaciones,
                    Estado = estadoTexto
                };
            }).OrderBy(v => v.Numero).ToList();

            dgvMesas.AutoGenerateColumns = true;
            dgvMesas.DataSource = null;
            dgvMesas.DataSource = vista;

            if (dgvMesas.Columns["Id"] != null)
                dgvMesas.Columns["Id"].Visible = false;
        }

        private void ModoEdicion(bool edicion)
        {
            panelEdicion.Enabled = edicion;
            btnGuardar.Enabled = edicion;
            btnCancelar.Enabled = edicion;
            btnNuevo.Enabled = !edicion;
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

            txtCodigo.ReadOnly = true;
            txtNumero.ReadOnly = true;

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

                if (_mesaActual == null)
                {
                    mesa.Estado = EstadoMesa.Libre;
                }
                else
                {
                    mesa.Estado = _mesaActual.Estado;
                }

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
            var idObj = dgvMesas.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            long idMesa = Convert.ToInt64(idObj);

            var mesa = _bllMesa.ListarTodo()?.FirstOrDefault(m => m.Id == idMesa);
            if (mesa == null) return;

            _mesaActual = mesa;

            txtCodigo.Text = mesa.Codigo;
            txtNumero.Text = mesa.Numero.ToString();
            txtSector.Text = mesa.Sector;
            txtCapacidad.Text = mesa.Capacidad.ToString();
            txtObservaciones.Text = mesa.Observaciones;

            txtCodigo.ReadOnly = true;
            txtNumero.ReadOnly = true;

            ModoEdicion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_mesaActual == null) return;

            try
            {
                if (_mesaActual.Estado == EstadoMesa.Bloqueada)
                {
                    if (MessageBox.Show("¿Desbloquear mesa?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _bllMesa.DesbloquearMesa(_mesaActual.Id);
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Bloquear mesa?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _bllMesa.BloquearMesa(_mesaActual.Id);
                    }
                }

                _mesaActual = null;
                CargarGrilla();
                ModoEdicion(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMesas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null) return;

            var idObj = dgvMesas.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            long idMesa = Convert.ToInt64(idObj);

            var com = _bllComanda.ObtenerAbiertaPorMesa(idMesa);
            if (com != null)
            {
                var frmComanda = new FormComandaMesa(idMesa, com.Mozo);
                frmComanda.MdiParent = this.MdiParent;
                frmComanda.Show();
            }
        }
    }
}
