namespace Vista
{
    partial class FormLogin
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
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnCancelar = new Button();
            this.lblUsuario = new Label();
            this.lblPassword = new Label();
            this.lblTitulo = new Label();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(80, 20);
            this.lblTitulo.Size = new System.Drawing.Size(200, 26);
            this.lblTitulo.Text = "Sistema CarFix - Login";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 80);
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.Text = "Usuario:";

            // txtUsuario
            this.txtUsuario.Location = new System.Drawing.Point(30, 100);
            this.txtUsuario.Size = new System.Drawing.Size(300, 20);
            this.txtUsuario.Text = "admin"; // Usuario por defecto para pruebas

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 140);
            this.lblPassword.Size = new System.Drawing.Size(64, 13);
            this.lblPassword.Text = "Contraseña:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(30, 160);
            this.txtPassword.Size = new System.Drawing.Size(300, 20);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Text = "admin123"; // Password por defecto para pruebas

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(130, 210);
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(220, 210);
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 260);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancelar);
            this.Text = "Login - CarFix";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancelar;
        private Label lblUsuario;
        private Label lblPassword;
        private Label lblTitulo;
    }
}