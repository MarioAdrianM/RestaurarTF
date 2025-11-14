namespace RestaurarTF
{
    partial class FormRolesPermisos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.groupBoxUsuario = new System.Windows.Forms.GroupBox();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.chkUsuarioBloqueado = new System.Windows.Forms.CheckBox();
            this.chkUsuarioActivo = new System.Windows.Forms.CheckBox();
            this.txtUsuarioPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.txtUsuarioId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            this.groupBoxRolesABM = new System.Windows.Forms.GroupBox();
            this.btnRolEliminar = new System.Windows.Forms.Button();
            this.btnRolModificar = new System.Windows.Forms.Button();
            this.btnRolAlta = new System.Windows.Forms.Button();
            this.txtRolNombre = new System.Windows.Forms.TextBox();
            this.txtRolId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.groupBoxUsuarios = new System.Windows.Forms.GroupBox();
            this.treeUsuarios = new System.Windows.Forms.TreeView();

            this.groupBoxRoles = new System.Windows.Forms.GroupBox();
            this.treeRoles = new System.Windows.Forms.TreeView();

            this.groupBoxPermisos = new System.Windows.Forms.GroupBox();
            this.treePermisos = new System.Windows.Forms.TreeView();

            this.groupBoxPermisosPorRol = new System.Windows.Forms.GroupBox();
            this.treePermisosPorRol = new System.Windows.Forms.TreeView();

            this.groupBoxUsuarioRolesPermisos = new System.Windows.Forms.GroupBox();
            this.treeUsuarioRolesPermisos = new System.Windows.Forms.TreeView();

            this.groupBoxAccionesUsuario = new System.Windows.Forms.GroupBox();
            this.btnPermisoUsuarioQuitar = new System.Windows.Forms.Button();
            this.btnPermisoUsuarioAsignar = new System.Windows.Forms.Button();
            this.btnRolUsuarioQuitar = new System.Windows.Forms.Button();
            this.btnRolUsuarioAsignar = new System.Windows.Forms.Button();

            this.groupBoxAccionesRolPermiso = new System.Windows.Forms.GroupBox();
            this.btnPermisoRolQuitar = new System.Windows.Forms.Button();
            this.btnPermisoRolAsignar = new System.Windows.Forms.Button();

            this.btnCerrar = new System.Windows.Forms.Button();

            this.groupBoxUsuario.SuspendLayout();
            this.groupBoxRolesABM.SuspendLayout();
            this.groupBoxUsuarios.SuspendLayout();
            this.groupBoxRoles.SuspendLayout();
            this.groupBoxPermisos.SuspendLayout();
            this.groupBoxPermisosPorRol.SuspendLayout();
            this.groupBoxUsuarioRolesPermisos.SuspendLayout();
            this.groupBoxAccionesUsuario.SuspendLayout();
            this.groupBoxAccionesRolPermiso.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUsuario
            // 
            this.groupBoxUsuario.Controls.Add(this.btnDesencriptar);
            this.groupBoxUsuario.Controls.Add(this.chkUsuarioBloqueado);
            this.groupBoxUsuario.Controls.Add(this.chkUsuarioActivo);
            this.groupBoxUsuario.Controls.Add(this.txtUsuarioPassword);
            this.groupBoxUsuario.Controls.Add(this.label7);
            this.groupBoxUsuario.Controls.Add(this.txtUsuarioNombre);
            this.groupBoxUsuario.Controls.Add(this.txtUsuarioId);
            this.groupBoxUsuario.Controls.Add(this.label6);
            this.groupBoxUsuario.Controls.Add(this.label5);
            this.groupBoxUsuario.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUsuario.Name = "groupBoxUsuario";
            this.groupBoxUsuario.Size = new System.Drawing.Size(330, 120);
            this.groupBoxUsuario.TabIndex = 0;
            this.groupBoxUsuario.TabStop = false;
            this.groupBoxUsuario.Text = "Usuario";
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.Location = new System.Drawing.Point(220, 83);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(90, 24);
            this.btnDesencriptar.TabIndex = 8;
            this.btnDesencriptar.Text = "Desencriptar";
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.Click += new System.EventHandler(this.btnDesencriptar_Click);
            // 
            // chkUsuarioBloqueado
            // 
            this.chkUsuarioBloqueado.AutoSize = true;
            this.chkUsuarioBloqueado.Enabled = false;
            this.chkUsuarioBloqueado.Location = new System.Drawing.Point(220, 27);
            this.chkUsuarioBloqueado.Name = "chkUsuarioBloqueado";
            this.chkUsuarioBloqueado.Size = new System.Drawing.Size(77, 17);
            this.chkUsuarioBloqueado.TabIndex = 7;
            this.chkUsuarioBloqueado.Text = "Bloqueado";
            this.chkUsuarioBloqueado.UseVisualStyleBackColor = true;
            // 
            // chkUsuarioActivo
            // 
            this.chkUsuarioActivo.AutoSize = true;
            this.chkUsuarioActivo.Enabled = false;
            this.chkUsuarioActivo.Location = new System.Drawing.Point(220, 53);
            this.chkUsuarioActivo.Name = "chkUsuarioActivo";
            this.chkUsuarioActivo.Size = new System.Drawing.Size(56, 17);
            this.chkUsuarioActivo.TabIndex = 6;
            this.chkUsuarioActivo.Text = "Activo";
            this.chkUsuarioActivo.UseVisualStyleBackColor = true;
            // 
            // txtUsuarioPassword
            // 
            this.txtUsuarioPassword.Location = new System.Drawing.Point(70, 87);
            this.txtUsuarioPassword.Name = "txtUsuarioPassword";
            this.txtUsuarioPassword.ReadOnly = true;
            this.txtUsuarioPassword.UseSystemPasswordChar = true;
            this.txtUsuarioPassword.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioPassword.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Password:";
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.Enabled = false;
            this.txtUsuarioNombre.Location = new System.Drawing.Point(70, 53);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioNombre.TabIndex = 3;
            // 
            // txtUsuarioId
            // 
            this.txtUsuarioId.Enabled = false;
            this.txtUsuarioId.Location = new System.Drawing.Point(70, 25);
            this.txtUsuarioId.Name = "txtUsuarioId";
            this.txtUsuarioId.Size = new System.Drawing.Size(58, 20);
            this.txtUsuarioId.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID:";
            // 
            // groupBoxRolesABM
            // 
            this.groupBoxRolesABM.Controls.Add(this.btnRolEliminar);
            this.groupBoxRolesABM.Controls.Add(this.btnRolModificar);
            this.groupBoxRolesABM.Controls.Add(this.btnRolAlta);
            this.groupBoxRolesABM.Controls.Add(this.txtRolNombre);
            this.groupBoxRolesABM.Controls.Add(this.txtRolId);
            this.groupBoxRolesABM.Controls.Add(this.label2);
            this.groupBoxRolesABM.Controls.Add(this.label1);
            this.groupBoxRolesABM.Location = new System.Drawing.Point(348, 12);
            this.groupBoxRolesABM.Name = "groupBoxRolesABM";
            this.groupBoxRolesABM.Size = new System.Drawing.Size(240, 120);
            this.groupBoxRolesABM.TabIndex = 1;
            this.groupBoxRolesABM.TabStop = false;
            this.groupBoxRolesABM.Text = "Rol";
            // 
            // btnRolEliminar
            // 
            this.btnRolEliminar.Location = new System.Drawing.Point(156, 79);
            this.btnRolEliminar.Name = "btnRolEliminar";
            this.btnRolEliminar.Size = new System.Drawing.Size(70, 30);
            this.btnRolEliminar.TabIndex = 6;
            this.btnRolEliminar.Text = "Eliminar";
            this.btnRolEliminar.UseVisualStyleBackColor = true;
            this.btnRolEliminar.Click += new System.EventHandler(this.btnRolEliminar_Click);
            // 
            // btnRolModificar
            // 
            this.btnRolModificar.Location = new System.Drawing.Point(81, 79);
            this.btnRolModificar.Name = "btnRolModificar";
            this.btnRolModificar.Size = new System.Drawing.Size(69, 30);
            this.btnRolModificar.TabIndex = 5;
            this.btnRolModificar.Text = "Modificar";
            this.btnRolModificar.UseVisualStyleBackColor = true;
            this.btnRolModificar.Click += new System.EventHandler(this.btnRolModificar_Click);
            // 
            // btnRolAlta
            // 
            this.btnRolAlta.Location = new System.Drawing.Point(10, 79);
            this.btnRolAlta.Name = "btnRolAlta";
            this.btnRolAlta.Size = new System.Drawing.Size(65, 30);
            this.btnRolAlta.TabIndex = 4;
            this.btnRolAlta.Text = "Alta";
            this.btnRolAlta.UseVisualStyleBackColor = true;
            this.btnRolAlta.Click += new System.EventHandler(this.btnRolAlta_Click);
            // 
            // txtRolNombre
            // 
            this.txtRolNombre.Location = new System.Drawing.Point(73, 46);
            this.txtRolNombre.Name = "txtRolNombre";
            this.txtRolNombre.Size = new System.Drawing.Size(153, 20);
            this.txtRolNombre.TabIndex = 3;
            // 
            // txtRolId
            // 
            this.txtRolId.Enabled = false;
            this.txtRolId.Location = new System.Drawing.Point(37, 20);
            this.txtRolId.Name = "txtRolId";
            this.txtRolId.Size = new System.Drawing.Size(50, 20);
            this.txtRolId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // groupBoxUsuarios
            // 
            this.groupBoxUsuarios.Controls.Add(this.treeUsuarios);
            this.groupBoxUsuarios.Location = new System.Drawing.Point(12, 138);
            this.groupBoxUsuarios.Name = "groupBoxUsuarios";
            this.groupBoxUsuarios.Size = new System.Drawing.Size(160, 430);
            this.groupBoxUsuarios.TabIndex = 2;
            this.groupBoxUsuarios.TabStop = false;
            this.groupBoxUsuarios.Text = "Usuarios";
            // 
            // treeUsuarios
            // 
            this.treeUsuarios.Location = new System.Drawing.Point(6, 19);
            this.treeUsuarios.Name = "treeUsuarios";
            this.treeUsuarios.Size = new System.Drawing.Size(148, 405);
            this.treeUsuarios.TabIndex = 0;
            this.treeUsuarios.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeUsuarios_AfterSelect);
            // 
            // groupBoxRoles
            // 
            this.groupBoxRoles.Controls.Add(this.treeRoles);
            this.groupBoxRoles.Location = new System.Drawing.Point(178, 138);
            this.groupBoxRoles.Name = "groupBoxRoles";
            this.groupBoxRoles.Size = new System.Drawing.Size(160, 430);
            this.groupBoxRoles.TabIndex = 3;
            this.groupBoxRoles.TabStop = false;
            this.groupBoxRoles.Text = "Roles";
            // 
            // treeRoles
            // 
            this.treeRoles.Location = new System.Drawing.Point(6, 19);
            this.treeRoles.Name = "treeRoles";
            this.treeRoles.Size = new System.Drawing.Size(148, 405);
            this.treeRoles.TabIndex = 0;
            this.treeRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRoles_AfterSelect);
            // 
            // groupBoxPermisos
            // 
            this.groupBoxPermisos.Controls.Add(this.treePermisos);
            this.groupBoxPermisos.Location = new System.Drawing.Point(344, 138);
            this.groupBoxPermisos.Name = "groupBoxPermisos";
            this.groupBoxPermisos.Size = new System.Drawing.Size(180, 430);
            this.groupBoxPermisos.TabIndex = 4;
            this.groupBoxPermisos.TabStop = false;
            this.groupBoxPermisos.Text = "Permisos (desde menú)";
            // 
            // treePermisos
            // 
            this.treePermisos.Location = new System.Drawing.Point(6, 19);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(168, 405);
            this.treePermisos.TabIndex = 0;
            this.treePermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePermisos_AfterSelect);
            // 
            // groupBoxPermisosPorRol
            // 
            this.groupBoxPermisosPorRol.Controls.Add(this.treePermisosPorRol);
            this.groupBoxPermisosPorRol.Location = new System.Drawing.Point(530, 138);
            this.groupBoxPermisosPorRol.Name = "groupBoxPermisosPorRol";
            this.groupBoxPermisosPorRol.Size = new System.Drawing.Size(180, 430);
            this.groupBoxPermisosPorRol.TabIndex = 5;
            this.groupBoxPermisosPorRol.TabStop = false;
            this.groupBoxPermisosPorRol.Text = "Permisos por Rol";
            // 
            // treePermisosPorRol
            // 
            this.treePermisosPorRol.Location = new System.Drawing.Point(6, 19);
            this.treePermisosPorRol.Name = "treePermisosPorRol";
            this.treePermisosPorRol.Size = new System.Drawing.Size(168, 405);
            this.treePermisosPorRol.TabIndex = 0;
            this.treePermisosPorRol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePermisosPorRol_AfterSelect);
            // 
            // groupBoxUsuarioRolesPermisos
            // 
            this.groupBoxUsuarioRolesPermisos.Controls.Add(this.treeUsuarioRolesPermisos);
            this.groupBoxUsuarioRolesPermisos.Location = new System.Drawing.Point(716, 138);
            this.groupBoxUsuarioRolesPermisos.Name = "groupBoxUsuarioRolesPermisos";
            this.groupBoxUsuarioRolesPermisos.Size = new System.Drawing.Size(210, 430);
            this.groupBoxUsuarioRolesPermisos.TabIndex = 6;
            this.groupBoxUsuarioRolesPermisos.TabStop = false;
            this.groupBoxUsuarioRolesPermisos.Text = "Roles y Permisos del Usuario";
            // 
            // treeUsuarioRolesPermisos
            // 
            this.treeUsuarioRolesPermisos.Location = new System.Drawing.Point(6, 19);
            this.treeUsuarioRolesPermisos.Name = "treeUsuarioRolesPermisos";
            this.treeUsuarioRolesPermisos.Size = new System.Drawing.Size(198, 405);
            this.treeUsuarioRolesPermisos.TabIndex = 0;
            this.treeUsuarioRolesPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeUsuarioRolesPermisos_AfterSelect);
            // 
            // groupBoxAccionesUsuario
            // 
            this.groupBoxAccionesUsuario.Controls.Add(this.btnPermisoUsuarioQuitar);
            this.groupBoxAccionesUsuario.Controls.Add(this.btnPermisoUsuarioAsignar);
            this.groupBoxAccionesUsuario.Controls.Add(this.btnRolUsuarioQuitar);
            this.groupBoxAccionesUsuario.Controls.Add(this.btnRolUsuarioAsignar);
            this.groupBoxAccionesUsuario.Location = new System.Drawing.Point(12, 574);
            this.groupBoxAccionesUsuario.Name = "groupBoxAccionesUsuario";
            this.groupBoxAccionesUsuario.Size = new System.Drawing.Size(414, 70);
            this.groupBoxAccionesUsuario.TabIndex = 7;
            this.groupBoxAccionesUsuario.TabStop = false;
            this.groupBoxAccionesUsuario.Text = "Asignar / Quitar a Usuario";
            // 
            // btnPermisoUsuarioQuitar
            // 
            this.btnPermisoUsuarioQuitar.Location = new System.Drawing.Point(306, 19);
            this.btnPermisoUsuarioQuitar.Name = "btnPermisoUsuarioQuitar";
            this.btnPermisoUsuarioQuitar.Size = new System.Drawing.Size(102, 40);
            this.btnPermisoUsuarioQuitar.TabIndex = 3;
            this.btnPermisoUsuarioQuitar.Text = "Quitar Permiso";
            this.btnPermisoUsuarioQuitar.UseVisualStyleBackColor = true;
            this.btnPermisoUsuarioQuitar.Click += new System.EventHandler(this.btnPermisoUsuarioQuitar_Click);
            // 
            // btnPermisoUsuarioAsignar
            // 
            this.btnPermisoUsuarioAsignar.Location = new System.Drawing.Point(199, 19);
            this.btnPermisoUsuarioAsignar.Name = "btnPermisoUsuarioAsignar";
            this.btnPermisoUsuarioAsignar.Size = new System.Drawing.Size(101, 40);
            this.btnPermisoUsuarioAsignar.TabIndex = 2;
            this.btnPermisoUsuarioAsignar.Text = "Asociar Permiso";
            this.btnPermisoUsuarioAsignar.UseVisualStyleBackColor = true;
            this.btnPermisoUsuarioAsignar.Click += new System.EventHandler(this.btnPermisoUsuarioAsignar_Click);
            // 
            // btnRolUsuarioQuitar
            // 
            this.btnRolUsuarioQuitar.Location = new System.Drawing.Point(105, 19);
            this.btnRolUsuarioQuitar.Name = "btnRolUsuarioQuitar";
            this.btnRolUsuarioQuitar.Size = new System.Drawing.Size(88, 40);
            this.btnRolUsuarioQuitar.TabIndex = 1;
            this.btnRolUsuarioQuitar.Text = "Quitar Rol";
            this.btnRolUsuarioQuitar.UseVisualStyleBackColor = true;
            this.btnRolUsuarioQuitar.Click += new System.EventHandler(this.btnRolUsuarioQuitar_Click);
            // 
            // btnRolUsuarioAsignar
            // 
            this.btnRolUsuarioAsignar.Location = new System.Drawing.Point(6, 19);
            this.btnRolUsuarioAsignar.Name = "btnRolUsuarioAsignar";
            this.btnRolUsuarioAsignar.Size = new System.Drawing.Size(93, 40);
            this.btnRolUsuarioAsignar.TabIndex = 0;
            this.btnRolUsuarioAsignar.Text = "Asociar Rol";
            this.btnRolUsuarioAsignar.UseVisualStyleBackColor = true;
            this.btnRolUsuarioAsignar.Click += new System.EventHandler(this.btnRolUsuarioAsignar_Click);
            // 
            // groupBoxAccionesRolPermiso
            // 
            this.groupBoxAccionesRolPermiso.Controls.Add(this.btnPermisoRolQuitar);
            this.groupBoxAccionesRolPermiso.Controls.Add(this.btnPermisoRolAsignar);
            this.groupBoxAccionesRolPermiso.Location = new System.Drawing.Point(432, 574);
            this.groupBoxAccionesRolPermiso.Name = "groupBoxAccionesRolPermiso";
            this.groupBoxAccionesRolPermiso.Size = new System.Drawing.Size(214, 70);
            this.groupBoxAccionesRolPermiso.TabIndex = 8;
            this.groupBoxAccionesRolPermiso.TabStop = false;
            this.groupBoxAccionesRolPermiso.Text = "Asignar / Quitar a Rol";
            // 
            // btnPermisoRolQuitar
            // 
            this.btnPermisoRolQuitar.Location = new System.Drawing.Point(109, 19);
            this.btnPermisoRolQuitar.Name = "btnPermisoRolQuitar";
            this.btnPermisoRolQuitar.Size = new System.Drawing.Size(97, 40);
            this.btnPermisoRolQuitar.TabIndex = 1;
            this.btnPermisoRolQuitar.Text = "Quitar Permiso del Rol";
            this.btnPermisoRolQuitar.UseVisualStyleBackColor = true;
            this.btnPermisoRolQuitar.Click += new System.EventHandler(this.btnPermisoRolQuitar_Click);
            // 
            // btnPermisoRolAsignar
            // 
            this.btnPermisoRolAsignar.Location = new System.Drawing.Point(6, 19);
            this.btnPermisoRolAsignar.Name = "btnPermisoRolAsignar";
            this.btnPermisoRolAsignar.Size = new System.Drawing.Size(97, 40);
            this.btnPermisoRolAsignar.TabIndex = 0;
            this.btnPermisoRolAsignar.Text = "Asociar Permiso al Rol";
            this.btnPermisoRolAsignar.UseVisualStyleBackColor = true;
            this.btnPermisoRolAsignar.Click += new System.EventHandler(this.btnPermisoRolAsignar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(834, 586);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(92, 46);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormRolesPermisos
            // 
            this.ClientSize = new System.Drawing.Size(938, 656);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBoxAccionesRolPermiso);
            this.Controls.Add(this.groupBoxAccionesUsuario);
            this.Controls.Add(this.groupBoxUsuarioRolesPermisos);
            this.Controls.Add(this.groupBoxPermisosPorRol);
            this.Controls.Add(this.groupBoxPermisos);
            this.Controls.Add(this.groupBoxRoles);
            this.Controls.Add(this.groupBoxUsuarios);
            this.Controls.Add(this.groupBoxRolesABM);
            this.Controls.Add(this.groupBoxUsuario);
            this.Name = "FormRolesPermisos";
            this.Text = "Roles y Permisos";
            this.Load += new System.EventHandler(this.FormRolesPermisos_Load);
            this.groupBoxUsuario.ResumeLayout(false);
            this.groupBoxUsuario.PerformLayout();
            this.groupBoxRolesABM.ResumeLayout(false);
            this.groupBoxRolesABM.PerformLayout();
            this.groupBoxUsuarios.ResumeLayout(false);
            this.groupBoxRoles.ResumeLayout(false);
            this.groupBoxPermisos.ResumeLayout(false);
            this.groupBoxPermisosPorRol.ResumeLayout(false);
            this.groupBoxUsuarioRolesPermisos.ResumeLayout(false);
            this.groupBoxAccionesUsuario.ResumeLayout(false);
            this.groupBoxAccionesRolPermiso.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUsuario;
        private System.Windows.Forms.Button btnDesencriptar;
        private System.Windows.Forms.CheckBox chkUsuarioBloqueado;
        private System.Windows.Forms.CheckBox chkUsuarioActivo;
        private System.Windows.Forms.TextBox txtUsuarioPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.TextBox txtUsuarioId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxRolesABM;
        private System.Windows.Forms.Button btnRolEliminar;
        private System.Windows.Forms.Button btnRolModificar;
        private System.Windows.Forms.Button btnRolAlta;
        private System.Windows.Forms.TextBox txtRolNombre;
        private System.Windows.Forms.TextBox txtRolId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxUsuarios;
        private System.Windows.Forms.TreeView treeUsuarios;
        private System.Windows.Forms.GroupBox groupBoxRoles;
        private System.Windows.Forms.TreeView treeRoles;
        private System.Windows.Forms.GroupBox groupBoxPermisos;
        private System.Windows.Forms.TreeView treePermisos;
        private System.Windows.Forms.GroupBox groupBoxPermisosPorRol;
        private System.Windows.Forms.TreeView treePermisosPorRol;
        private System.Windows.Forms.GroupBox groupBoxUsuarioRolesPermisos;
        private System.Windows.Forms.TreeView treeUsuarioRolesPermisos;
        private System.Windows.Forms.GroupBox groupBoxAccionesUsuario;
        private System.Windows.Forms.Button btnPermisoUsuarioQuitar;
        private System.Windows.Forms.Button btnPermisoUsuarioAsignar;
        private System.Windows.Forms.Button btnRolUsuarioQuitar;
        private System.Windows.Forms.Button btnRolUsuarioAsignar;
        private System.Windows.Forms.GroupBox groupBoxAccionesRolPermiso;
        private System.Windows.Forms.Button btnPermisoRolQuitar;
        private System.Windows.Forms.Button btnPermisoRolAsignar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
