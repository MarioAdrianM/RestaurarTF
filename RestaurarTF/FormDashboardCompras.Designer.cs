namespace RestaurarTF
{
    partial class FormDashboardCompras
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberar recursos.
        /// </summary>
        /// <param name="disposing"></param>
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
        /// Método necesario para admitir el Diseñador.
        /// </summary>
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
            this.kpi3 = new System.Windows.Forms.Panel();
            this.kpi3Value = new System.Windows.Forms.Label();
            this.kpi3Title = new System.Windows.Forms.Label();
            this.kpi2 = new System.Windows.Forms.Panel();
            this.kpi2Value = new System.Windows.Forms.Label();
            this.kpi2Title = new System.Windows.Forms.Label();
            this.kpi1 = new System.Windows.Forms.Panel();
            this.kpi1Value = new System.Windows.Forms.Label();
            this.kpi1Title = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.Panel();
            this.chartComprasFamilia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartComprasFamiliaTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.header.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            this.panelKpis.SuspendLayout();
            this.kpi3.SuspendLayout();
            this.kpi2.SuspendLayout();
            this.kpi1.SuspendLayout();
            this.panelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasFamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasFamiliaTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.header.Controls.Add(this.lblTitulo);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(13, 9, 13, 9);
            this.header.Size = new System.Drawing.Size(1029, 43);
            this.header.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1003, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard de Compras";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panelFiltros.Location = new System.Drawing.Point(0, 43);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.panelFiltros.Size = new System.Drawing.Size(1029, 52);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAplicar.Location = new System.Drawing.Point(750, 13);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(64, 23);
            this.btnAplicar.TabIndex = 10;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // chkDark
            // 
            this.chkDark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkDark.AutoSize = true;
            this.chkDark.Location = new System.Drawing.Point(941, 7);
            this.chkDark.Name = "chkDark";
            this.chkDark.Size = new System.Drawing.Size(88, 17);
            this.chkDark.TabIndex = 9;
            this.chkDark.Text = "Tema oscuro";
            this.chkDark.UseVisualStyleBackColor = true;
            // 
            // chkPie3D
            // 
            this.chkPie3D.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkPie3D.AutoSize = true;
            this.chkPie3D.Location = new System.Drawing.Point(867, 7);
            this.chkPie3D.Name = "chkPie3D";
            this.chkPie3D.Size = new System.Drawing.Size(68, 17);
            this.chkPie3D.TabIndex = 8;
            this.chkPie3D.Text = "Torta 3D";
            this.chkPie3D.UseVisualStyleBackColor = true;
            // 
            // nudTopN
            // 
            this.nudTopN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTopN.Location = new System.Drawing.Point(300, 16);
            this.nudTopN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTopN.Name = "nudTopN";
            this.nudTopN.Size = new System.Drawing.Size(54, 20);
            this.nudTopN.TabIndex = 3;
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
            this.lblTopN.Location = new System.Drawing.Point(254, 18);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(40, 13);
            this.lblTopN.TabIndex = 2;
            this.lblTopN.Text = "Top N:";
            // 
            // dtHasta
            // 
            this.dtHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(667, 13);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(77, 20);
            this.dtHasta.TabIndex = 7;
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(627, 15);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 6;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtDesde
            // 
            this.dtDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(546, 13);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(77, 20);
            this.dtDesde.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(506, 15);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
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
            this.cboRango.Location = new System.Drawing.Point(69, 15);
            this.cboRango.Name = "cboRango";
            this.cboRango.Size = new System.Drawing.Size(112, 21);
            this.cboRango.TabIndex = 1;
            // 
            // lblRango
            // 
            this.lblRango.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(15, 18);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(42, 13);
            this.lblRango.TabIndex = 0;
            this.lblRango.Text = "Rango:";
            // 
            // panelKpis
            // 
            this.panelKpis.Controls.Add(this.kpi3);
            this.panelKpis.Controls.Add(this.kpi2);
            this.panelKpis.Controls.Add(this.kpi1);
            this.panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpis.Location = new System.Drawing.Point(0, 95);
            this.panelKpis.Name = "panelKpis";
            this.panelKpis.Padding = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.panelKpis.Size = new System.Drawing.Size(1029, 65);
            this.panelKpis.TabIndex = 2;
            // 
            // kpi3
            // 
            this.kpi3.BackColor = System.Drawing.Color.White;
            this.kpi3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi3.Controls.Add(this.kpi3Value);
            this.kpi3.Controls.Add(this.kpi3Title);
            this.kpi3.Location = new System.Drawing.Point(365, 9);
            this.kpi3.Name = "kpi3";
            this.kpi3.Padding = new System.Windows.Forms.Padding(7);
            this.kpi3.Size = new System.Drawing.Size(167, 48);
            this.kpi3.TabIndex = 2;
            // 
            // kpi3Value
            // 
            this.kpi3Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi3Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi3Value.Location = new System.Drawing.Point(7, 21);
            this.kpi3Value.Name = "kpi3Value";
            this.kpi3Value.Size = new System.Drawing.Size(151, 18);
            this.kpi3Value.TabIndex = 1;
            this.kpi3Value.Text = "-";
            this.kpi3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi3Title
            // 
            this.kpi3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi3Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi3Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi3Title.Location = new System.Drawing.Point(7, 7);
            this.kpi3Title.Name = "kpi3Title";
            this.kpi3Title.Size = new System.Drawing.Size(151, 16);
            this.kpi3Title.TabIndex = 0;
            this.kpi3Title.Text = "Ticket promedio compra";
            // 
            // kpi2
            // 
            this.kpi2.BackColor = System.Drawing.Color.White;
            this.kpi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi2.Controls.Add(this.kpi2Value);
            this.kpi2.Controls.Add(this.kpi2Title);
            this.kpi2.Location = new System.Drawing.Point(193, 9);
            this.kpi2.Name = "kpi2";
            this.kpi2.Padding = new System.Windows.Forms.Padding(7);
            this.kpi2.Size = new System.Drawing.Size(167, 48);
            this.kpi2.TabIndex = 1;
            // 
            // kpi2Value
            // 
            this.kpi2Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi2Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi2Value.Location = new System.Drawing.Point(7, 21);
            this.kpi2Value.Name = "kpi2Value";
            this.kpi2Value.Size = new System.Drawing.Size(151, 18);
            this.kpi2Value.TabIndex = 1;
            this.kpi2Value.Text = "-";
            this.kpi2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi2Title
            // 
            this.kpi2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi2Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi2Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi2Title.Location = new System.Drawing.Point(7, 7);
            this.kpi2Title.Name = "kpi2Title";
            this.kpi2Title.Size = new System.Drawing.Size(151, 16);
            this.kpi2Title.TabIndex = 0;
            this.kpi2Title.Text = "Cantidad de compras";
            // 
            // kpi1
            // 
            this.kpi1.BackColor = System.Drawing.Color.White;
            this.kpi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpi1.Controls.Add(this.kpi1Value);
            this.kpi1.Controls.Add(this.kpi1Title);
            this.kpi1.Location = new System.Drawing.Point(21, 9);
            this.kpi1.Name = "kpi1";
            this.kpi1.Padding = new System.Windows.Forms.Padding(7);
            this.kpi1.Size = new System.Drawing.Size(167, 48);
            this.kpi1.TabIndex = 0;
            // 
            // kpi1Value
            // 
            this.kpi1Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpi1Value.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.kpi1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.kpi1Value.Location = new System.Drawing.Point(7, 21);
            this.kpi1Value.Name = "kpi1Value";
            this.kpi1Value.Size = new System.Drawing.Size(151, 18);
            this.kpi1Value.TabIndex = 1;
            this.kpi1Value.Text = "-";
            this.kpi1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpi1Title
            // 
            this.kpi1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpi1Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpi1Title.ForeColor = System.Drawing.Color.Gray;
            this.kpi1Title.Location = new System.Drawing.Point(7, 7);
            this.kpi1Title.Name = "kpi1Title";
            this.kpi1Title.Size = new System.Drawing.Size(151, 16);
            this.kpi1Title.TabIndex = 0;
            this.kpi1Title.Text = "Total compras ($)";
            
            // panelCharts
            this.panelCharts.Controls.Add(this.chartComprasFamiliaTotal);
            this.panelCharts.Controls.Add(this.chartComprasFamilia);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharts.Location = new System.Drawing.Point(0, 160);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Padding = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.panelCharts.Size = new System.Drawing.Size(1029, 447);
            this.panelCharts.TabIndex = 3;

            // 
            // chartComprasFamilia
            // 
            // 
            // chartComprasFamilia
            // 
            this.chartComprasFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartComprasFamilia.Location = new System.Drawing.Point(13, 4);
            this.chartComprasFamilia.Name = "chartComprasFamilia";
            this.chartComprasFamilia.Size = new System.Drawing.Size(1003, 220);
            this.chartComprasFamilia.TabIndex = 0;
            this.chartComprasFamilia.Text = "chartComprasFamilia";
            //
            // chartComprasFamiliaTotal
            //
            this.chartComprasFamiliaTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartComprasFamiliaTotal.Location = new System.Drawing.Point(13, 224);
            this.chartComprasFamiliaTotal.Name = "chartComprasFamiliaTotal";
            this.chartComprasFamiliaTotal.Size = new System.Drawing.Size(1003, 227);
            this.chartComprasFamiliaTotal.TabIndex = 1;
            this.chartComprasFamiliaTotal.Text = "chartComprasFamiliaTotal";
            // 
            // FormDashboardCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 607);
            this.Controls.Add(this.panelCharts);
            this.Controls.Add(this.panelKpis);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.header);
            this.Name = "FormDashboardCompras";
            this.Text = "Dashboard de Compras";
            this.header.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.panelKpis.ResumeLayout(false);
            this.kpi3.ResumeLayout(false);
            this.kpi2.ResumeLayout(false);
            this.kpi1.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasFamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasFamiliaTotal)).EndInit();
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
        private System.Windows.Forms.Panel kpi3;
        private System.Windows.Forms.Label kpi3Value;
        private System.Windows.Forms.Label kpi3Title;
        private System.Windows.Forms.Panel kpi2;
        private System.Windows.Forms.Label kpi2Value;
        private System.Windows.Forms.Label kpi2Title;
        private System.Windows.Forms.Panel kpi1;
        private System.Windows.Forms.Label kpi1Value;
        private System.Windows.Forms.Label kpi1Title;
        private System.Windows.Forms.Panel panelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartComprasFamilia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartComprasFamiliaTotal;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
