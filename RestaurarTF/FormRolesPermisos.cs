using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BE.BEComposite;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormRolesPermisos : Form
    {
        private readonly MenuStrip _menu;

        private readonly BLLUsuario _bllUsuario;
        private readonly BLLRol _bllRol;
        private readonly BLLPermiso _bllPermiso;

        private BEUsuario _usuarioSeleccionado;
        private BERol _rolSeleccionado;
        private BEPermiso _permisoSeleccionado;
        private BEPermiso _permisoSeleccionadoEnRol;

        public FormRolesPermisos(MenuStrip menu)
        {
            InitializeComponent();

            _menu = menu;
            _bllUsuario = new BLLUsuario();
            _bllRol = new BLLRol();
            _bllPermiso = new BLLPermiso();
        }

        private void FormRolesPermisos_Load(object sender, EventArgs e)
        {

            SincronizarPermisosConMenu();


            CargarUsuarios();
            CargarRoles();
            CargarPermisos();
            LimpiarUsuario();
            LimpiarRol();
        }

 

        private void SincronizarPermisosConMenu()
        {
            var permisosExistentes = _bllPermiso.ListarTodo() ?? new List<BEPermiso>();
            RecorrerMenuYCrear(_menu.Items, permisosExistentes);
        }

        private void RecorrerMenuYCrear(ToolStripItemCollection items, List<BEPermiso> permisosExistentes)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    string nombre = menuItem.Text.Trim();

                    bool existe = permisosExistentes.Any(p =>
                        p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

                    if (!existe)
                    {
                        var nuevo = new BEPermiso(0, nombre);
                        _bllPermiso.Guardar(nuevo);
                        permisosExistentes.Add(nuevo);
                    }

                    if (menuItem.DropDownItems != null && menuItem.DropDownItems.Count > 0)
                    {
                        RecorrerMenuYCrear(menuItem.DropDownItems, permisosExistentes);
                    }
                }
            }
        }


        private void CargarUsuarios()
        {
            treeUsuarios.Nodes.Clear();
            var usuarios = _bllUsuario.ListarTodo() ?? new List<BEUsuario>();

            foreach (var u in usuarios)
            {
                TreeNode n = new TreeNode(u.Usuario);
                n.Tag = u;
                treeUsuarios.Nodes.Add(n);
            }
        }

        private void CargarRoles()
        {
            treeRoles.Nodes.Clear();
            var roles = _bllRol.ListarTodo() ?? new List<BERol>();

            foreach (var r in roles)
            {
                TreeNode n = new TreeNode(r.Nombre);
                n.Tag = r;
                treeRoles.Nodes.Add(n);
            }

            CargarPermisosPorRol();
        }

        private void CargarPermisos()
        {
            treePermisos.Nodes.Clear();

            foreach (ToolStripItem item in _menu.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {

                    TreeNode nodo = new TreeNode(menuItem.Text);
                    treePermisos.Nodes.Add(nodo);

                    CargarSubMenusEnTree(menuItem, nodo);
                }
            }

            treePermisos.ExpandAll();
        }
        private void CargarSubMenusEnTree(ToolStripMenuItem menuItem, TreeNode nodoPadre)
        {
            foreach (ToolStripItem sub in menuItem.DropDownItems)
            {
                if (sub is ToolStripMenuItem subMenu)
                {
                    TreeNode nodoHijo = new TreeNode(subMenu.Text);
                    nodoPadre.Nodes.Add(nodoHijo);

                    if (subMenu.DropDownItems.Count > 0)
                        CargarSubMenusEnTree(subMenu, nodoHijo);
                }
            }
        }
        private void CargarPermisosPorRol()
        {
            treePermisosPorRol.Nodes.Clear();

            if (_rolSeleccionado == null)
                return;

            var permisosDelRol = _bllRol.ListarPermisosDelRol(_rolSeleccionado) ?? new List<BEPermiso>();

            foreach (var p in permisosDelRol)
            {
                TreeNode n = new TreeNode(p.Nombre);
                n.Tag = p;
                treePermisosPorRol.Nodes.Add(n);
            }
        }

        private void CargarRolesYPermisosDelUsuario()
        {
            treeUsuarioRolesPermisos.Nodes.Clear();

            if (_usuarioSeleccionado == null)
                return;

            var usr = _bllUsuario.ListarObjetoJerarquico(_usuarioSeleccionado);
            if (usr == null) return;

            TreeNode nodoRoles = new TreeNode("Roles");
            var rolesUsuario = _bllUsuario.ListarRolesDelUsuario(usr) ?? new List<BERol>();
            foreach (var r in rolesUsuario)
            {
                TreeNode nr = new TreeNode(r.Nombre);
                nr.Tag = r;
                nodoRoles.Nodes.Add(nr);
            }

            TreeNode nodoPermisos = new TreeNode("Permisos directos");
            var permisosUsuario = _bllUsuario.ListarPermisosDirectosDelUsuario(usr) ?? new List<BEPermiso>();
            foreach (var p in permisosUsuario)
            {
                TreeNode np = new TreeNode(p.Nombre);
                np.Tag = p;
                nodoPermisos.Nodes.Add(np);
            }

            treeUsuarioRolesPermisos.Nodes.Add(nodoRoles);
            treeUsuarioRolesPermisos.Nodes.Add(nodoPermisos);
            treeUsuarioRolesPermisos.ExpandAll();
        }

        private void treeUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is BEUsuario u)
            {
                _usuarioSeleccionado = u;
                txtUsuarioId.Text = u.Id.ToString();
                txtUsuarioNombre.Text = u.Usuario;

                txtUsuarioPassword.UseSystemPasswordChar = true;
                txtUsuarioPassword.Text = u.Password ?? string.Empty;

                chkUsuarioActivo.Checked = u.Activo;
                chkUsuarioBloqueado.Checked = u.Bloqueado;

                bool esAdmin = _usuarioSeleccionado.Usuario.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase)
                  || _usuarioSeleccionado.Id == 1;

                btnRolUsuarioAsignar.Enabled = !esAdmin;
                btnRolUsuarioQuitar.Enabled = !esAdmin;
                btnPermisoUsuarioAsignar.Enabled = !esAdmin;
                btnPermisoUsuarioQuitar.Enabled = !esAdmin;
                CargarRolesYPermisosDelUsuario();
            }
        }

        private void treeRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is BERol r)
            {
                _rolSeleccionado = r;
                txtRolId.Text = r.Id.ToString();
                txtRolNombre.Text = r.Nombre;
                CargarPermisosPorRol();
            }
        }

        private void treePermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nombrePermiso = e.Node.Text.Trim();

            var todos = _bllPermiso.ListarTodo() ?? new List<BEPermiso>();
            var permiso = todos.FirstOrDefault(p =>
                p.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase));

            _permisoSeleccionado = permiso;  
        }

        private void treePermisosPorRol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is BEPermiso p)
            {
                _permisoSeleccionadoEnRol = p;
            }
        }

        private void treeUsuarioRolesPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

    

        private void btnRolAlta_Click(object sender, EventArgs e)
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
                LimpiarRol();
                CargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRolModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                _rolSeleccionado.Nombre = txtRolNombre.Text.Trim();
                _bllRol.Guardar(_rolSeleccionado);
                CargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRolEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                _bllRol.Eliminar(_rolSeleccionado);
                LimpiarRol();
                CargarRoles();
                CargarPermisosPorRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void btnRolUsuarioAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                _bllUsuario.AsociarUsuarioARol(_usuarioSeleccionado, _rolSeleccionado);
                CargarRolesYPermisosDelUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRolUsuarioQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }

                _bllUsuario.DesasociarUsuarioARol(_usuarioSeleccionado, _rolSeleccionado);
                CargarRolesYPermisosDelUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPermisoUsuarioAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }
                if (_permisoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un permiso en la lista de permisos.");
                    return;
                }

                _bllUsuario.AsociarPermisoAUsuario(_usuarioSeleccionado, _permisoSeleccionado);
                CargarRolesYPermisosDelUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPermisoUsuarioQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un usuario.");
                    return;
                }
                if (_permisoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un permiso.");
                    return;
                }

                _bllUsuario.DesasociarPermisoAUsuario(_usuarioSeleccionado, _permisoSeleccionado);
                CargarRolesYPermisosDelUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnPermisoRolAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }
                if (_permisoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un permiso de la lista general.");
                    return;
                }

                _bllRol.AsociarRolaPermiso(_rolSeleccionado, _permisoSeleccionado);
                CargarPermisosPorRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPermisoRolQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rolSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un rol.");
                    return;
                }
                if (_permisoSeleccionadoEnRol == null)
                {
                    MessageBox.Show("Seleccione un permiso dentro de 'Permisos por Rol'.");
                    return;
                }

                _bllRol.DesasociarRolaPermiso(_rolSeleccionado, _permisoSeleccionadoEnRol);
                CargarPermisosPorRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null) return;

            var passCifrada = _usuarioSeleccionado.Password;
            if (string.IsNullOrEmpty(passCifrada)) return;

            var passPlano = _bllUsuario.DesencriptarPassword(passCifrada);
            txtUsuarioPassword.UseSystemPasswordChar = false;
            txtUsuarioPassword.Text = passPlano;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarUsuario()
        {
            _usuarioSeleccionado = null;
            txtUsuarioId.Text = "";
            txtUsuarioNombre.Text = "";
            txtUsuarioPassword.Text = "";
            txtUsuarioPassword.UseSystemPasswordChar = true;
            chkUsuarioActivo.Checked = false;
            chkUsuarioBloqueado.Checked = false;
            treeUsuarioRolesPermisos.Nodes.Clear();
        }

        private void LimpiarRol()
        {
            _rolSeleccionado = null;
            txtRolId.Text = "";
            txtRolNombre.Text = "";
        }
    }
}
