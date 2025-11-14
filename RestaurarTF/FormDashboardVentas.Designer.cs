namespace RestaurarTF
{
    partial class FormDashboardVentas
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.header = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.chkDark = new System.Windows.Forms.CheckBox();
            this.chkPie3D = new System.Windows.Forms.CheckBox();
            this.nudTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cboRango = new System.Windows.Forms.ComboBox();
            this.lblRango = new System.Windows.Forms.Label();
            this.panelKpis = new System.Windows.Forms.Panel();
            this.kpi4 = new System.Windows.Forms.Panel();
            this.kpi4Value = new System.Windows.Forms.Label();
            this.kpi4Title = new System.Windows.Forms.Label();
            this.kpi3 = new System.Windows.Forms.Panel();
            this.kpi3Value = new System.Windows.Forms.Label();
            this.kpi3Title = new System.Windows.Forms.Label();
            this.kpi2 = new System.Windows.Forms.Panel();
            this.kpi2Value = new System.Windows.Forms.Label();
            this.kpi2Title = new System.Windows.Forms.Label();
            this.kpi1 = new System.Windows.Forms.Panel();
            this.kpi1Value = new System.Windows.Forms.Label();
            this.kpi1Title = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartTopProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMozos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            //this.chartComandasHora = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVentasDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMediosPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.header.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            this.panelKpis.SuspendLayout();
            this.kpi4.SuspendLayout();
            this.kpi3.SuspendLayout();
            this.kpi2.SuspendLayout();
            this.kpi1.SuspendLayout();
            this.panelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMozos)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.chartComandasHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.header.Controls.Add(this.lblTitulo);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.header.Size = new System.Drawing.Size(1200, 50);
            this.header.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1170, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard de Ventas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.btnAplicar);
            this.panelFiltros.Controls.Add(this.chkDark);
            this.panelFiltros.Controls.Add(this.chkPie3D);
            this.panelFiltros.Controls.Add(this.nudTopN);
            this.panelFiltros.Controls.Add(this.lblTopN);
            this.panelFiltros.Controls.Add(this.dtHasta);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtDesde);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.cboRango);
            this.panelFiltros.Controls.Add(this.lblRango);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 50);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.panelFiltros.Size = new System.Drawing.Size(1200, 60);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAplicar.Location = new System.Drawing.Point(1105, 16);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 27);
            this.btnAplicar.TabIndex = 10;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // chkDark
            // 
            this.chkDark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkDark.AutoSize = true;
            this.chkDark.Location = new System.Drawing.Point(1010, 20);
            this.chkDark.Name = "chkDark";
            this.chkDark.Size = new System.Drawing.Size(89, 19);
            this.chkDark.TabIndex = 9;
            this.chkDark.Text = "Tema oscuro";
            this.chkDark.UseVisualStyleBackColor = true;
            // 
            // chkPie3D
            // 
            this.chkPie3D.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkPie3D.AutoSize = true;
            this.chkPie3D.Location = new System.Drawing.Point(930, 20);
            this.chkPie3D.Name = "chkPie3D";
            this.chkPie3D.Size = new System.Drawing.Size(68, 19);
            this.chkPie3D.TabIndex = 8;
            this.chkPie3D.Text = "Pie 3D";
            this.chkPie3D.UseVisualStyleBackColor = true;
            // 
            // nudTopN
            // 
            this.nudTopN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTopN.Location = new System.Drawing.Point(482, 18);
            this.nudTopN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTopN.Name = "nudTopN";
            this.nudTopN.Size = new System.Drawing.Size(60, 23);
            this.nudTopN.TabIndex = 4;
            this.nudTopN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblTopN
            // 
            this.lblTopN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTopN.AutoSize = true;
            this.lblTopN.Location = new System.Drawing.Point(425, 21);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(51, 15);
            this.lblTopN.TabIndex = 3;
            this.lblTopN.Text = "Top N:";
            // 
            // dtHasta
            // 
            this.dtHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(835, 18);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(89, 23);
            this.dtHasta.TabIndex = 7;
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(789, 21);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(43, 15);
            this.lblHasta.TabIndex = 6;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtDesde
            // 
            this.dtDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(694, 18);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(89, 23);
            this.dtDesde.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(647, 21);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(45, 15);
            this.lblDesde.TabIndex = 4;
            this.lblDesde.Text = "Desde:";
            // 
            // cboRango
            // 
            this.cboRango.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRango.FormattingEnabled = true;
            this.cboRango.Items.AddRange(new object[] {
            "Hoy",
            "Semana",
            "Mes",
            "Año",
            "Personalizado"});
            this.cboRango.Location = new System.Drawing.Point(80, 17);
            this.cboRango.Name = "cboRango";
            this.cboRango.Size = new System.Drawing.Size(130, 23);
            this.cboRango.TabIndex = 1;
            // 
            // lblRango
            // 
            this.lblRango.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(18, 21);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(46, 15);
            this.lblRango.TabIndex = 0;
            this.lblRango.Text = "Rango:";
            // 
            // panelKpis
            // 
            this.panelKpis.Controls.Add(this.kpi4);
            this.panelKpis.Controls.Add(this.kpi3);
            this.panelKpis.Controls.Add(this.kpi2);
            this.panelKpis.Controls.Add(this.kpi1);
            this.panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpis.Location = new System.Drawing.Point(0, 110);
            this.panelKpis.Name = "panelKpis";
            this.panelKpis.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.panelKpis.Size = new System.Drawing.Size(1200, 75);
            this.panelKpis.TabIndex = 2;
            // 
            // kpi4
            // 
            this.kpi4.BackColor = System.Drawing.Color.White;
            this.kpi4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi4.Controls.Add(this.kpi4Value);
            this.kpi4.Controls.Add(this.kpi4Title);
            this.kpi4.Location = new System.Drawing.Point(627, 10);
            this.kpi4.Name = "kpi4";
            this.kpi4.Padding = new System.Windows.Forms.Padding(8);
            this.kpi4.Size = new System.Drawing.Size(195, 55);
            this.kpi4.TabIndex = 3;
            // 
            // kpi4Value
            // 
            this.kpi4Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi4Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi4Value.Location = new System.Drawing.Point(8, 26);
            this.kpi4Value.Name = "kpi4Value";
            this.kpi4Value.Size = new System.Drawing.Size(177, 21);
            this.kpi4Value.TabIndex = 1;
            this.kpi4Value.Text = "-";
            this.kpi4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi4Title
            // 
            this.kpi4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi4Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi4Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi4Title.Location = new System.Drawing.Point(8, 8);
            this.kpi4Title.Name = "kpi4Title";
            this.kpi4Title.Size = new System.Drawing.Size(177, 18);
            this.kpi4Title.TabIndex = 0;
            this.kpi4Title.Text = "Ticket promedio";
            // 
            // kpi3
            // 
            this.kpi3.BackColor = System.Drawing.Color.White;
            this.kpi3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi3.Controls.Add(this.kpi3Value);
            this.kpi3.Controls.Add(this.kpi3Title);
            this.kpi3.Location = new System.Drawing.Point(426, 10);
            this.kpi3.Name = "kpi3";
            this.kpi3.Padding = new System.Windows.Forms.Padding(8);
            this.kpi3.Size = new System.Drawing.Size(195, 55);
            this.kpi3.TabIndex = 2;
            // 
            // kpi3Value
            // 
            this.kpi3Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi3Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi3Value.Location = new System.Drawing.Point(8, 26);
            this.kpi3Value.Name = "kpi3Value";
            this.kpi3Value.Size = new System.Drawing.Size(177, 21);
            this.kpi3Value.TabIndex = 1;
            this.kpi3Value.Text = "-";
            this.kpi3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi3Title
            // 
            this.kpi3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi3Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi3Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi3Title.Location = new System.Drawing.Point(8, 8);
            this.kpi3Title.Name = "kpi3Title";
            this.kpi3Title.Size = new System.Drawing.Size(177, 18);
            this.kpi3Title.TabIndex = 0;
            this.kpi3Title.Text = "% Ocupación mesas";
            // 
            // kpi2
            // 
            this.kpi2.BackColor = System.Drawing.Color.White;
            this.kpi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi2.Controls.Add(this.kpi2Value);
            this.kpi2.Controls.Add(this.kpi2Title);
            this.kpi2.Location = new System.Drawing.Point(225, 10);
            this.kpi2.Name = "kpi2";
            this.kpi2.Padding = new System.Windows.Forms.Padding(8);
            this.kpi2.Size = new System.Drawing.Size(195, 55);
            this.kpi2.TabIndex = 1;
            // 
            // kpi2Value
            // 
            this.kpi2Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi2Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi2Value.Location = new System.Drawing.Point(8, 26);
            this.kpi2Value.Name = "kpi2Value";
            this.kpi2Value.Size = new System.Drawing.Size(177, 21);
            this.kpi2Value.TabIndex = 1;
            this.kpi2Value.Text = "-";
            this.kpi2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi2Title
            // 
            this.kpi2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi2Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi2Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi2Title.Location = new System.Drawing.Point(8, 8);
            this.kpi2Title.Name = "kpi2Title";
            this.kpi2Title.Size = new System.Drawing.Size(177, 18);
            this.kpi2Title.TabIndex = 0;
            this.kpi2Title.Text = "Cantidad de facturas";
            // 
            // kpi1
            // 
            this.kpi1.BackColor = System.Drawing.Color.White;
            this.kpi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi1.Controls.Add(this.kpi1Value);
            this.kpi1.Controls.Add(this.kpi1Title);
            this.kpi1.Location = new System.Drawing.Point(24, 10);
            this.kpi1.Name = "kpi1";
            this.kpi1.Padding = new System.Windows.Forms.Padding(8);
            this.kpi1.Size = new System.Drawing.Size(195, 55);
            this.kpi1.TabIndex = 0;
            // 
            // kpi1Value
            // 
            this.kpi1Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi1Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi1Value.Location = new System.Drawing.Point(8, 26);
            this.kpi1Value.Name = "kpi1Value";
            this.kpi1Value.Size = new System.Drawing.Size(177, 21);
            this.kpi1Value.TabIndex = 1;
            this.kpi1Value.Text = "-";
            this.kpi1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi1Title
            // 
            this.kpi1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi1Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi1Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi1Title.Location = new System.Drawing.Point(8, 8);
            this.kpi1Title.Name = "kpi1Title";
            this.kpi1Title.Size = new System.Drawing.Size(177, 18);
            this.kpi1Title.TabIndex = 0;
            this.kpi1Title.Text = "Ventas en el periodo ($)";
            // 
            // panelCharts
            // 
            // panelCharts
            this.panelCharts.ColumnCount = 2;
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.panelCharts.RowCount = 2;
            this.panelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.panelCharts.Controls.Add(this.chartTopProductos, 0, 0);   
            this.panelCharts.Controls.Add(this.chartMozos, 1, 0);  
            this.panelCharts.Controls.Add(this.chartVentasDia, 0, 1);   
            this.panelCharts.Controls.Add(this.chartMediosPago, 1, 1);   

            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharts.Location = new System.Drawing.Point(0, 185);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Size = new System.Drawing.Size(1200, 515);
            this.panelCharts.TabIndex = 3;

            // 
            // chartTopProductos
            // 
            this.chartTopProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTopProductos.Location = new System.Drawing.Point(3, 3);
            this.chartTopProductos.Name = "chartTopProductos";
            this.chartTopProductos.Size = new System.Drawing.Size(594, 164);
            this.chartTopProductos.TabIndex = 0;
            this.chartTopProductos.Text = "chartTopProductos";
            // 
            // chartMozos
            // 
            this.chartMozos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMozos.Location = new System.Drawing.Point(603, 3);
            this.chartMozos.Name = "chartMozos";
            this.chartMozos.Size = new System.Drawing.Size(594, 164);
            this.chartMozos.TabIndex = 1;
            this.chartMozos.Text = "chartMozos";
            // 
            // chartComandasHora
            // 
            //this.chartComandasHora.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.chartComandasHora.Location = new System.Drawing.Point(3, 173);
            //this.chartComandasHora.Name = "chartComandasHora";
            //this.chartComandasHora.Size = new System.Drawing.Size(594, 164);
            //this.chartComandasHora.TabIndex = 2;
            //this.chartComandasHora.Text = "chartComandasHora";
            // 
            // chartVentasDia
            // 
            this.chartVentasDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVentasDia.Location = new System.Drawing.Point(603, 173);
            this.chartVentasDia.Name = "chartVentasDia";
            this.chartVentasDia.Size = new System.Drawing.Size(594, 164);
            this.chartVentasDia.TabIndex = 3;
            this.chartVentasDia.Text = "chartVentasDia";
            // 
            // chartMediosPago
            // 
            this.chartMediosPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMediosPago.Location = new System.Drawing.Point(3, 343);
            this.chartMediosPago.Name = "chartMediosPago";
            this.chartMediosPago.Size = new System.Drawing.Size(594, 169);
            this.chartMediosPago.TabIndex = 4;
            this.chartMediosPago.Text = "chartMediosPago";
            // 
            // FormDashboardVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelCharts);
            this.Controls.Add(this.panelKpis);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.header);
            this.Name = "FormDashboardVentas";
            this.Text = "Dashboard de Ventas";
            this.header.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.panelKpis.ResumeLayout(false);
            this.kpi4.ResumeLayout(false);
            this.kpi3.ResumeLayout(false);
            this.kpi2.ResumeLayout(false);
            this.kpi1.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMozos)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.chartComandasHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.ComboBox cboRango;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.NumericUpDown nudTopN;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.CheckBox chkPie3D;
        private System.Windows.Forms.CheckBox chkDark;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Panel panelKpis;
        private System.Windows.Forms.Panel kpi4;
        private System.Windows.Forms.Label kpi4Value;
        private System.Windows.Forms.Label kpi4Title;
        private System.Windows.Forms.Panel kpi3;
        private System.Windows.Forms.Label kpi3Value;
        private System.Windows.Forms.Label kpi3Title;
        private System.Windows.Forms.Panel kpi2;
        private System.Windows.Forms.Label kpi2Value;
        private System.Windows.Forms.Label kpi2Title;
        private System.Windows.Forms.Panel kpi1;
        private System.Windows.Forms.Label kpi1Value;
        private System.Windows.Forms.Label kpi1Title;
        private System.Windows.Forms.TableLayoutPanel panelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMozos;
       // private System.Windows.Forms.DataVisualization.Charting.Chart chartComandasHora;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasDia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMediosPago;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
