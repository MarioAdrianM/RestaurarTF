using System;
using System.Windows.Forms;

namespace RestaurarTF
{
    partial class FormReservas
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvReservas;
        private Panel panelEdicion;
        private Label lblFecha;
        private Label lblDuracion;
        private Label lblPersonas;
        private Label lblMesa;
        private Label lblEstado;
        private Label lblNombre;
        private Label lblTelefono;
        private Label lblObs;
        private DateTimePicker dtpFechaHora;
        private NumericUpDown nudDuracion;
        private NumericUpDown nudPersonas;
        private ComboBox cmbMesa;
        private ComboBox cmbEstado;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtObs;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnMarcarAtendida;
        private Button btnCancelar;
        private Button btnEliminar;
        private Button btnTomarDeEspera;
        private Button btnListaEspera;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colPersonas;
        private DataGridViewTextBoxColumn colMesa;
        private DataGridViewTextBoxColumn colEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.panelEdicion = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblObs = new System.Windows.Forms.Label();

            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.nudPersonas = new System.Windows.Forms.NumericUpDown();
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtObs = new System.Windows.Forms.TextBox();

            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnMarcarAtendida = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnTomarDeEspera = new System.Windows.Forms.Button();
            this.btnListaEspera = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.panelEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.AutoGenerateColumns = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colHora,
                this.colCliente,
                this.colPersonas,
                this.colMesa,
                this.colEstado
            });
            this.dgvReservas.Location = new System.Drawing.Point(12, 12);
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(500, 200);
            this.dgvReservas.TabIndex = 0;
            this.dgvReservas.SelectionChanged += new System.EventHandler(this.dgvReservas_SelectionChanged);

            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colHora
            // 
            this.colHora.DataPropertyName = "FechaHora";
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            this.colHora.Width = 60;
            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "NombreCliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 140;
            // 
            // colPersonas
            // 
            this.colPersonas.DataPropertyName = "CantidadPersonas";
            this.colPersonas.HeaderText = "Pax";
            this.colPersonas.Name = "colPersonas";
            this.colPersonas.ReadOnly = true;
            this.colPersonas.Width = 40;
            // 
            // colMesa
            // 
            this.colMesa.DataPropertyName = "IdMesa";
            this.colMesa.HeaderText = "Mesa";
            this.colMesa.Name = "colMesa";
            this.colMesa.ReadOnly = true;
            this.colMesa.Width = 60;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 80;

            // 
            // panelEdicion
            // 
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdicion.Controls.Add(this.lblFecha);
            this.panelEdicion.Controls.Add(this.lblDuracion);
            this.panelEdicion.Controls.Add(this.lblPersonas);
            this.panelEdicion.Controls.Add(this.lblMesa);
            this.panelEdicion.Controls.Add(this.lblEstado);
            this.panelEdicion.Controls.Add(this.lblNombre);
            this.panelEdicion.Controls.Add(this.lblTelefono);
            this.panelEdicion.Controls.Add(this.lblObs);
            this.panelEdicion.Controls.Add(this.dtpFechaHora);
            this.panelEdicion.Controls.Add(this.nudDuracion);
            this.panelEdicion.Controls.Add(this.nudPersonas);
            this.panelEdicion.Controls.Add(this.cmbMesa);
            this.panelEdicion.Controls.Add(this.cmbEstado);
            this.panelEdicion.Controls.Add(this.txtNombre);
            this.panelEdicion.Controls.Add(this.txtTelefono);
            this.panelEdicion.Controls.Add(this.txtObs);
            this.panelEdicion.Location = new System.Drawing.Point(12, 218);
            this.panelEdicion.Name = "panelEdicion";
            this.panelEdicion.Size = new System.Drawing.Size(500, 200);
            this.panelEdicion.TabIndex = 1;

            // labels
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(10, 10);
            this.lblFecha.Text = "Fecha / hora:";
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(10, 40);
            this.lblDuracion.Text = "Duración (min):";
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Location = new System.Drawing.Point(10, 70);
            this.lblPersonas.Text = "Personas:";
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(10, 100);
            this.lblMesa.Text = "Mesa:";
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(10, 130);
            this.lblEstado.Text = "Estado:";
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(250, 10);
            this.lblNombre.Text = "Nombre cliente:";
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(250, 40);
            this.lblTelefono.Text = "Teléfono:";
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(250, 70);
            this.lblObs.Text = "Observaciones:";

            // dtpFechaHora
            this.dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHora.Location = new System.Drawing.Point(100, 7);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(130, 20);
            this.dtpFechaHora.ValueChanged += new System.EventHandler(this.dtpFechaHora_ValueChanged);

            // nudDuracion
            this.nudDuracion.Location = new System.Drawing.Point(100, 37);
            this.nudDuracion.Maximum = 300;
            this.nudDuracion.Minimum = 30;
            this.nudDuracion.Value = 90;
            this.nudDuracion.ValueChanged += new System.EventHandler(this.nudDuracion_ValueChanged);

            // nudPersonas
            this.nudPersonas.Location = new System.Drawing.Point(100, 67);
            this.nudPersonas.Minimum = 1;
            this.nudPersonas.Maximum = 20;
            this.nudPersonas.Value = 2;
            this.nudPersonas.ValueChanged += new System.EventHandler(this.nudPersonas_ValueChanged);

            // cmbMesa
            this.cmbMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa.Location = new System.Drawing.Point(100, 97);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(130, 21);

            // cmbEstado
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Location = new System.Drawing.Point(100, 127);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(130, 21);

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(345, 7);
            this.txtNombre.Size = new System.Drawing.Size(140, 20);

            // txtTelefono
            this.txtTelefono.Location = new System.Drawing.Point(345, 37);
            this.txtTelefono.Size = new System.Drawing.Size(140, 20);

            // txtObs
            this.txtObs.Location = new System.Drawing.Point(253, 86);
            this.txtObs.Multiline = true;
            this.txtObs.Size = new System.Drawing.Size(232, 80);

            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(530, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 23);
            this.btnNuevo.Text = "Nueva reserva";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(530, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 23);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // btnMarcarAtendida
            // 
            this.btnMarcarAtendida.Location = new System.Drawing.Point(530, 70);
            this.btnMarcarAtendida.Name = "btnMarcarAtendida";
            this.btnMarcarAtendida.Size = new System.Drawing.Size(120, 23);
            this.btnMarcarAtendida.Text = "Llegó / Atender";
            this.btnMarcarAtendida.UseVisualStyleBackColor = true;
            this.btnMarcarAtendida.Click += new System.EventHandler(this.btnMarcarAtendida_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(530, 99);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 23);
            this.btnCancelar.Text = "Cancelar edición";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(530, 128);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 23);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // btnTomarDeEspera
            // 
            this.btnTomarDeEspera.Location = new System.Drawing.Point(530, 157);
            this.btnTomarDeEspera.Name = "btnTomarDeEspera";
            this.btnTomarDeEspera.Size = new System.Drawing.Size(120, 23);
            this.btnTomarDeEspera.Text = "Tomar de espera";
            this.btnTomarDeEspera.UseVisualStyleBackColor = true;
            this.btnTomarDeEspera.Click += new System.EventHandler(this.btnTomarDeEspera_Click);

            // 
            // btnListaEspera
            // 
            this.btnListaEspera.Location = new System.Drawing.Point(530, 186);
            this.btnListaEspera.Name = "btnListaEspera";
            this.btnListaEspera.Size = new System.Drawing.Size(120, 23);
            this.btnListaEspera.Text = "Ver lista de espera";
            this.btnListaEspera.UseVisualStyleBackColor = true;
            this.btnListaEspera.Click += new System.EventHandler(this.btnListaEspera_Click);

            // 
            // FormReservas
            // 
            this.ClientSize = new System.Drawing.Size(670, 430);
            this.Controls.Add(this.btnListaEspera);
            this.Controls.Add(this.btnTomarDeEspera);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnMarcarAtendida);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.panelEdicion);
            this.Controls.Add(this.dgvReservas);
            this.Name = "FormReservas";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.FormReservas_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.panelEdicion.ResumeLayout(false);
            this.panelEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
