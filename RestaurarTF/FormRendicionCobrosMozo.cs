using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormRendicionCobrosMozo : Form
    {
        private readonly BLLCobroMozo _bllCobro;
        private readonly BLLCaja _bllCaja;

        public FormRendicionCobrosMozo()
        {
            InitializeComponent();
            _bllCobro = new BLLCobroMozo();
            _bllCaja = new BLLCaja();
        }

        private void FormRendicionCobrosMozo_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                List<BECobroMozo> lista = _bllCobro.ListarNoRendidos();
                dgvCobros.AutoGenerateColumns = false;
                dgvCobros.DataSource = lista;
                CalcularTotal(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cobros: " + ex.Message);
            }
        }

        private void CalcularTotal(List<BECobroMozo> lista)
        {
            decimal total = 0;
            if (lista != null && lista.Any())
                total = lista.Sum(x => x.Importe);

            lblTotal.Text = $"Total pendiente: ${total:N2}";
        }

        private void btnRendirSeleccionados_Click(object sender, EventArgs e)
        {
            try
            {
                int rendidos = 0;

                foreach (DataGridViewRow row in dgvCobros.Rows)
                {
                    bool seleccionado = false;

                    if (row.Cells["colSeleccionar"] is DataGridViewCheckBoxCell chk &&
                        chk.Value != null &&
                        chk.Value is bool &&
                        (bool)chk.Value)
                    {
                        seleccionado = true;
                    }

                    if (seleccionado)
                    {
                        long idCobro = Convert.ToInt64(row.Cells["colId"].Value);

                        _bllCaja.RendirCobro(idCobro);

                        rendidos++;
                    }
                }

                if (rendidos == 0)
                {
                    MessageBox.Show("No hay cobros seleccionados.");
                    return;
                }

                MessageBox.Show($"Se rindieron {rendidos} cobros.");
                CargarGrilla(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rendir: " + ex.Message);
            }
        }
    }
}
