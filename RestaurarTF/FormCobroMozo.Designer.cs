namespace RestaurarTF
{
    partial class FormCobroMozo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.colIdComanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMedio = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(221, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mesas facturadas sin cobrar";
            // 
            // lblMozo
            // 
            this.lblMozo.AutoSize = true;
            this.lblMozo.Location = new System.Drawing.Point(12, 33);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(69, 13);
            this.lblMozo.TabIndex = 1;
            this.lblMozo.Text = "Mozo: (vacío)";
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdComanda,
            this.colMesa,
            this.colFecha,
            this.colTotal});
            this.dgvPendientes.Location = new System.Drawing.Point(15, 58);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(544, 188);
            this.dgvPendientes.TabIndex = 2;
            // 
            // colIdComanda
            // 
            this.colIdComanda.DataPropertyName = "Id_Comanda";
            this.colIdComanda.HeaderText = "Comanda";
            this.colIdComanda.Name = "colIdComanda";
            this.colIdComanda.ReadOnly = true;
            this.colIdComanda.Width = 80;
            // 
            // colMesa
            // 
            this.colMesa.DataPropertyName = "Mesa";
            this.colMesa.HeaderText = "Mesa";
            this.colMesa.Name = "colMesa";
            this.colMesa.ReadOnly = true;
            this.colMesa.Width = 60;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha/hora";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { Format = "N2" };
            this.colTotal.Width = 80;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Medio de pago";
            // 
            // cmbMedio
            // 
            this.cmbMedio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedio.FormattingEnabled = true;
            this.cmbMedio.Location = new System.Drawing.Point(94, 259);
            this.cmbMedio.Name = "cmbMedio";
            this.cmbMedio.Size = new System.Drawing.Size(121, 21);
            this.cmbMedio.TabIndex = 4;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefrescar.Location = new System.Drawing.Point(221, 257);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(404, 257);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(155, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar cobro";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FormCobroMozo
            // 
            this.ClientSize = new System.Drawing.Size(571, 292);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.cmbMedio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.lblMozo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormCobroMozo";
            this.Text = "Cobro de mozo";
            this.Load += new System.EventHandler(this.FormCobroMozo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMedio;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdComanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}
