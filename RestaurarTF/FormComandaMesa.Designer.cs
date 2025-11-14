namespace RestaurarTF
{
    partial class FormComandaMesa
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblMesa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMozo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colProdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colDetLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSolicitarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMesa.Location = new System.Drawing.Point(12, 9);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(62, 17);
            this.lblMesa.TabIndex = 0;
            this.lblMesa.Text = "Mesa: -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mozo";
            // 
            // txtMozo
            // 
            this.txtMozo.Location = new System.Drawing.Point(211, 9);
            this.txtMozo.Name = "txtMozo";
            this.txtMozo.ReadOnly = true;
            this.txtMozo.Size = new System.Drawing.Size(132, 20);
            this.txtMozo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Productos:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProdId,
            this.colProdNombre,
            this.colProdCategoria,
            this.colProdPrecio});
            this.dgvProductos.Location = new System.Drawing.Point(16, 55);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(457, 150);
            this.dgvProductos.TabIndex = 4;
            // 
            // colProdId
            // 
            this.colProdId.DataPropertyName = "Id";
            this.colProdId.HeaderText = "Id";
            this.colProdId.Name = "colProdId";
            this.colProdId.ReadOnly = true;
            this.colProdId.Visible = false;
            // 
            // colProdNombre
            // 
            this.colProdNombre.DataPropertyName = "Nombre";
            this.colProdNombre.HeaderText = "Producto";
            this.colProdNombre.Name = "colProdNombre";
            this.colProdNombre.ReadOnly = true;
            this.colProdNombre.Width = 180;
            // 
            // colProdCategoria
            // 
            this.colProdCategoria.DataPropertyName = "Categoria";
            this.colProdCategoria.HeaderText = "Categoría";
            this.colProdCategoria.Name = "colProdCategoria";
            this.colProdCategoria.ReadOnly = true;
            // 
            // colProdPrecio
            // 
            this.colProdPrecio.DataPropertyName = "Precio";
            this.colProdPrecio.HeaderText = "Precio";
            this.colProdPrecio.Name = "colProdPrecio";
            this.colProdPrecio.ReadOnly = true;
            this.colProdPrecio.Width = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Detalle comanda:";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetLinea,
            this.colDetProducto,
            this.colDetCant,
            this.colDetPrecio,
            this.colDetSubtotal,
            this.colDetEstado});
            this.dgvDetalle.Location = new System.Drawing.Point(16, 241);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(457, 150);
            this.dgvDetalle.TabIndex = 6;
            // 
            // colDetLinea
            // 
            this.colDetLinea.DataPropertyName = "Linea";
            this.colDetLinea.HeaderText = "Linea";
            this.colDetLinea.Name = "colDetLinea";
            this.colDetLinea.ReadOnly = true;
            this.colDetLinea.Visible = false;
            // 
            // colDetProducto
            // 
            this.colDetProducto.DataPropertyName = "Producto";
            this.colDetProducto.HeaderText = "Producto";
            this.colDetProducto.Name = "colDetProducto";
            this.colDetProducto.ReadOnly = true;
            this.colDetProducto.Width = 160;
            // 
            // colDetCant
            // 
            this.colDetCant.DataPropertyName = "Cant";
            this.colDetCant.HeaderText = "Cant.";
            this.colDetCant.Name = "colDetCant";
            this.colDetCant.ReadOnly = true;
            this.colDetCant.Width = 50;
            // 
            // colDetPrecio
            // 
            this.colDetPrecio.DataPropertyName = "P_Unit";
            this.colDetPrecio.HeaderText = "P.Unit";
            this.colDetPrecio.Name = "colDetPrecio";
            this.colDetPrecio.ReadOnly = true;
            this.colDetPrecio.Width = 60;
            // 
            // colDetSubtotal
            // 
            this.colDetSubtotal.DataPropertyName = "Subtotal";
            this.colDetSubtotal.HeaderText = "Subtotal";
            this.colDetSubtotal.Name = "colDetSubtotal";
            this.colDetSubtotal.ReadOnly = true;
            this.colDetSubtotal.Width = 70;
            // 
            // colDetEstado
            // 
            this.colDetEstado.DataPropertyName = "Estado";
            this.colDetEstado.HeaderText = "Estado";
            this.colDetEstado.Name = "colDetEstado";
            this.colDetEstado.ReadOnly = true;
            this.colDetEstado.Width = 80;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(479, 98);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(94, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar >>";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(479, 55);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(94, 20);
            this.nudCantidad.TabIndex = 8;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cantidad:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(13, 404);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 17);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total: $";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(479, 368);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(94, 23);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Enviar a cocina";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(479, 241);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(94, 23);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "<< Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnSolicitarFactura
            // 
            this.btnSolicitarFactura.Location = new System.Drawing.Point(479, 339);
            this.btnSolicitarFactura.Name = "btnSolicitarFactura";
            this.btnSolicitarFactura.Size = new System.Drawing.Size(94, 23);
            this.btnSolicitarFactura.TabIndex = 13;
            this.btnSolicitarFactura.Text = "Solicitar factura";
            this.btnSolicitarFactura.UseVisualStyleBackColor = true;
            this.btnSolicitarFactura.Click += new System.EventHandler(this.btnSolicitarFactura_Click);
            // 
            // FormComandaMesa
            // 
            this.ClientSize = new System.Drawing.Size(585, 432);
            this.Controls.Add(this.btnSolicitarFactura);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMozo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMesa);
            this.Name = "FormComandaMesa";
            this.Text = "Comanda de Mesa";
            this.Load += new System.EventHandler(this.FormComandaMesa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMozo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetEstado;
        private System.Windows.Forms.Button btnSolicitarFactura;
    }
}
