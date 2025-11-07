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

        public FormMenu(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            _usuario = usuarioLogueado;
            _bllUsuario = new BLLUsuario();
            _permisos = _bllUsuario.ListarTodosLosPermisosDelUsuario(_usuario);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            OcultarTodosLosItemsDelMenu();
            if (_permisos != null && _permisos.Count > 0)
                MostrarItemsSegunPermisos(_permisos);
        }

        // =======================
        //  ABRIR FORMULARIOS
        // =======================
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

        // =======================
        //  OCULTAR (igual que FordFox)
        // =======================
        private void OcultarTodosLosItemsDelMenu()
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Visible = false;
                    if (menuItem.DropDownItems.Count > 0)
                        OcultarItemsDelSubMenu(menuItem.DropDownItems);
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
                    // si tuvieras más niveles, podés volver a llamar
                    // if (subItem.DropDownItems.Count > 0) OcultarItemsDelSubMenu(subItem.DropDownItems);
                }
            }
        }

        // =======================
        //  MOSTRAR SEGÚN PERMISOS
        // =======================
        private void MostrarItemsSegunPermisos(List<BEPermiso> permisosUsuario)
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // primero veo submenús
                    if (menuItem.DropDownItems.Count > 0)
                        MostrarSubItemsSegunPermisos(menuItem, permisosUsuario);

                    // después veo si este propio item tiene permiso
                    if (TienePermiso(menuItem.Text, permisosUsuario))
                        menuItem.Visible = true;
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
                    // recursivo si hay más niveles
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
            var frm = new FormSeguridad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cobroDeMozoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormCobroMozo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rendiciónDeCobrosDeMozoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormRendicionCobrosMozo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void resumenDeCobrosDeMozoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormResumenCobrosMozo();
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

       
    }
}
