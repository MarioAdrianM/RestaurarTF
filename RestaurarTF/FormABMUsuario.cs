using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormABMUsuario : Form
    {
        private readonly BLLUsuario _bll;
        private BEUsuario _actual;   // <- acá guardamos el seleccionado

        public FormABMUsuario()
        {
            InitializeComponent();
            _bll = new BLLUsuario();
        }

        private void FormABMUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            var lista = _bll.ListarTodo();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = lista;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _actual = (BEUsuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;

            txtUsuario.Text = _actual.Usuario;
            txtPassword.Text = _bll.DesencriptarPassword(_actual.Password);
            chkActivo.Checked = _actual.Activo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_actual == null)
                    _actual = new BEUsuario();

                _actual.Usuario = txtUsuario.Text.Trim();
                _actual.Password = txtPassword.Text.Trim();
                _actual.Activo = chkActivo.Checked;
                _actual.Bloqueado = false;

                _bll.Guardar(_actual);
                MessageBox.Show("Usuario guardado/actualizado.");
                _actual = null;
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
