namespace RestaurarTF
{
    partial class FormResumenCobrosMozo
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.dgvPorMozo = new System.Windows.Forms.DataGridView();
            this.dgvPorMedio = new System.Windows.Forms.DataGridView();
            this.lblPorMozo = new System.Windows.Forms.Label();
            this.lblPorMedio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorMozo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorMedio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(12, 9);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(145, 13);
            this.lblTotalGeneral.TabIndex = 0;
            this.lblTotalGeneral.Text = "Total pendiente general: $0";
            // 
            // dgvPorMozo
            // 
            this.dgvPorMozo.AllowUserToAddRows = false;
            this.dgvPorMozo.AllowUserToDeleteRows = false;
            this.dgvPorMozo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorMozo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorMozo.Location = new System.Drawing.Point(15, 50);
            this.dgvPorMozo.Name = "dgvPorMozo";
            this.dgvPorMozo.ReadOnly = true;
            this.dgvPorMozo.RowHeadersVisible = false;
            this.dgvPorMozo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorMozo.Size = new System.Drawing.Size(550, 150);
            this.dgvPorMozo.TabIndex = 1;
            // 
            // dgvPorMedio
            // 
            this.dgvPorMedio.AllowUserToAddRows = false;
            this.dgvPorMedio.AllowUserToDeleteRows = false;
            this.dgvPorMedio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorMedio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorMedio.Location = new System.Drawing.Point(15, 240);
            this.dgvPorMedio.Name = "dgvPorMedio";
            this.dgvPorMedio.ReadOnly = true;
            this.dgvPorMedio.RowHeadersVisible = false;
            this.dgvPorMedio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorMedio.Size = new System.Drawing.Size(550, 150);
            this.dgvPorMedio.TabIndex = 2;
            // 
            // lblPorMozo
            // 
            this.lblPorMozo.AutoSize = true;
            this.lblPorMozo.Location = new System.Drawing.Point(12, 34);
            this.lblPorMozo.Name = "lblPorMozo";
            this.lblPorMozo.Size = new System.Drawing.Size(97, 13);
            this.lblPorMozo.TabIndex = 3;
            this.lblPorMozo.Text = "Pendiente por mozo";
            // 
            // lblPorMedio
            // 
            this.lblPorMedio.AutoSize = true;
            this.lblPorMedio.Location = new System.Drawing.Point(12, 224);
            this.lblPorMedio.Name = "lblPorMedio";
            this.lblPorMedio.Size = new System.Drawing.Size(111, 13);
            this.lblPorMedio.TabIndex = 4;
            this.lblPorMedio.Text = "Pendiente por medio";
            // 
            // FormResumenCobrosMozo
            // 
            this.ClientSize = new System.Drawing.Size(584, 401);
            this.Controls.Add(this.lblPorMedio);
            this.Controls.Add(this.lblPorMozo);
            this.Controls.Add(this.dgvPorMedio);
            this.Controls.Add(this.dgvPorMozo);
            this.Controls.Add(this.lblTotalGeneral);
            this.Name = "FormResumenCobrosMozo";
            this.Text = "Resumen de cobros de mozo (pendientes)";
            this.Load += new System.EventHandler(this.FormResumenCobrosMozo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorMozo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorMedio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.DataGridView dgvPorMozo;
        private System.Windows.Forms.DataGridView dgvPorMedio;
        private System.Windows.Forms.Label lblPorMozo;
        private System.Windows.Forms.Label lblPorMedio;
    }
}
