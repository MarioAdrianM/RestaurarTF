using System;
using System.Windows.Forms;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormAuditoriaOperaciones : Form
    {
        private readonly BLLComanda _bllComanda;

        public FormAuditoriaOperaciones()
        {
            InitializeComponent();
            _bllComanda = new BLLComanda();
        }

        private void FormAuditoriaOperaciones_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            dgvAnulaciones.AutoGenerateColumns = true;
            dgvCancelaciones.AutoGenerateColumns = true;

            dgvAnulaciones.ReadOnly = true;
            dgvCancelaciones.ReadOnly = true;

            dgvAnulaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCancelaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvAnulaciones.MultiSelect = false;
            dgvCancelaciones.MultiSelect = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'hasta' no puede ser menor que la fecha 'desde'.");
                return;
            }
            var anulaciones = _bllComanda.ListarAnulaciones(desde, hasta);
            dgvAnulaciones.DataSource = null;
            dgvAnulaciones.DataSource = anulaciones;
            var cancelaciones = _bllComanda.ListarCancelaciones(desde, hasta);
            dgvCancelaciones.DataSource = null;
            dgvCancelaciones.DataSource = cancelaciones;
        }
    }
}
