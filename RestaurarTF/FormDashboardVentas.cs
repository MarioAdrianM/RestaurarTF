using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormDashboardVentas : Form
    {
        private readonly DashboardBLL _bll = new DashboardBLL();

        public FormDashboardVentas()
        {
            InitializeComponent();
            this.Load += FormDashboardVentas_Load;
        }

        private void FormDashboardVentas_Load(object sender, EventArgs e)
        {
            cboRango.SelectedIndex = 0; 
            ApplyPresetRange("Hoy");

            cboRango.SelectedIndexChanged += (s, ev) =>
            {
                var sel = cboRango.SelectedItem?.ToString();
                if (sel == "Personalizado")
                {
                    dtDesde.Enabled = dtHasta.Enabled = true;
                }
                else
                {
                    dtDesde.Enabled = dtHasta.Enabled = false;
                    ApplyPresetRange(sel);
                }
                RefreshAll();
            };

            nudTopN.ValueChanged += (s, ev) => RefreshAll();
            chkPie3D.CheckedChanged += (s, ev) => { ConfigureCharts(); RefreshAll(); };
            chkDark.CheckedChanged += (s, ev) => ApplyTheme(chkDark.Checked);

            ConfigureCharts();
            RefreshAll();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void ConfigureCharts()
        {
            if (chkPie3D.Checked)
            {
                SetupChart(chartTopProductos, "Top productos (torta 3D)", SeriesChartType.Pie, false);
                chartTopProductos.ChartAreas["Area"].Area3DStyle.Enable3D = true;
                var s = chartTopProductos.Series["Datos"];
                s["PieDrawingStyle"] = "Concave";
            }
            else
            {
                SetupChart(chartTopProductos, "Top productos (cantidad)", SeriesChartType.Bar, true);
            }

            SetupChart(chartMozos, "Mozos por facturación", SeriesChartType.Column, true);

           // SetupChart(chartComandasHora, "Comandas por hora", SeriesChartType.Column, false);

            SetupChart(chartVentasDia, "Ventas por día", SeriesChartType.Line, false);
            SetupChart(chartMediosPago, "Ventas por medio de pago", SeriesChartType.Pie, false);
            chartMediosPago.ChartAreas["Area"].Area3DStyle.Enable3D = chkPie3D.Checked;
            var serieMedios = chartMediosPago.Series["Datos"];
            serieMedios["PieDrawingStyle"] = "Concave";

        }

        private void SetupChart(Chart chart, string title, SeriesChartType type, bool horizontal)
        {
            chart.BackColor = Color.White;
            chart.Padding = new Padding(8);
            chart.BorderlineColor = Color.Gainsboro;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            var area = new ChartArea("Area");
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Format = "#,0";
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.LabelStyle.Angle = horizontal ? 0 : -45;
            chart.ChartAreas.Add(area);

            var legend = new Legend("Legend")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 8F)
            };
            chart.Legends.Add(legend);

            var series = new Series("Datos")
            {
                ChartType = type,
                ChartArea = "Area",
                Legend = "Legend",
                IsValueShownAsLabel = true,
                LabelFormat = "#,0",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BorderWidth = (type == SeriesChartType.Line) ? 3 : 1
            };
            chart.Series.Add(series);

            chart.Titles.Add(new Title(title, Docking.Top,
                new Font("Segoe UI", 11F, FontStyle.Bold), Color.FromArgb(40, 44, 52)));
        }

        private void ApplyPresetRange(string preset)
        {
            var hoy = DateTime.Today;
            switch (preset)
            {
                case "Hoy":
                    dtDesde.Value = hoy; dtHasta.Value = hoy; break;
                case "Semana":
                    int delta = ((int)hoy.DayOfWeek == 0) ? 6 : (int)hoy.DayOfWeek - 1;
                    dtDesde.Value = hoy.AddDays(-delta);
                    dtHasta.Value = dtDesde.Value.AddDays(6);
                    break;
                case "Mes":
                    dtDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
                    dtHasta.Value = dtDesde.Value.AddMonths(1).AddDays(-1);
                    break;
                case "Año":
                    dtDesde.Value = new DateTime(hoy.Year, 1, 1);
                    dtHasta.Value = new DateTime(hoy.Year, 12, 31);
                    break;
                default: break;
            }
        }
        private void RefreshAll()
        {
            int topN = (int)nudTopN.Value;
            var desde = dtDesde.Value.Date;
            var hasta = dtHasta.Value.Date.AddDays(1).AddTicks(-1);

            var tk = _bll.TicketPromedioRango(desde, hasta);
            kpi1Value.Text = tk.total.ToString("#,0");        
            kpi2Value.Text = tk.cantidad.ToString("#,0");   
            var est = _bll.EstadoMesas();
            var denom = Math.Max(1, est.ocupadas + est.libres);
            kpi3Value.Text = ((double)est.ocupadas / denom * 100).ToString("0.0") + "%";
            kpi4Value.Text = tk.ticket.ToString("#,0.00");

            var top = _bll.TopProductos(desde, hasta, topN);
            if (chartTopProductos.Series["Datos"].ChartType == SeriesChartType.Pie)
            {
                BindPie(chartTopProductos,
                    top.Select(x => x.producto).ToArray(),
                    top.Select(x => (double)x.monto).ToArray());
            }
            else
            {
                BindColumn(chartTopProductos,
                    top.Select(x => x.producto).ToArray(),
                    top.Select(x => (double)x.cantidad).ToArray(),
                    "Cantidad");
            }

            var mozos = _bll.MozosTop(desde, hasta, topN);
            BindColumn(chartMozos,
                mozos.Select(x => x.mozo).ToArray(),
                mozos.Select(x => (double)x.total).ToArray(),
                "Facturación $");

            //var horas = _bll.ComandasPorHora(desde, hasta);
            //BindColumn(chartComandasHora,
            //    horas.Select(x => x.hora.ToString("00") + "h").ToArray(),
            //    horas.Select(x => (double)x.cantidad).ToArray(),
            //    "Cantidad");

            var ventas = _bll.VentasPorDia(desde, hasta);
            BindLine(chartVentasDia,
                ventas.Select(x => x.fecha.ToString("dd/MM")).ToArray(),
                ventas.Select(x => (double)x.total).ToArray(),
                "Ventas $");

            var medios = _bll.VentasPorMedioPago(desde, hasta);
            BindPie(
                chartMediosPago,
                medios.Select(m => m.medio).ToArray(),
                medios.Select(m => (double)m.total).ToArray()
            );

        }
        private void BindPie(Chart chart, string[] categorias, double[] valores)
        {
            var s = chart.Series["Datos"]; s.Points.Clear();
            for (int i = 0; i < categorias.Length && i < valores.Length; i++)
            {
                var p = s.Points.Add(valores[i]);
                p.AxisLabel = categorias[i];
                p.LegendText = categorias[i];
                p.ToolTip = categorias[i] + ": " + valores[i].ToString("#,0");
            }
        }

        private void BindColumn(Chart chart, string[] categorias, double[] valores, string legend)
        {
            var s = chart.Series["Datos"]; s.Points.Clear(); s.LegendText = legend;
            for (int i = 0; i < categorias.Length && i < valores.Length; i++)
            {
                var dp = s.Points.Add(valores[i]);
                dp.AxisLabel = categorias[i];
                dp.ToolTip = categorias[i] + ": " + valores[i].ToString("#,0");
            }
        }

        private void BindLine(Chart chart, string[] x, double[] y, string legend)
        {
            var s = chart.Series["Datos"]; s.ChartType = SeriesChartType.Line;
            s.Points.Clear(); s.LegendText = legend;
            for (int i = 0; i < x.Length && i < y.Length; i++)
            {
                var dp = s.Points.Add(y[i]);
                dp.AxisLabel = x[i];
                dp.ToolTip = x[i] + ": " + y[i].ToString("#,0");
            }
        }

        private void ApplyTheme(bool dark)
        {
            var card = dark ? Color.FromArgb(50, 51, 53) : Color.White;
            var fg = dark ? Color.Gainsboro : Color.FromArgb(40, 44, 52);
            var grid = dark ? Color.DimGray : Color.Gainsboro;

            this.BackColor = dark ? Color.FromArgb(28, 29, 31) : SystemColors.Control;
            header.BackColor = dark ? Color.FromArgb(44, 45, 47) : Color.FromArgb(245, 246, 248);
            lblTitulo.ForeColor = fg;

            foreach (var p in new[] { kpi1, kpi2, kpi3, kpi4 })
            {
                p.BackColor = card;
                foreach (var lbl in p.Controls.OfType<Label>()) lbl.ForeColor = fg;
            }

            void style(Chart c)
            {
                c.BackColor = card;
                var a = c.ChartAreas["Area"];
                a.BackColor = card;
                a.AxisX.LabelStyle.ForeColor = fg;
                a.AxisY.LabelStyle.ForeColor = fg;
                a.AxisY.MajorGrid.LineColor = grid;
                foreach (var t in c.Titles) t.ForeColor = fg;
                foreach (var lg in c.Legends) lg.ForeColor = fg;
            }

            style(chartTopProductos);
            style(chartMozos);
            //style(chartComandasHora);
            style(chartVentasDia);

            style(chartMediosPago);


        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormDashboardVentas_Load_1(object sender, EventArgs e)
        {

        }
    }
}
