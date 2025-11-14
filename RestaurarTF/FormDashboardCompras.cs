using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormDashboardCompras : Form
    {
        private readonly DashboardBLL _bll = new DashboardBLL();

        public FormDashboardCompras()
        {
            InitializeComponent();
            this.Load += FormDashboardCompras_Load;
        }

        private void FormDashboardCompras_Load(object sender, EventArgs e)
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
                SetupChart(chartComprasFamilia, "Compras por familia (%)", SeriesChartType.Pie, false);
                chartComprasFamilia.ChartAreas["Area"].Area3DStyle.Enable3D = true;
                var s = chartComprasFamilia.Series["Datos"];
                s["PieDrawingStyle"] = "Concave";
            }
            else
            {
                SetupChart(chartComprasFamilia, "Compras por familia (%)", SeriesChartType.Column, true);
            }
            SetupChart(chartComprasFamiliaTotal, "Compras por familia ($)", SeriesChartType.Column, true);
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
            area.AxisY.LabelStyle.Format = "#,0.##";
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
                LabelFormat = "#,0.##",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BorderWidth = (type == SeriesChartType.Line) ? 3 : 1
            };
            chart.Series.Add(series);

            chart.Titles.Add(new Title(title, Docking.Top,
                new Font("Segoe UI", 11F, FontStyle.Bold), Color.FromArgb(40, 44, 52)));
        }

        private void ApplyTheme(bool dark)
        {
            Color back, fore, cardBack;
            if (dark)
            {
                back = Color.FromArgb(36, 37, 38);
                fore = Color.White;
                cardBack = Color.FromArgb(52, 53, 54);
            }
            else
            {
                back = Color.White;
                fore = Color.FromArgb(40, 44, 52);
                cardBack = Color.White;
            }

            this.BackColor = back;
            header.BackColor = dark ? Color.FromArgb(45, 45, 48) : Color.FromArgb(245, 246, 248);
            lblTitulo.ForeColor = fore;

            foreach (var panel in new[] { kpi1, kpi2, kpi3 })
            {
                panel.BackColor = cardBack;
            }

            foreach (var lbl in new[] { kpi1Title, kpi2Title, kpi3Title })
            {
                lbl.ForeColor = dark ? Color.Gainsboro : Color.Gray;
            }

            foreach (var lbl in new[] { kpi1Value, kpi2Value, kpi3Value })
            {
                lbl.ForeColor = fore;
            }
        }

        private void ApplyPresetRange(string preset)
        {
            var hoy = DateTime.Today;
            switch (preset)
            {
                case "Hoy":
                    dtDesde.Value = hoy;
                    dtHasta.Value = hoy;
                    break;
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
                default:
                    break;
            }
        }

        private void RefreshAll()
        {
            int topN = (int)nudTopN.Value;
            var desde = dtDesde.Value.Date;
            var hasta = dtHasta.Value.Date.AddDays(1).AddTicks(-1);

            var k = _bll.ComprasResumen(desde, hasta);
            kpi1Value.Text = k.total.ToString("#,0");         
            kpi2Value.Text = k.cantidad.ToString("#,0");      
            kpi3Value.Text = k.ticket.ToString("#,0.00");     


            var familias = _bll.ComprasPorFamilia(desde, hasta);
            if (topN > 0)
                familias = familias.Take(topN).ToList();

            var labels = familias.Select(x => x.familia).ToArray();
            var valoresPct = familias.Select(x => x.percent).ToArray();
            var valoresTotales = familias.Select(x => (double)x.total).ToArray();


            if (chartComprasFamilia.Series["Datos"].ChartType == SeriesChartType.Pie)
            {
                BindPie(chartComprasFamilia, labels, valoresPct);
            }
            else
            {
                BindColumn(chartComprasFamilia, labels, valoresPct, "% del total");
            }

            BindColumn(chartComprasFamiliaTotal, labels, valoresTotales, "Importe $");
        }


        private void BindPie(Chart chart, string[] categorias, double[] valores)
        {
            var s = chart.Series["Datos"]; s.Points.Clear();
            for (int i = 0; i < categorias.Length && i < valores.Length; i++)
            {
                var p = s.Points.Add(valores[i]);
                p.AxisLabel = categorias[i];
                p.LegendText = categorias[i];
                p.ToolTip = categorias[i] + ": " + valores[i].ToString("0.##") + "%";
            }
        }

        private void BindColumn(Chart chart, string[] categorias, double[] valores, string legend)
        {
            var s = chart.Series["Datos"]; s.Points.Clear();
            for (int i = 0; i < categorias.Length && i < valores.Length; i++)
            {
                var p = s.Points.Add(valores[i]);
                p.AxisLabel = categorias[i];
                p.ToolTip = categorias[i] + ": " + valores[i].ToString("0.##") + "%";
            }
            s.LegendText = legend;
        }
    }
}
