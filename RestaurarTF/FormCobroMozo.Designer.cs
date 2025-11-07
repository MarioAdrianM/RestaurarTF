namespace RestaurarTF
{
    partial class FormCobroMozo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtComanda = new System.Windows.Forms.TextBox();
            this.btnBuscarFactura = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMozo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMedio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° de Comanda:";
            // 
            // txtComanda
            // 
            this.txtComanda.Location = new System.Drawing.Point(106, 12);
            this.txtComanda.Name = "txtComanda";
            this.txtComanda.Size = new System.Drawing.Size(87, 20);
            this.txtComanda.TabIndex = 1;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Location = new System.Drawing.Point(199, 10);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarFactura.TabIndex = 2;
            this.btnBuscarFactura.Text = "...";
            this.btnBuscarFactura.UseVisualStyleBackColor = true;
            this.btnBuscarFactura.Click += new System.EventHandler(this.btnBuscarFactura_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mozo";
            // 
            // txtMozo
            // 
            this.txtMozo.Location = new System.Drawing.Point(272, 12);
            this.txtMozo.Name = "txtMozo";
            this.txtMozo.Size = new System.Drawing.Size(112, 20);
            this.txtMozo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medio";
            // 
            // cmbMedio
            // 
            this.cmbMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedio.FormattingEnabled = true;
            this.cmbMedio.Location = new System.Drawing.Point(430, 11);
            this.cmbMedio.Name = "cmbMedio";
            this.cmbMedio.Size = new System.Drawing.Size(121, 21);
            this.cmbMedio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(65, 42);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(128, 20);
            this.txtImporte.TabIndex = 8;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(213, 40);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(103, 23);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrar cobro";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Location = new System.Drawing.Point(20, 98);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(531, 189);
            this.dgvPendientes.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mis cobros no rendidos aún:";
            // 
            // FormCobroMozo
            // 
            this.ClientSize = new System.Drawing.Size(566, 304);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMedio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMozo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscarFactura);
            this.Controls.Add(this.txtComanda);
            this.Controls.Add(this.label1);
            this.Name = "FormCobroMozo";
            this.Text = "Cobro de Mozo";
            this.Load += new System.EventHandler(this.FormCobroMozo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComanda;
        private System.Windows.Forms.Button btnBuscarFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMozo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMedio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label label5;
    }
}
