namespace RestaurarTF
{
    partial class FormCaja
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.dgvCobros = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRendir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEstado.Location = new System.Drawing.Point(12, 9);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(129, 17);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Caja de hoy: --- ---";
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Location = new System.Drawing.Point(115, 40);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(100, 20);
            this.txtMontoInicial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto inicial:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(231, 38);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir caja";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.AllowUserToDeleteRows = false;
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Location = new System.Drawing.Point(16, 100);
            this.dgvCobros.MultiSelect = false;
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.ReadOnly = true;
            this.dgvCobros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCobros.Size = new System.Drawing.Size(544, 140);
            this.dgvCobros.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cobros de mozo no rendidos:";
            // 
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(16, 246);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(119, 23);
            this.btnRendir.TabIndex = 6;
            this.btnRendir.Text = "Rendir seleccionado";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(485, 38);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar caja";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Movimientos de caja:";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(16, 295);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(544, 130);
            this.dgvMovimientos.TabIndex = 9;
            // 
            // FormCaja
            // 
            this.ClientSize = new System.Drawing.Size(579, 437);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCobros);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMontoInicial);
            this.Controls.Add(this.lblEstado);
            this.Name = "FormCaja";
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.FormCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.DataGridView dgvCobros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvMovimientos;
    }
}
