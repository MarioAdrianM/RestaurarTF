namespace RestaurarTF
{
    partial class FormAnularItemComanda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvComandas = new System.Windows.Forms.DataGridView();
            this.colComId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComMozo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.colDetLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComandas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvComandas
            // 
            this.dgvComandas.AllowUserToAddRows = false;
            this.dgvComandas.AllowUserToDeleteRows = false;
            this.dgvComandas.AllowUserToResizeRows = false;
            this.dgvComandas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvComandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colComId,
            this.colComMesa,
            this.colComMozo,
            this.colComEstado,
            this.colComFecha});
            this.dgvComandas.Location = new System.Drawing.Point(12, 12);
            this.dgvComandas.MultiSelect = false;
            this.dgvComandas.Name = "dgvComandas";
            this.dgvComandas.ReadOnly = true;
            this.dgvComandas.RowHeadersVisible = false;
            this.dgvComandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComandas.Size = new System.Drawing.Size(360, 360);
            this.dgvComandas.TabIndex = 0;
            this.dgvComandas.SelectionChanged += new System.EventHandler(this.dgvComandas_SelectionChanged);
            // 
            // colComId
            // 
            this.colComId.DataPropertyName = "Id";
            this.colComId.HeaderText = "Id";
            this.colComId.Name = "colComId";
            this.colComId.ReadOnly = true;
            this.colComId.Visible = false;
            // 
            // colComMesa
            // 
            this.colComMesa.DataPropertyName = "Id_Mesa";
            this.colComMesa.HeaderText = "Mesa";
            this.colComMesa.Name = "colComMesa";
            this.colComMesa.ReadOnly = true;
            this.colComMesa.Width = 50;
            // 
            // colComMozo
            // 
            this.colComMozo.DataPropertyName = "Mozo";
            this.colComMozo.HeaderText = "Mozo";
            this.colComMozo.Name = "colComMozo";
            this.colComMozo.ReadOnly = true;
            this.colComMozo.Width = 90;
            // 
            // colComEstado
            // 
            this.colComEstado.DataPropertyName = "Estado";
            this.colComEstado.HeaderText = "Estado";
            this.colComEstado.Name = "colComEstado";
            this.colComEstado.ReadOnly = true;
            this.colComEstado.Width = 80;
            // 
            // colComFecha
            // 
            this.colComFecha.DataPropertyName = "FechaHora";
            this.colComFecha.HeaderText = "Fecha/Hora";
            this.colComFecha.Name = "colComFecha";
            this.colComFecha.ReadOnly = true;
            this.colComFecha.Width = 120;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToResizeRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetLinea,
            this.colDetDesc,
            this.colDetCant,
            this.colDetPrecio,
            this.colDetSubtotal});
            this.dgvDetalles.Location = new System.Drawing.Point(378, 12);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(410, 222);
            this.dgvDetalles.TabIndex = 1;
            // 
            // colDetLinea
            // 
            this.colDetLinea.DataPropertyName = "Linea";
            this.colDetLinea.HeaderText = "Linea";
            this.colDetLinea.Name = "colDetLinea";
            this.colDetLinea.ReadOnly = true;
            this.colDetLinea.Width = 50;
            // 
            // colDetDesc
            // 
            this.colDetDesc.DataPropertyName = "Descripcion";
            this.colDetDesc.HeaderText = "Descripción";
            this.colDetDesc.Name = "colDetDesc";
            this.colDetDesc.ReadOnly = true;
            this.colDetDesc.Width = 160;
            // 
            // colDetCant
            // 
            this.colDetCant.DataPropertyName = "Cantidad";
            this.colDetCant.HeaderText = "Cant.";
            this.colDetCant.Name = "colDetCant";
            this.colDetCant.ReadOnly = true;
            this.colDetCant.Width = 50;
            // 
            // colDetPrecio
            // 
            this.colDetPrecio.DataPropertyName = "PrecioUnitario";
            this.colDetPrecio.HeaderText = "P.Unit";
            this.colDetPrecio.Name = "colDetPrecio";
            this.colDetPrecio.ReadOnly = true;
            this.colDetPrecio.Width = 70;
            // 
            // colDetSubtotal
            // 
            this.colDetSubtotal.DataPropertyName = "Subtotal";
            this.colDetSubtotal.HeaderText = "Subtotal";
            this.colDetSubtotal.Name = "colDetSubtotal";
            this.colDetSubtotal.ReadOnly = true;
            this.colDetSubtotal.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Location = new System.Drawing.Point(378, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motivo de anulación (obligatorio)";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMotivo.Location = new System.Drawing.Point(3, 16);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(404, 51);
            this.txtMotivo.TabIndex = 0;
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.Location = new System.Drawing.Point(632, 316);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 30);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "Anular ítem";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(713, 316);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 378);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 26);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FormAnularItemComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.dgvComandas);
            this.MinimizeBox = false;
            this.Name = "FormAnularItemComanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anular ítem de comanda";
            this.Load += new System.EventHandler(this.FormAnularItemComanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComandas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComandas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComMozo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComFecha;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSubtotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnActualizar;
    }
}
