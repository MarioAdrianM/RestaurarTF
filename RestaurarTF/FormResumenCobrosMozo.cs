using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL_Negocio;
using BE;

namespace RestaurarTF
{
    public partial class FormResumenCobrosMozo : Form
    {
        private readonly BLLCobroMozo _bll;

        public FormResumenCobrosMozo()
        {
            InitializeComponent();
            _bll = new BLLCobroMozo();
        }

        private void FormResumenCobrosMozo_Load(object sender, EventArgs e)
        {
            CargarResumen();
        }

        private void CargarResumen()
        {
            try
            {
                // usamos lo que ya tenés
                List<BECobroMozo> lista = _bll.ListarNoRendidos();

                // agrupado por mozo
                var porMozo = lista
                    .GroupBy(x => x.Mozo ?? "(sin mozo)")
                    .Select(g => new
                    {
                        Mozo = g.Key,
                        CantidadCobros = g.Count(),
                        Total = g.Sum(x => x.Importe)
                    })
                    .OrderByDescending(x => x.Total)
                    .ToList();

                dgvPorMozo.AutoGenerateColumns = false;
                dgvPorMozo.DataSource = porMozo;

                // agrupado por medio
                var porMedio = lista
                    .GroupBy(x => x.Medio ?? "(sin medio)")
                    .Select(g => new
                    {
                        Medio = g.Key,
                        CantidadCobros = g.Count(),
                        Total = g.Sum(x => x.Importe)
                    })
                    .OrderByDescending(x => x.Total)
                    .ToList();

                dgvPorMedio.AutoGenerateColumns = false;
                dgvPorMedio.DataSource = porMedio;

                lblTotalGeneral.Text = $"Total pendiente general: ${lista.Sum(x => x.Importe):N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar resumen: " + ex.Message);
            }
        }
    }
}
