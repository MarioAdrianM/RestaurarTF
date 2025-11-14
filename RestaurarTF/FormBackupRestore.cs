using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL_Negocio;
using System.Linq;


namespace RestaurarTF
{
    public partial class FormBackupRestore : Form
    {
        private readonly BEUsuario _usuario;
        private readonly BLLGestorBD _bllGestorBD;
        private readonly BLLBitacora _bllBitacora;
        private readonly BLLUsuario _bllUsuario;


        public FormBackupRestore(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            _usuario = usuarioLogueado;
            _bllGestorBD = new BLLGestorBD();
            _bllBitacora = new BLLBitacora();
            _bllUsuario = new BLLUsuario();
        }

        private void FormBackupRestore_Load(object sender, EventArgs e)
        {
            CargarBackups();
            CargarHistorial();
        }

        private void CargarBackups()
        {
            lstBackups.Items.Clear();
            try
            {
                var archivos = _bllGestorBD.ListarBackups();
                foreach (var a in archivos)
                    lstBackups.Items.Add(a);
            }
            catch
            {
                
            }
        }

        private void CargarHistorial()
        {
            var backs = _bllBitacora.ListarTodoPorTipo(true) ?? new List<BEBitacora>();
            var rests = _bllBitacora.ListarTodoPorTipo(false) ?? new List<BEBitacora>();

            var lista = new List<BEBitacora>();
            lista.AddRange(backs);
            lista.AddRange(rests);

            var usuarios = _bllUsuario.ListarTodo() ?? new List<BEUsuario>();
            var dicUsuarios = usuarios.ToDictionary(u => u.Id, u => u.Usuario);

            var vista = lista
                .OrderByDescending(b => b.FechaRegistro)
                .Select(b => new
                {
                    Fecha = b.FechaRegistro,
                    Accion = b.Detalle,
                    Usuario = (b.oBEUsuario != null && dicUsuarios.ContainsKey(b.oBEUsuario.Id))
                                ? dicUsuarios[b.oBEUsuario.Id]
                                : (b.oBEUsuario != null ? b.oBEUsuario.Id.ToString() : ""),
                })
                .ToList();

            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = vista;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                _bllGestorBD.CrearBackup(); 

                _bllBitacora.Guardar(new BEBitacora
                {
                    Detalle = "backup",
                    FechaRegistro = DateTime.Now,
                    oBEUsuario = _usuario
                });

                MessageBox.Show("Backup realizado correctamente.");
                CargarBackups();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

            if (lstBackups.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un backup de la lista.");
                return;
            }

            string nombreBackup = lstBackups.SelectedItem.ToString();

            var r = MessageBox.Show(
                "Se va a restaurar la base de datos con el backup seleccionado.\n" +
                "Esto sobrescribirá los datos actuales.\n\n¿Desea continuar?",
                "Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes)
                return;

            try
            {
                _bllGestorBD.CrearRestore(nombreBackup);

                _bllBitacora.Guardar(new BEBitacora
                {
                    Detalle = "restore",
                    FechaRegistro = DateTime.Now,
                    oBEUsuario = _usuario
                });

                MessageBox.Show(
                    "Restore realizado correctamente.\n\nLa aplicación se reiniciará para aplicar los cambios.",
                    "Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
