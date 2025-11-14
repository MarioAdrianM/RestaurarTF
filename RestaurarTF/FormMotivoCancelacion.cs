using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RestaurarTF
{
    public partial class FormMotivoCancelacion : Form
    {
        public string Motivo => txt.Text.Trim();

        public FormMotivoCancelacion()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("El motivo es obligatorio.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
