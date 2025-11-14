namespace RestaurarTF
{
    partial class FormSalonMozo
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.dgvMesas = new System.Windows.Forms.DataGridView();
            this.colIdMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(131, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mesas del salón";
            // 
            // lblMozo
            // 
            this.lblMozo.AutoSize = true;
            this.lblMozo.Location = new System.Drawing.Point(12, 35);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(39, 13);
            this.lblMozo.TabIndex = 1;
            this.lblMozo.Text = "Mozo: ";
            // 
            // dgvMesas
            // 
            this.dgvMesas.AllowUserToAddRows = false;
            this.dgvMesas.AllowUserToDeleteRows = false;
            this.dgvMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdMesa,
            this.colCodigo,
            this.colNumero,
            this.colSector,
            this.colCapacidad,
            this.colEstado});
            this.dgvMesas.Location = new System.Drawing.Point(15, 60);
            this.dgvMesas.MultiSelect = false;
            this.dgvMesas.Name = "dgvMesas";
            this.dgvMesas.ReadOnly = true;
            this.dgvMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMesas.Size = new System.Drawing.Size(520, 240);
            this.dgvMesas.TabIndex = 2;
            this.dgvMesas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMesas_CellDoubleClick);
            // 
            // colIdMesa
            // 
            this.colIdMesa.DataPropertyName = "Id";
            this.colIdMesa.HeaderText = "Id";
            this.colIdMesa.Name = "colIdMesa";
            this.colIdMesa.ReadOnly = true;
            this.colIdMesa.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 70;
            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "Numero";
            this.colNumero.HeaderText = "N°";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 50;
            // 
            // colSector
            // 
            this.colSector.DataPropertyName = "Sector";
            this.colSector.HeaderText = "Sector";
            this.colSector.Name = "colSector";
            this.colSector.ReadOnly = true;
            this.colSector.Width = 80;
            // 
            // colCapacidad
            // 
            this.colCapacidad.DataPropertyName = "Capacidad";
            this.colCapacidad.HeaderText = "Cap.";
            this.colCapacidad.Name = "colCapacidad";
            this.colCapacidad.ReadOnly = true;
            this.colCapacidad.Width = 50;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 120;
            // 
            // btnAtender
            // 
            this.btnAtender.Location = new System.Drawing.Point(15, 306);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(110, 23);
            this.btnAtender.TabIndex = 3;
            this.btnAtender.Text = "Atender mesa";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(425, 306);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 23);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.Location = new System.Drawing.Point(131, 306);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(177, 23);
            this.btnLiberar.TabIndex = 5;
            this.btnLiberar.Text = "Liberar mesa (sin consumo)";
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // FormSalonMozo
            // 
            this.ClientSize = new System.Drawing.Size(549, 341);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.dgvMesas);
            this.Controls.Add(this.lblMozo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLiberar);
            this.Name = "FormSalonMozo";
            this.Text = "Salón - Mesas";
            this.Load += new System.EventHandler(this.FormSalonMozo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.DataGridView dgvMesas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnLiberar;
    }
}
