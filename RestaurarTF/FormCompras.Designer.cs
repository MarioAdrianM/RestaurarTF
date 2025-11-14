namespace RestaurarTF
{
    partial class FormCompras
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboFamilia;
        private System.Windows.Forms.NumericUpDown nudImporte;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblObs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.cboFamilia = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.nudImporte = new System.Windows.Forms.NumericUpDown();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colProveedor,
            this.colComprobante,
            this.colFamilia,
            this.colImporte});
            this.dgvCompras.Location = new System.Drawing.Point(12, 12);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(640, 200);
            this.dgvCompras.TabIndex = 0;
            this.dgvCompras.SelectionChanged += new System.EventHandler(this.dgvCompras_SelectionChanged);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colProveedor
            // 
            this.colProveedor.DataPropertyName = "Proveedor";
            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            this.colProveedor.Width = 150;
            // 
            // colComprobante
            // 
            this.colComprobante.DataPropertyName = "NumeroComprobante";
            this.colComprobante.HeaderText = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.ReadOnly = true;
            // 
            // colFamilia
            // 
            this.colFamilia.DataPropertyName = "Familia";
            this.colFamilia.HeaderText = "Familia";
            this.colFamilia.Name = "colFamilia";
            this.colFamilia.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "ImporteTotal";
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(12, 218);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(59, 13);
            this.lblProveedor.TabIndex = 1;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(12, 234);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(200, 20);
            this.txtProveedor.TabIndex = 2;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(225, 218);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(73, 13);
            this.lblComprobante.TabIndex = 3;
            this.lblComprobante.Text = "Comprobante:";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(228, 234);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(150, 20);
            this.txtComprobante.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(393, 218);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(396, 234);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 6;
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(12, 260);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 7;
            this.lblFamilia.Text = "Familia:";
            // 
            // cboFamilia
            // 
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.Location = new System.Drawing.Point(12, 276);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(200, 21);
            this.cboFamilia.TabIndex = 8;
//            this.cboFamilia.SelectedIndexChanged += new System.EventHandler(this.cboFamilia_SelectedIndexChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(225, 260);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 9;
            this.lblImporte.Text = "Importe:";
            // 
            // nudImporte
            // 
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Location = new System.Drawing.Point(228, 276);
            this.nudImporte.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(150, 20);
            this.nudImporte.TabIndex = 10;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 300);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(78, 13);
            this.lblObs.TabIndex = 11;
            this.lblObs.Text = "Observaciones";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(12, 316);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(484, 50);
            this.txtObs.TabIndex = 12;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(520, 230);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(132, 23);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nueva compra";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(520, 259);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(520, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(520, 317);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(132, 23);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(520, 346);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(132, 23);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormCompras
            // 
            this.ClientSize = new System.Drawing.Size(664, 381);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.nudImporte);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.cboFamilia);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtComprobante);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.dgvCompras);
            this.Name = "FormCompras";
            this.Text = "Registro de compras por familia";
            this.Load += new System.EventHandler(this.FormCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
