namespace Vista
{
    partial class FormDatosVehiculos
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbDueño = new ComboBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtDominio = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAño = new TextBox();
            SuspendLayout();
            // 
            // cmbDueño
            // 
            cmbDueño.FormattingEnabled = true;
            cmbDueño.Location = new Point(227, 327);
            cmbDueño.Margin = new Padding(3, 4, 3, 4);
            cmbDueño.Name = "cmbDueño";
            cmbDueño.Size = new Size(114, 28);
            cmbDueño.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(115, 433);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 67);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 12F);
            btnAceptar.Location = new Point(256, 433);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(91, 67);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtDominio
            // 
            txtDominio.Location = new Point(227, 256);
            txtDominio.Margin = new Padding(3, 4, 3, 4);
            txtDominio.Name = "txtDominio";
            txtDominio.Size = new Size(114, 27);
            txtDominio.TabIndex = 3;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(227, 113);
            txtModelo.Margin = new Padding(3, 4, 3, 4);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(114, 27);
            txtModelo.TabIndex = 1;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(227, 49);
            txtMarca.Margin = new Padding(3, 4, 3, 4);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(114, 27);
            txtMarca.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(122, 253);
            label5.Name = "label5";
            label5.Size = new Size(88, 28);
            label5.TabIndex = 40;
            label5.Text = "Dominio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(122, 329);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 38;
            label4.Text = "Dueño";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(122, 181);
            label3.Name = "label3";
            label3.Size = new Size(48, 28);
            label3.TabIndex = 37;
            label3.Text = "Año";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(122, 111);
            label2.Name = "label2";
            label2.Size = new Size(81, 28);
            label2.TabIndex = 35;
            label2.Text = "Modelo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(122, 47);
            label1.Name = "label1";
            label1.Size = new Size(66, 28);
            label1.TabIndex = 33;
            label1.Text = "Marca";
            // 
            // txtAño
            // 
            txtAño.Location = new Point(227, 184);
            txtAño.Margin = new Padding(3, 4, 3, 4);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(114, 27);
            txtAño.TabIndex = 2;
            // 
            // FormDatosVehiculos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 548);
            Controls.Add(txtAño);
            Controls.Add(cmbDueño);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDominio);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDatosVehiculos";
            Text = "Gestion Vehiculos";
            Load += FormDatosVehiculos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDueño;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtDominio;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtAño;
    }
}