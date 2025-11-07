namespace RestaurarTF
{
    partial class FormSeguridad
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstUsuarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.chkBloqueado = new System.Windows.Forms.CheckBox();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRolId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRolNombre = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstPermisosDelRol = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregarPermisoARol = new System.Windows.Forms.Button();
            this.btnQuitarPermisoARol = new System.Windows.Forms.Button();
            this.lstRolesUsuario = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarRolAUsuario = new System.Windows.Forms.Button();
            this.btnQuitarRolAUsuario = new System.Windows.Forms.Button();
            this.lstPermisosUsuario = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregarPermisoAUsuario = new System.Windows.Forms.Button();
            this.btnQuitarPermisoAUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Location = new System.Drawing.Point(12, 27);
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(150, 303);
            this.lstUsuarios.TabIndex = 0;
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(171, 43);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(160, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(171, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Enabled = false;
            this.chkActivo.Location = new System.Drawing.Point(171, 114);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 5;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.AutoSize = true;
            this.chkBloqueado.Enabled = false;
            this.chkBloqueado.Location = new System.Drawing.Point(233, 114);
            this.chkBloqueado.Name = "chkBloqueado";
            this.chkBloqueado.Size = new System.Drawing.Size(79, 17);
            this.chkBloqueado.TabIndex = 6;
            this.chkBloqueado.Text = "Bloqueado";
            this.chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.Location = new System.Drawing.Point(171, 137);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(160, 23);
            this.btnDesencriptar.TabIndex = 7;
            this.btnDesencriptar.Text = "Desencriptar contraseña";
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.Click += new System.EventHandler(this.btnDesencriptar_Click);
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(356, 27);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(150, 134);
            this.lstRoles.TabIndex = 8;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Id:";
            // 
            // txtRolId
            // 
            this.txtRolId.Location = new System.Drawing.Point(356, 184);
            this.txtRolId.Name = "txtRolId";
            this.txtRolId.ReadOnly = true;
            this.txtRolId.Size = new System.Drawing.Size(53, 20);
            this.txtRolId.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre:";
            // 
            // txtRolNombre
            // 
            this.txtRolNombre.Location = new System.Drawing.Point(415, 184);
            this.txtRolNombre.Name = "txtRolNombre";
            this.txtRolNombre.Size = new System.Drawing.Size(141, 20);
            this.txtRolNombre.TabIndex = 12;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(356, 210);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(90, 23);
            this.btnCrearRol.TabIndex = 13;
            this.btnCrearRol.Text = "Crear rol";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Location = new System.Drawing.Point(452, 210);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(90, 23);
            this.btnEliminarRol.TabIndex = 14;
            this.btnEliminarRol.Text = "Eliminar rol";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // lstPermisos
            // 
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(572, 27);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.Size = new System.Drawing.Size(150, 134);
            this.lstPermisos.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Permisos disponibles:";
            // 
            // lstPermisosDelRol
            // 
            this.lstPermisosDelRol.FormattingEnabled = true;
            this.lstPermisosDelRol.Location = new System.Drawing.Point(572, 184);
            this.lstPermisosDelRol.Name = "lstPermisosDelRol";
            this.lstPermisosDelRol.Size = new System.Drawing.Size(150, 134);
            this.lstPermisosDelRol.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Permisos del rol:";
            // 
            // btnAgregarPermisoARol
            // 
            this.btnAgregarPermisoARol.Location = new System.Drawing.Point(728, 60);
            this.btnAgregarPermisoARol.Name = "btnAgregarPermisoARol";
            this.btnAgregarPermisoARol.Size = new System.Drawing.Size(123, 23);
            this.btnAgregarPermisoARol.TabIndex = 19;
            this.btnAgregarPermisoARol.Text = ">> al rol";
            this.btnAgregarPermisoARol.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoARol.Click += new System.EventHandler(this.btnAgregarPermisoARol_Click);
            // 
            // btnQuitarPermisoARol
            // 
            this.btnQuitarPermisoARol.Location = new System.Drawing.Point(728, 214);
            this.btnQuitarPermisoARol.Name = "btnQuitarPermisoARol";
            this.btnQuitarPermisoARol.Size = new System.Drawing.Size(123, 23);
            this.btnQuitarPermisoARol.TabIndex = 20;
            this.btnQuitarPermisoARol.Text = "<< quitar del rol";
            this.btnQuitarPermisoARol.UseVisualStyleBackColor = true;
            this.btnQuitarPermisoARol.Click += new System.EventHandler(this.btnQuitarPermisoARol_Click);
            // 
            // lstRolesUsuario
            // 
            this.lstRolesUsuario.FormattingEnabled = true;
            this.lstRolesUsuario.Location = new System.Drawing.Point(171, 204);
            this.lstRolesUsuario.Name = "lstRolesUsuario";
            this.lstRolesUsuario.Size = new System.Drawing.Size(160, 95);
            this.lstRolesUsuario.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Roles usuario";
            // 
            // btnAgregarRolAUsuario
            // 
            this.btnAgregarRolAUsuario.Location = new System.Drawing.Point(356, 239);
            this.btnAgregarRolAUsuario.Name = "btnAgregarRolAUsuario";
            this.btnAgregarRolAUsuario.Size = new System.Drawing.Size(90, 23);
            this.btnAgregarRolAUsuario.TabIndex = 23;
            this.btnAgregarRolAUsuario.Text = ">> usuario";
            this.btnAgregarRolAUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarRolAUsuario.Click += new System.EventHandler(this.btnAgregarRolAUsuario_Click);
            // 
            // btnQuitarRolAUsuario
            // 
            this.btnQuitarRolAUsuario.Location = new System.Drawing.Point(452, 239);
            this.btnQuitarRolAUsuario.Name = "btnQuitarRolAUsuario";
            this.btnQuitarRolAUsuario.Size = new System.Drawing.Size(90, 23);
            this.btnQuitarRolAUsuario.TabIndex = 24;
            this.btnQuitarRolAUsuario.Text = "<< quitar";
            this.btnQuitarRolAUsuario.UseVisualStyleBackColor = true;
            this.btnQuitarRolAUsuario.Click += new System.EventHandler(this.btnQuitarRolAUsuario_Click);
            // 
            // lstPermisosUsuario
            // 
            this.lstPermisosUsuario.FormattingEnabled = true;
            this.lstPermisosUsuario.Location = new System.Drawing.Point(171, 318);
            this.lstPermisosUsuario.Name = "lstPermisosUsuario";
            this.lstPermisosUsuario.Size = new System.Drawing.Size(160, 95);
            this.lstPermisosUsuario.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Permisos usuario";
            // 
            // btnAgregarPermisoAUsuario
            // 
            this.btnAgregarPermisoAUsuario.Location = new System.Drawing.Point(356, 318);
            this.btnAgregarPermisoAUsuario.Name = "btnAgregarPermisoAUsuario";
            this.btnAgregarPermisoAUsuario.Size = new System.Drawing.Size(90, 23);
            this.btnAgregarPermisoAUsuario.TabIndex = 27;
            this.btnAgregarPermisoAUsuario.Text = "permiso >>";
            this.btnAgregarPermisoAUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoAUsuario.Click += new System.EventHandler(this.btnAgregarPermisoAUsuario_Click);
            // 
            // btnQuitarPermisoAUsuario
            // 
            this.btnQuitarPermisoAUsuario.Location = new System.Drawing.Point(452, 318);
            this.btnQuitarPermisoAUsuario.Name = "btnQuitarPermisoAUsuario";
            this.btnQuitarPermisoAUsuario.Size = new System.Drawing.Size(90, 23);
            this.btnQuitarPermisoAUsuario.TabIndex = 28;
            this.btnQuitarPermisoAUsuario.Text = "<< quitar";
            this.btnQuitarPermisoAUsuario.UseVisualStyleBackColor = true;
            this.btnQuitarPermisoAUsuario.Click += new System.EventHandler(this.btnQuitarPermisoAUsuario_Click);
            // 
            // FormSeguridad
            // 
            this.ClientSize = new System.Drawing.Size(867, 427);
            this.Controls.Add(this.btnQuitarPermisoAUsuario);
            this.Controls.Add(this.btnAgregarPermisoAUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstPermisosUsuario);
            this.Controls.Add(this.btnQuitarRolAUsuario);
            this.Controls.Add(this.btnAgregarRolAUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstRolesUsuario);
            this.Controls.Add(this.btnQuitarPermisoARol);
            this.Controls.Add(this.btnAgregarPermisoARol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstPermisosDelRol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstPermisos);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.txtRolNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRolId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstRoles);
            this.Controls.Add(this.btnDesencriptar);
            this.Controls.Add(this.chkBloqueado);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUsuarios);
            this.Name = "FormSeguridad";
            this.Text = "Seguridad";
            this.Load += new System.EventHandler(this.FormSeguridad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.CheckBox chkBloqueado;
        private System.Windows.Forms.Button btnDesencriptar;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRolId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRolNombre;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstPermisosDelRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregarPermisoARol;
        private System.Windows.Forms.Button btnQuitarPermisoARol;
        private System.Windows.Forms.ListBox lstRolesUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarRolAUsuario;
        private System.Windows.Forms.Button btnQuitarRolAUsuario;
        private System.Windows.Forms.ListBox lstPermisosUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarPermisoAUsuario;
        private System.Windows.Forms.Button btnQuitarPermisoAUsuario;
    }
}
