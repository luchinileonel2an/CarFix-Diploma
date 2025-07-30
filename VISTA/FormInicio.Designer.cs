namespace Vista
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            label1 = new Label();
            btnTecnicos = new Button();
            btnVehiculos = new Button();
            btnTickets = new Button();
            btnClientes = new Button();
            groupBox2 = new GroupBox();
            panel1 = new Panel();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(39, 31);
            label1.Name = "label1";
            label1.Size = new Size(216, 37);
            label1.TabIndex = 0;
            label1.Text = "Panel de Gestion";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnTecnicos
            // 
            btnTecnicos.Cursor = Cursors.Hand;
            btnTecnicos.Font = new Font("Segoe UI", 12F);
            btnTecnicos.Location = new Point(577, 31);
            btnTecnicos.Name = "btnTecnicos";
            btnTecnicos.Size = new Size(149, 40);
            btnTecnicos.TabIndex = 3;
            btnTecnicos.Text = "Tecnicos";
            btnTecnicos.UseVisualStyleBackColor = true;
            btnTecnicos.Click += btnTecnicos_Click;
            // 
            // btnVehiculos
            // 
            btnVehiculos.Cursor = Cursors.Hand;
            btnVehiculos.Font = new Font("Segoe UI", 12F);
            btnVehiculos.Location = new Point(422, 31);
            btnVehiculos.Name = "btnVehiculos";
            btnVehiculos.Size = new Size(149, 40);
            btnVehiculos.TabIndex = 2;
            btnVehiculos.Text = "Vehiculos";
            btnVehiculos.UseVisualStyleBackColor = true;
            btnVehiculos.Click += btnVehiculos_Click;
            // 
            // btnTickets
            // 
            btnTickets.Cursor = Cursors.Hand;
            btnTickets.Font = new Font("Segoe UI", 12F);
            btnTickets.Location = new Point(732, 31);
            btnTickets.Name = "btnTickets";
            btnTickets.Size = new Size(157, 40);
            btnTickets.TabIndex = 4;
            btnTickets.Text = "Tickets de Trabajo";
            btnTickets.UseVisualStyleBackColor = true;
            btnTickets.Click += btnTickets_Click;
            // 
            // btnClientes
            // 
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.Location = new Point(267, 31);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(149, 40);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel1);
            groupBox2.Location = new Point(39, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1019, 487);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1013, 465);
            panel1.TabIndex = 0;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 567);
            Controls.Add(groupBox2);
            Controls.Add(btnTecnicos);
            Controls.Add(btnClientes);
            Controls.Add(btnTickets);
            Controls.Add(btnVehiculos);
            Controls.Add(label1);
            Name = "FormInicio";
            Text = "Inicio";
            Load += FormInicio_Load;
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnTickets;
        private Button btnClientes;
        private Button btnTecnicos;
        private Button btnVehiculos;
        private GroupBox groupBox2;
        private Panel panel1;
    }
}
