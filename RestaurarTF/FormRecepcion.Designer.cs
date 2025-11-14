using System;
using System.Windows.Forms;

namespace RestaurarTF
{
    partial class FormRecepcion
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblReservas;
        private DataGridView dgvReservas;
        private Label lblEspera;
        private DataGridView dgvEspera;
        private Button btnMarcarLlegadaReserva;
        private Button btnLlamarEspera;
        private Button btnAtenderEspera;
        private Button btnCerrar;

        // columnas reservas
        private DataGridViewTextBoxColumn colResId;
        private DataGridViewTextBoxColumn colResHora;
        private DataGridViewTextBoxColumn colResCliente;
        private DataGridViewTextBoxColumn colResPersonas;
        private DataGridViewTextBoxColumn colResMesa;
        private DataGridViewTextBoxColumn colResObs;

        // columnas espera
        private DataGridViewTextBoxColumn colEspId;
        private DataGridViewTextBoxColumn colEspCliente;
        private DataGridViewTextBoxColumn colEspPersonas;
        private DataGridViewTextBoxColumn colEspHora;
        private DataGridViewTextBoxColumn colEspEstado;
        private DataGridViewTextBoxColumn colEspObs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReservas = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.colResId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEspera = new System.Windows.Forms.Label();
            this.dgvEspera = new System.Windows.Forms.DataGridView();
            this.colEspId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMarcarLlegadaReserva = new System.Windows.Forms.Button();
            this.btnLlamarEspera = new System.Windows.Forms.Button();
            this.btnAtenderEspera = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReservas
            // 
            this.lblReservas.AutoSize = true;
            this.lblReservas.Location = new System.Drawing.Point(12, 9);
            this.lblReservas.Name = "lblReservas";
            this.lblReservas.Size = new System.Drawing.Size(95, 13);
            this.lblReservas.TabIndex = 0;
            this.lblReservas.Text = "Reservas de hoy:";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.AutoGenerateColumns = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResId,
            this.colResHora,
            this.colResCliente,
            this.colResPersonas,
            this.colResMesa,
            this.colResObs});
            this.dgvReservas.Location = new System.Drawing.Point(15, 25);
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(540, 150);
            this.dgvReservas.TabIndex = 1;
            // 
            // colResId
            // 
            this.colResId.DataPropertyName = "Id";
            this.colResId.HeaderText = "Id";
            this.colResId.Name = "colResId";
            this.colResId.ReadOnly = true;
            this.colResId.Visible = false;
            // 
            // colResHora
            // 
            this.colResHora.DataPropertyName = "Hora";
            this.colResHora.HeaderText = "Hora";
            this.colResHora.Name = "colResHora";
            this.colResHora.ReadOnly = true;
            this.colResHora.Width = 50;
            // 
            // colResCliente
            // 
            this.colResCliente.DataPropertyName = "NombreCliente";
            this.colResCliente.HeaderText = "Cliente";
            this.colResCliente.Name = "colResCliente";
            this.colResCliente.ReadOnly = true;
            this.colResCliente.Width = 150;
            // 
            // colResPersonas
            // 
            this.colResPersonas.DataPropertyName = "CantidadPersonas";
            this.colResPersonas.HeaderText = "Pax";
            this.colResPersonas.Name = "colResPersonas";
            this.colResPersonas.ReadOnly = true;
            this.colResPersonas.Width = 40;
            // 
            // colResMesa
            // 
            this.colResMesa.DataPropertyName = "Mesa";
            this.colResMesa.HeaderText = "Mesa";
            this.colResMesa.Name = "colResMesa";
            this.colResMesa.ReadOnly = true;
            this.colResMesa.Width = 60;
            // 
            // colResObs
            // 
            this.colResObs.DataPropertyName = "Observaciones";
            this.colResObs.HeaderText = "Obs.";
            this.colResObs.Name = "colResObs";
            this.colResObs.ReadOnly = true;
            this.colResObs.Width = 180;
            // 
            // lblEspera
            // 
            this.lblEspera.AutoSize = true;
            this.lblEspera.Location = new System.Drawing.Point(12, 188);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(95, 13);
            this.lblEspera.TabIndex = 2;
            this.lblEspera.Text = "Clientes en espera:";
            // 
            // dgvEspera
            // 
            this.dgvEspera.AllowUserToAddRows = false;
            this.dgvEspera.AllowUserToDeleteRows = false;
            this.dgvEspera.AutoGenerateColumns = false;
            this.dgvEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEspId,
            this.colEspCliente,
            this.colEspPersonas,
            this.colEspHora,
            this.colEspEstado,
            this.colEspObs});
            this.dgvEspera.Location = new System.Drawing.Point(15, 204);
            this.dgvEspera.MultiSelect = false;
            this.dgvEspera.Name = "dgvEspera";
            this.dgvEspera.ReadOnly = true;
            this.dgvEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspera.Size = new System.Drawing.Size(540, 150);
            this.dgvEspera.TabIndex = 3;
            // 
            // colEspId
            // 
            this.colEspId.DataPropertyName = "Id";
            this.colEspId.HeaderText = "Id";
            this.colEspId.Name = "colEspId";
            this.colEspId.ReadOnly = true;
            this.colEspId.Visible = false;
            // 
            // colEspCliente
            // 
            this.colEspCliente.DataPropertyName = "NombreCliente";
            this.colEspCliente.HeaderText = "Cliente";
            this.colEspCliente.Name = "colEspCliente";
            this.colEspCliente.ReadOnly = true;
            this.colEspCliente.Width = 150;
            // 
            // colEspPersonas
            // 
            this.colEspPersonas.DataPropertyName = "CantidadPersonas";
            this.colEspPersonas.HeaderText = "Pax";
            this.colEspPersonas.Name = "colEspPersonas";
            this.colEspPersonas.ReadOnly = true;
            this.colEspPersonas.Width = 40;
            // 
            // colEspHora
            // 
            this.colEspHora.DataPropertyName = "Llegó";
            this.colEspHora.HeaderText = "Ingreso";
            this.colEspHora.Name = "colEspHora";
            this.colEspHora.ReadOnly = true;
            this.colEspHora.Width = 60;
            // 
            // colEspEstado
            // 
            this.colEspEstado.DataPropertyName = "Estado";
            this.colEspEstado.HeaderText = "Estado";
            this.colEspEstado.Name = "colEspEstado";
            this.colEspEstado.ReadOnly = true;
            this.colEspEstado.Width = 80;
            // 
            // colEspObs
            // 
            this.colEspObs.DataPropertyName = "Observaciones";
            this.colEspObs.HeaderText = "Obs.";
            this.colEspObs.Name = "colEspObs";
            this.colEspObs.ReadOnly = true;
            this.colEspObs.Width = 180;
            // 
            // btnMarcarLlegadaReserva
            // 
            this.btnMarcarLlegadaReserva.Location = new System.Drawing.Point(570, 25);
            this.btnMarcarLlegadaReserva.Name = "btnMarcarLlegadaReserva";
            this.btnMarcarLlegadaReserva.Size = new System.Drawing.Size(140, 23);
            this.btnMarcarLlegadaReserva.TabIndex = 4;
            this.btnMarcarLlegadaReserva.Text = "Llegó la reserva";
            this.btnMarcarLlegadaReserva.UseVisualStyleBackColor = true;
            this.btnMarcarLlegadaReserva.Click += new System.EventHandler(this.btnMarcarLlegadaReserva_Click);
            // 
            // btnLlamarEspera
            // 
            this.btnLlamarEspera.Location = new System.Drawing.Point(570, 204);
            this.btnLlamarEspera.Name = "btnLlamarEspera";
            this.btnLlamarEspera.Size = new System.Drawing.Size(140, 23);
            this.btnLlamarEspera.TabIndex = 5;
            this.btnLlamarEspera.Text = "Llamar de espera";
            this.btnLlamarEspera.UseVisualStyleBackColor = true;
            this.btnLlamarEspera.Click += new System.EventHandler(this.btnLlamarEspera_Click);
            // 
            // btnAtenderEspera
            // 
            this.btnAtenderEspera.Location = new System.Drawing.Point(570, 233);
            this.btnAtenderEspera.Name = "btnAtenderEspera";
            this.btnAtenderEspera.Size = new System.Drawing.Size(140, 23);
            this.btnAtenderEspera.TabIndex = 6;
            this.btnAtenderEspera.Text = "Asignar mesa ahora";
            this.btnAtenderEspera.UseVisualStyleBackColor = true;
            this.btnAtenderEspera.Click += new System.EventHandler(this.btnAtenderEspera_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(570, 331);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormRecepcion
            // 
            this.ClientSize = new System.Drawing.Size(722, 366);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAtenderEspera);
            this.Controls.Add(this.btnLlamarEspera);
            this.Controls.Add(this.btnMarcarLlegadaReserva);
            this.Controls.Add(this.dgvEspera);
            this.Controls.Add(this.lblEspera);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.lblReservas);
            this.Name = "FormRecepcion";
            this.Text = "Recepción";
            this.Load += new System.EventHandler(this.FormRecepcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
