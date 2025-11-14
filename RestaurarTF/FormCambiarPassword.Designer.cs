namespace RestaurarTF
{

    partial class FormCambiarPassword
    {
       // private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtActual;
        private System.Windows.Forms.TextBox txtNueva;
        private System.Windows.Forms.TextBox txtRepetir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;


        private void InitializeComponent()
        {
            this.txtActual = new System.Windows.Forms.TextBox();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.txtRepetir = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labels + textboxes
            // 
            this.lbl1.Text = "Actual:";
            this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.txtActual.Location = new System.Drawing.Point(140, 20);
            this.txtActual.PasswordChar = '*';

            this.lbl2.Text = "Nueva:";
            this.lbl2.Location = new System.Drawing.Point(20, 60);
            this.txtNueva.Location = new System.Drawing.Point(140, 60);
            this.txtNueva.PasswordChar = '*';

            this.lbl3.Text = "Repetir:";
            this.lbl3.Location = new System.Drawing.Point(20, 100);
            this.txtRepetir.Location = new System.Drawing.Point(140, 100);
            this.txtRepetir.PasswordChar = '*';

            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Location = new System.Drawing.Point(40, 140);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(160, 140);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtNueva);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtRepetir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
