using System;
using System.Windows.Forms;
using BE;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormCambiarPassword : Form
    {
        private readonly BEUsuario _usuario;
        private readonly BLLUsuario _bll;

        public FormCambiarPassword(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            _usuario = usuarioLogueado;
            _bll = new BLLUsuario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNueva.Text.Trim() != txtRepetir.Text.Trim())
                {
                    MessageBox.Show("La nueva contraseña no coincide.");
                    return;
                }

                _bll.CambiarPassword(_usuario, txtActual.Text.Trim(), txtNueva.Text.Trim());
                MessageBox.Show("Contraseña cambiada correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
