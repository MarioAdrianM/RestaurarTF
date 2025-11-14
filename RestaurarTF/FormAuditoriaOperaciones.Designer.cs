namespace RestaurarTF
{
    partial class FormAuditoriaOperaciones
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// </summary>
        /// <param name="disposing">true 
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBoxAnulaciones = new System.Windows.Forms.GroupBox();
            this.dgvAnulaciones = new System.Windows.Forms.DataGridView();
            this.groupBoxCancelaciones = new System.Windows.Forms.GroupBox();
            this.dgvCancelaciones = new System.Windows.Forms.DataGridView();
            this.groupBoxAnulaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnulaciones)).BeginInit();
            this.groupBoxCancelaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(12, 15);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(240, 15);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(59, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(284, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(410, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBoxAnulaciones
            // 
            this.groupBoxAnulaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAnulaciones.Controls.Add(this.dgvAnulaciones);
            this.groupBoxAnulaciones.Location = new System.Drawing.Point(12, 45);
            this.groupBoxAnulaciones.Name = "groupBoxAnulaciones";
            this.groupBoxAnulaciones.Size = new System.Drawing.Size(760, 200);
            this.groupBoxAnulaciones.TabIndex = 5;
            this.groupBoxAnulaciones.TabStop = false;
            this.groupBoxAnulaciones.Text = "Ítems anulados";
            // 
            // dgvAnulaciones
            // 
            this.dgvAnulaciones.AllowUserToAddRows = false;
            this.dgvAnulaciones.AllowUserToDeleteRows = false;
            this.dgvAnulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnulaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnulaciones.Location = new System.Drawing.Point(3, 16);
            this.dgvAnulaciones.Name = "dgvAnulaciones";
            this.dgvAnulaciones.Size = new System.Drawing.Size(754, 181);
            this.dgvAnulaciones.TabIndex = 0;
            // 
            // groupBoxCancelaciones
            // 
            this.groupBoxCancelaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCancelaciones.Controls.Add(this.dgvCancelaciones);
            this.groupBoxCancelaciones.Location = new System.Drawing.Point(12, 251);
            this.groupBoxCancelaciones.Name = "groupBoxCancelaciones";
            this.groupBoxCancelaciones.Size = new System.Drawing.Size(760, 198);
            this.groupBoxCancelaciones.TabIndex = 6;
            this.groupBoxCancelaciones.TabStop = false;
            this.groupBoxCancelaciones.Text = "Comandas canceladas / mesas liberadas sin consumo";
            // 
            // dgvCancelaciones
            // 
            this.dgvCancelaciones.AllowUserToAddRows = false;
            this.dgvCancelaciones.AllowUserToDeleteRows = false;
            this.dgvCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCancelaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCancelaciones.Location = new System.Drawing.Point(3, 16);
            this.dgvCancelaciones.Name = "dgvCancelaciones";
            this.dgvCancelaciones.Size = new System.Drawing.Size(754, 179);
            this.dgvCancelaciones.TabIndex = 0;
            // 
            // FormAuditoriaOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBoxCancelaciones);
            this.Controls.Add(this.groupBoxAnulaciones);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Name = "FormAuditoriaOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoría de operaciones";
            this.Load += new System.EventHandler(this.FormAuditoriaOperaciones_Load);
            this.groupBoxAnulaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnulaciones)).EndInit();
            this.groupBoxCancelaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBoxAnulaciones;
        private System.Windows.Forms.DataGridView dgvAnulaciones;
        private System.Windows.Forms.GroupBox groupBoxCancelaciones;
        private System.Windows.Forms.DataGridView dgvCancelaciones;
    }
}
