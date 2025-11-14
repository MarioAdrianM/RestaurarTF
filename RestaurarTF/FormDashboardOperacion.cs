using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL_Negocio;

namespace RestaurarTF
{
    public partial class FormDashboardOperacion : Form
    {
        private readonly DashboardBLL _bll = new DashboardBLL();

        public FormDashboardOperacion()
        {
            InitializeComponent();
            this.Load += FormDashboardOperacion_Load;
        }

        private void FormDashboardOperacion_Load(object sender, EventArgs e)
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
           
            SetupChart(chartEstadoMesas, "Estado de mesas", SeriesChartType.Pie, false);
            chartEstadoMesas.ChartAreas["Area"].Area3DStyle.Enable3D = chkPie3D.Checked;

            SetupChart(chartOcupacion, "Ocupación actual", SeriesChartType.Column, true);

            SetupChart(chartComandasHora, "Comandas por hora", SeriesChartType.Column, false);
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
            var desde = dtDesde.Value.Date;
            var hasta = dtHasta.Value.Date.AddDays(1).AddTicks(-1);

            var est = _bll.EstadoMesas(); 
            var denom = Math.Max(1, est.libres + est.ocupadas);
            var ocup = (double)est.ocupadas / denom;

            kpi1Value.Text = (ocup * 100).ToString("0.0") + "%";
            kpi2Value.Text = est.libres.ToString("#,0");
            kpi3Value.Text = est.ocupadas.ToString("#,0");

            BindPie(chartEstadoMesas,
                new[] { "Libres", "Ocupadas", "Bloqueadas" },
                new[] { (double)est.libres, (double)est.ocupadas, (double)est.bloqueadas });

            BindColumn(chartOcupacion,
                new[] { "Ocupadas", "Libres" },
                new[] { (double)est.ocupadas, (double)est.libres },
                "Mesas");

            var horas = _bll.ComandasPorHora(desde, hasta);
            BindColumn(chartComandasHora,
                horas.Select(x => x.hora.ToString("00") + "h").ToArray(),
                horas.Select(x => (double)x.cantidad).ToArray(),
                "Cantidad");
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

        private void ApplyTheme(bool dark)
        {
            var card = dark ? Color.FromArgb(50, 51, 53) : Color.White;
            var fg = dark ? Color.Gainsboro : Color.FromArgb(40, 44, 52);
            var grid = dark ? Color.DimGray : Color.Gainsboro;

            this.BackColor = dark ? Color.FromArgb(28, 29, 31) : SystemColors.Control;
            header.BackColor = dark ? Color.FromArgb(44, 45, 47) : Color.FromArgb(245, 246, 248);
            lblTitulo.ForeColor = fg;

            foreach (var p in new[] { kpi1, kpi2, kpi3 })
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

            style(chartEstadoMesas);
            style(chartOcupacion);
            style(chartComandasHora);
        }
    }
}
