using BE;
using BLL_Negocio;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace RestaurarTF
{
    public partial class FormLogin : Form
    {

        BEUsuario oBEUsuario;
        BLLUsuario oBLLUsuario;
        Regex nwRegex;
        int intento;
        public FormLogin()
        {
            oBEUsuario = new BEUsuario();
            oBLLUsuario = new BLLUsuario();
            InitializeComponent();
            intento = 0;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private BEUsuario ValidarDatos()
        {
            try
            {
                if (txtUsuario.Text.Length > 0)
                {
                    nwRegex = new Regex("^[a-zA-Z0-9]*$");
                    if (nwRegex.IsMatch(txtUsuario.Text.Trim()))
                    {
                        if (txtPassword.Text.Length > 0)
                        {
                            oBEUsuario.Usuario = txtUsuario.Text.Trim();
                            oBEUsuario.Password = txtPassword.Text.Trim();
                            return oBEUsuario;
                        }
                        else { throw new Exception("Error: El Password no puede ser nulo!"); }
                    }
                    else { throw new Exception("Error: El nombre de usuario sólo acepta letras y números!"); }
                }
                else { throw new Exception("Error: El nombre de Usuario no puede ser nulo!"); }
            }
            catch (XmlException ex) { MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return null;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                oBEUsuario = ValidarDatos();
                if (oBEUsuario != null)
                {
                    var usuarioBD = oBLLUsuario.ListarObjeto(oBEUsuario);
                    if (usuarioBD == null)
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oBEUsuario = usuarioBD;

                    if (oBEUsuario.Activo == true)
                    {
                        if (oBEUsuario.Bloqueado == false)
                        {
                            string txtBoxPasswordEncriptado = oBLLUsuario.EncriptarPassword(txtPassword.Text.Trim());
                            if (oBEUsuario.Password == txtBoxPasswordEncriptado)
                            {
                                oBEUsuario.Password = txtPassword.Text.Trim();

                                if (oBLLUsuario.Login(oBEUsuario) == true)
                                {
                                    intento = 0;
                                    oBEUsuario = oBLLUsuario.ListarObjeto(oBEUsuario);
                                    
                                    FormMenu frm = new FormMenu(oBEUsuario);
                                    frm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    throw new Exception("Error: Usuario y/o Contraseña incorrecta, por favor intente nuevamente!");
                                }
                            }
                            else
                            {
                                intento++;
                                if (intento == 3)
                                {
                                    oBEUsuario.Activo = false;
                                    oBEUsuario.Password = txtPassword.Text.Trim();
                                    oBLLUsuario.Guardar(oBEUsuario);
                                    MessageBox.Show($"Usuario: {oBEUsuario.Usuario} se ha desactivado por intentos fallidos. Contacte al administrador.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    throw new Exception("Error: Usuario y/o Contraseña incorrecta, por favor intente nuevamente!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception($"Error: El Usuario {oBEUsuario.Usuario} se encuentra Bloqueado! Consulte al Administrador.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Error: El Usuario: {oBEUsuario.Usuario} no se encuentra activo! Consulte al Administrador.");
                    }
                }
            }
            catch (XmlException ex) { MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkMostrarPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkMostrarPass.Checked;

        }
        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkMostrarPass.Checked = false;
        }
    }
}
