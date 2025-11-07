namespace RestaurarTF
{
    partial class FormRendicionCobrosMozo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCobros = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdComanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMozo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRendirSeleccionados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.AllowUserToDeleteRows = false;
            this.dgvCobros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colId,
            this.colIdComanda,
            this.colFechaHora,
            this.colMozo,
            this.colMedio,
            this.colImporte});
            this.dgvCobros.Location = new System.Drawing.Point(12, 12);
            this.dgvCobros.MultiSelect = false;
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.RowHeadersVisible = false;
            this.dgvCobros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCobros.Size = new System.Drawing.Size(560, 280);
            this.dgvCobros.TabIndex = 0;
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "";
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.Width = 30;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colIdComanda
            // 
            this.colIdComanda.DataPropertyName = "Id_Comanda";
            this.colIdComanda.HeaderText = "Comanda";
            this.colIdComanda.Name = "colIdComanda";
            this.colIdComanda.ReadOnly = true;
            this.colIdComanda.Width = 80;
            // 
            // colFechaHora
            // 
            this.colFechaHora.DataPropertyName = "FechaHora";
            this.colFechaHora.HeaderText = "Fecha";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            this.colFechaHora.Width = 130;
            // 
            // colMozo
            // 
            this.colMozo.DataPropertyName = "Mozo";
            this.colMozo.HeaderText = "Mozo";
            this.colMozo.Name = "colMozo";
            this.colMozo.ReadOnly = true;
            this.colMozo.Width = 120;
            // 
            // colMedio
            // 
            this.colMedio.DataPropertyName = "Medio";
            this.colMedio.HeaderText = "Medio";
            this.colMedio.Name = "colMedio";
            this.colMedio.ReadOnly = true;
            this.colMedio.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Importe";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.Width = 80;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 305);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total pendiente: $0,00";
            // 
            // btnRendirSeleccionados
            // 
            this.btnRendirSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRendirSeleccionados.Location = new System.Drawing.Point(397, 300);
            this.btnRendirSeleccionados.Name = "btnRendirSeleccionados";
            this.btnRendirSeleccionados.Size = new System.Drawing.Size(175, 23);
            this.btnRendirSeleccionados.TabIndex = 2;
            this.btnRendirSeleccionados.Text = "Rendir seleccionados";
            this.btnRendirSeleccionados.UseVisualStyleBackColor = true;
            this.btnRendirSeleccionados.Click += new System.EventHandler(this.btnRendirSeleccionados_Click);
            // 
            // FormRendicionCobrosMozo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.btnRendirSeleccionados);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCobros);
            this.Name = "FormRendicionCobrosMozo";
            this.Text = "Rendición de cobros de mozo";
            this.Load += new System.EventHandler(this.FormRendicionCobrosMozo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCobros;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRendirSeleccionados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdComanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMozo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
    }
}
