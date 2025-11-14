using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BE.BEComposite;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormMenu : Form
    {
        BEUsuario _usuario;
        BLLUsuario _bllUsuario;
        List<BEPermiso> _permisos;
        private BLLPermiso _bllPermiso;


        public FormMenu(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            _usuario = usuarioLogueado;
            _bllUsuario = new BLLUsuario();
            _permisos = _bllUsuario.ListarTodosLosPermisosDelUsuario(_usuario);
            _bllPermiso = new BLLPermiso();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            SincronizarPermisosConMenu();
            _permisos = _bllUsuario.ListarTodosLosPermisosDelUsuario(_usuario);
            OcultarTodosLosItemsDelMenu();
            if (_permisos != null && _permisos.Count > 0)
                MostrarItemsSegunPermisos(_permisos);
        }

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormPlanoMesas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormProductosCarta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormReservas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormComandas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OcultarTodosLosItemsDelMenu()
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Text.Equals("Sistema", StringComparison.OrdinalIgnoreCase))
                    {
                        menuItem.Visible = true;

                        foreach (ToolStripItem sub in menuItem.DropDownItems)
                        {
                            if (sub is ToolStripMenuItem subMenuItem)
                                subMenuItem.Visible = true;
                        }
                    }
                    else
                    {
                        menuItem.Visible = false;
                        if (menuItem.DropDownItems.Count > 0)
                            OcultarItemsDelSubMenu(menuItem.DropDownItems);
                    }
                }
            }
        }



        private void OcultarItemsDelSubMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem subItem)
                {
                    subItem.Visible = false;
                }
            }
        }

        private void MostrarItemsSegunPermisos(List<BEPermiso> permisosUsuario)
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Text.Equals("Sistema", StringComparison.OrdinalIgnoreCase))
                    {
                        menuItem.Visible = true;
                        foreach (ToolStripItem sub in menuItem.DropDownItems)
                        {
                            if (sub is ToolStripMenuItem subMenuItem)
                                subMenuItem.Visible = true;
                        }
                    }
                    else
                    {
                        if (menuItem.DropDownItems.Count > 0)
                            MostrarSubItemsSegunPermisos(menuItem, permisosUsuario);

                        if (TienePermiso(menuItem.Text, permisosUsuario))
                            menuItem.Visible = true;
                    }
                }
            }
        }



        private void MostrarSubItemsSegunPermisos(ToolStripMenuItem menuItem, List<BEPermiso> permisosUsuario)
        {
            bool algunSubItemVisible = false;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    if (subMenuItem.DropDownItems.Count > 0)
                        MostrarSubItemsSegunPermisos(subMenuItem, permisosUsuario);

                    if (TienePermiso(subMenuItem.Text, permisosUsuario))
                    {
                        subMenuItem.Visible = true;
                        algunSubItemVisible = true;
                    }
                }
            }

            if (algunSubItemVisible)
                menuItem.Visible = true;
        }

        private bool TienePermiso(string nombreItem, List<BEPermiso> permisosUsuario)
        {
            return permisosUsuario.Any(p => p.Nombre.Equals(nombreItem, StringComparison.OrdinalIgnoreCase));
        }
        private void SincronizarPermisosConMenu()
        {
            var permisosExistentes = _bllPermiso.ListarTodo() ?? new List<BEPermiso>();
            RecorrerMenuYCrear(this.menuStrip1.Items, permisosExistentes);
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

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aBMUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormABMUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormRolesPermisos(this.menuStrip1);
            frm.MdiParent = this;
            frm.Show();
        }

        private void cobroDeMozoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCobroMozo(this._usuario.Usuario);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rendiciónDeCobrosDeMozoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormRendicionCobrosMozo();
            frm.MdiParent = this;
            frm.Show();
        }


        private void cocinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCocina();
            frm.MdiParent = this;
            frm.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmComandas = new FormComandas();
            frmComandas.MdiParent = this;
            frmComandas.Show();
        }

        private void comandaDeMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void listaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormListaEspera();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCompras();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormSalonMozo(this._usuario.Usuario);
            frm.MdiParent = this;  
            frm.Show();
        }

        private void recepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormRecepcion();
            frm.MdiParent = this; 
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCambiarPassword(_usuario);
            frm.ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormBackupRestore(_usuario);
            frm.MdiParent = this;
            frm.Show();
        }

        private void categoriaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCategoriasProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void anularItemComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormAnularItemComanda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultarReimprimirFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormFacturasConsulta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dashboardVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormDashboardVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dashboardOperacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormDashboardOperacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dashboardComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormDashboardCompras();
            frm.MdiParent = this;
            frm.Show();
        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormAuditoriaOperaciones();
            frm.MdiParent = this;   
            frm.Show();
        }
    }
}
