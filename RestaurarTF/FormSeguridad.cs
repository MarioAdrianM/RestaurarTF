using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BE.BEComposite;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormSeguridad : Form
    {
        private readonly BLLUsuario _bllUsuario;
        private readonly BLLRol _bllRol;
        private readonly BLLPermiso _bllPermiso;

        private BEUsuario _usuarioSeleccionado;
        private BERol _rolSeleccionado;

        public FormSeguridad()
        {
            InitializeComponent();
            _bllUsuario = new BLLUsuario();
            _bllRol = new BLLRol();
            _bllPermiso = new BLLPermiso();
        }

        private void FormSeguridad_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarRoles();
            CargarPermisos();
        }

        private void CargarUsuarios()
        {
            var usuarios = _bllUsuario.ListarTodo();
            lstUsuarios.DataSource = usuarios;
            lstUsuarios.DisplayMember = "Usuario";
            lstUsuarios.ValueMember = "Id";
            lstUsuarios.ClearSelected();
        }

        private void CargarRoles()
        {
            var roles = _bllRol.ListarTodo();
            lstRoles.DataSource = roles;
            lstRoles.DisplayMember = "Nombre";
            lstRoles.ValueMember = "Id";
            lstRoles.ClearSelected();
        }

        private void CargarPermisos()
        {
            var permisos = _bllPermiso.ListarTodo();
            lstPermisos.DataSource = permisos;
            lstPermisos.DisplayMember = "Nombre";
            lstPermisos.ValueMember = "Id";
            lstPermisos.ClearSelected();
        }

        // =========================
        //  USUARIO SELECCIONADO
        // =========================
        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem is BEUsuario u)
            {
                _usuarioSeleccionado = u = _bllUsuario.ListarObjetoPorId(u);

                txtUsuario.Text = u.Usuario;
                chkActivo.Checked = u.Activo;
                chkBloqueado.Checked = u.Bloqueado;

                // no desencripto todavía, lo hace el botón
                txtPassword.Text = u.Password;

                CargarRolesDelUsuario(u);
                CargarPermisosDelUsuario(u);
            }
        }

        private void CargarRolesDelUsuario(BEUsuario u)
        {
            var rolesUsuario = _bllUsuario.ListarRolesDelUsuario(u);
            lstRolesUsuario.DataSource = rolesUsuario;
            lstRolesUsuario.DisplayMember = "Nombre";
            lstRolesUsuario.ValueMember = "Id";
            lstRolesUsuario.ClearSelected();
        }

        private void CargarPermisosDelUsuario(BEUsuario u)
        {
            // solo directos
            var permisosUsuario = _bllUsuario.ListarPermisosDirectosDelUsuario(u);
            lstPermisosUsuario.DataSource = permisosUsuario;
            lstPermisosUsuario.DisplayMember = "Nombre";
            lstPermisosUsuario.ValueMember = "Id";
            lstPermisosUsuario.ClearSelected();
        }

        // =========================
        //  DESENCRIPTAR PASS
        // =========================
        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null) return;

            var passCifrada = _usuarioSeleccionado.Password;
            var passPlano = _bllUsuario.DesencriptarPassword(passCifrada);
            txtPassword.Text = passPlano;
        }

        // =========================
        //  ROLES
        // =========================
        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem is BERol r)
            {
                _rolSeleccionado = r = _bllRol.ListarObjeto(r);
                txtRolId.Text = r.Id.ToString();
                txtRolNombre.Text = r.Nombre;
                CargarPermisosDelRol(r);
            }
        }

        private void CargarPermisosDelRol(BERol r)
        {
            var permisos = _bllRol.ListarPermisosDelRol(r);
            lstPermisosDelRol.DataSource = permisos;
            lstPermisosDelRol.DisplayMember = "Nombre";
            lstPermisosDelRol.ValueMember = "Id";
            lstPermisosDelRol.ClearSelected();
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRolNombre.Text))
                {
                    MessageBox.Show("Ingrese un nombre de rol.");
                    return;
                }

                var nuevo = new BERol(0, txtRolNombre.Text.Trim());
                _bllRol.Guardar(nuevo);
                CargarRoles();
                MessageBox.Show("Rol creado.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                if (_rolSeleccionado.Nombre.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se puede eliminar el rol admin.");
                    return;
                }

                _bllRol.Eliminar(_rolSeleccionado);
                txtRolId.Clear();
                txtRolNombre.Clear();
                lstPermisosDelRol.DataSource = null;
                CargarRoles();
                MessageBox.Show("Rol eliminado.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAgregarPermisoARol_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                if (_rolSeleccionado.Nombre.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los permisos del rol admin.");
                    return;
                }

                if (lstPermisos.SelectedItem is BEPermiso p)
                {
                    _bllRol.AsociarRolaPermiso(_rolSeleccionado, p);
                    CargarPermisosDelRol(_rolSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso de la lista.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnQuitarPermisoARol_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                if (_rolSeleccionado.Nombre.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los permisos del rol admin.");
                    return;
                }

                if (lstPermisosDelRol.SelectedItem is BEPermiso p)
                {
                    _bllRol.DesasociarRolaPermiso(_rolSeleccionado, p);
                    CargarPermisosDelRol(_rolSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso del rol.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // =========================
        //  ROLES EN USUARIO
        // =========================
        private void btnAgregarRolAUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }

                // no tocar admin
                if (_usuarioSeleccionado.Usuario.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los roles del usuario admin.");
                    return;
                }

                if (lstRoles.SelectedItem is BERol r)
                {
                    _bllUsuario.AsociarUsuarioARol(_usuarioSeleccionado, r);
                    CargarRolesDelUsuario(_usuarioSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un rol de la lista de roles.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnQuitarRolAUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }

                if (_usuarioSeleccionado.Usuario.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los roles del usuario admin.");
                    return;
                }

                if (lstRolesUsuario.SelectedItem is BERol r)
                {
                    _bllUsuario.DesasociarUsuarioARol(_usuarioSeleccionado, r);
                    CargarRolesDelUsuario(_usuarioSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un rol del usuario.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // =========================
        //  PERMISOS DIRECTOS EN USUARIO
        // =========================
        private void btnAgregarPermisoAUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }

                if (_usuarioSeleccionado.Usuario.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los permisos del usuario admin.");
                    return;
                }

                if (lstPermisos.SelectedItem is BEPermiso p)
                {
                    _bllUsuario.AsociarPermisoAUsuario(_usuarioSeleccionado, p);
                    CargarPermisosDelUsuario(_usuarioSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnQuitarPermisoAUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }

                if (_usuarioSeleccionado.Usuario.Trim().ToLower() == "admin")
                {
                    MessageBox.Show("No se pueden modificar los permisos del usuario admin.");
                    return;
                }

                if (lstPermisosUsuario.SelectedItem is BEPermiso p)
                {
                    _bllUsuario.DesasociarPermisoAUsuario(_usuarioSeleccionado, p);
                    CargarPermisosDelUsuario(_usuarioSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso del usuario.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
