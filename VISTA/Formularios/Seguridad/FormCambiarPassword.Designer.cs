namespace Vista
{
    partial class FormCambiarPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtPasswordActual = new TextBox();
            this.txtPasswordNuevo = new TextBox();
            this.txtConfirmarPassword = new TextBox();
            this.btnCambiar = new Button();
            this.btnCancelar = new Button();
            this.lblPasswordActual = new Label();
            this.lblPasswordNuevo = new Label();
            this.lblConfirmarPassword = new Label();
            this.SuspendLayout();

            // Labels y TextBoxes
            this.lblPasswordActual.Text = "Contraseña Actual:";
            this.lblPasswordActual.Location = new System.Drawing.Point(12, 15);
            this.lblPasswordActual.Size = new System.Drawing.Size(120, 23);

            this.txtPasswordActual.Location = new System.Drawing.Point(140, 12);
            this.txtPasswordActual.Size = new System.Drawing.Size(200, 20);
            this.txtPasswordActual.UseSystemPasswordChar = true;

            this.lblPasswordNuevo.Text = "Nueva Contraseña:";
            this.lblPasswordNuevo.Location = new System.Drawing.Point(12, 45);
            this.lblPasswordNuevo.Size = new System.Drawing.Size(120, 23);

            this.txtPasswordNuevo.Location = new System.Drawing.Point(140, 42);
            this.txtPasswordNuevo.Size = new System.Drawing.Size(200, 20);
            this.txtPasswordNuevo.UseSystemPasswordChar = true;

            this.lblConfirmarPassword.Text = "Confirmar Nueva:";
            this.lblConfirmarPassword.Location = new System.Drawing.Point(12, 75);
            this.lblConfirmarPassword.Size = new System.Drawing.Size(120, 23);

            this.txtConfirmarPassword.Location = new System.Drawing.Point(140, 72);
            this.txtConfirmarPassword.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmarPassword.UseSystemPasswordChar = true;

            // Botones
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.Location = new System.Drawing.Point(140, 110);
            this.btnCambiar.Size = new System.Drawing.Size(75, 23);
            this.btnCambiar.Click += btnCambiar_Click;

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(265, 110);
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Click += btnCancelar_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(370, 160);
            this.Controls.Add(this.lblPasswordActual);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.lblPasswordNuevo);
            this.Controls.Add(this.txtPasswordNuevo);
            this.Controls.Add(this.lblConfirmarPassword);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.btnCancelar);
            this.Text = "Cambiar Contraseña";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }
        #endregion

        private TextBox txtPasswordActual, txtPasswordNuevo, txtConfirmarPassword;
        private Button btnCambiar, btnCancelar;
        private Label lblPasswordActual, lblPasswordNuevo, lblConfirmarPassword;
    }
}