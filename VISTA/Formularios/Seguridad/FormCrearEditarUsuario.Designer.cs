using Entidades.Core;

namespace Vista
{
    partial class FormCrearEditarUsuario
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
            this.txtUsuario = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmarPassword = new TextBox();
            this.chkActivo = new CheckBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.lblUsuario = new Label();
            this.lblEmail = new Label();
            this.lblPassword = new Label();
            this.lblConfirmarPassword = new Label();
            this.SuspendLayout();

            // Labels y TextBoxes
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new System.Drawing.Point(12, 15);
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);

            this.txtUsuario.Location = new System.Drawing.Point(120, 12);
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(12, 45);
            this.lblEmail.Size = new System.Drawing.Size(100, 23);

            this.txtEmail.Location = new System.Drawing.Point(120, 42);
            this.txtEmail.Size = new System.Drawing.Size(200, 20);

            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Location = new System.Drawing.Point(12, 75);
            this.lblPassword.Size = new System.Drawing.Size(100, 23);

            this.txtPassword.Location = new System.Drawing.Point(120, 72);
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblConfirmarPassword.Text = "Confirmar:";
            this.lblConfirmarPassword.Location = new System.Drawing.Point(12, 105);
            this.lblConfirmarPassword.Size = new System.Drawing.Size(100, 23);

            this.txtConfirmarPassword.Location = new System.Drawing.Point(120, 102);
            this.txtConfirmarPassword.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmarPassword.UseSystemPasswordChar = true;

            this.chkActivo.Text = "Usuario Activo";
            this.chkActivo.Location = new System.Drawing.Point(120, 135);
            this.chkActivo.Size = new System.Drawing.Size(200, 24);
            this.chkActivo.Checked = true;

            // Botones
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(120, 170);
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.Click += btnGuardar_Click;

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(245, 170);
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Click += btnCancelar_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmarPassword);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsuario, txtEmail, txtPassword, txtConfirmarPassword;
        private CheckBox chkActivo;
        private Button btnGuardar, btnCancelar;
        private Label lblUsuario, lblEmail, lblPassword, lblConfirmarPassword;
        private Usuario usuarioAEditar;
        private bool esEdicion;
    }
}