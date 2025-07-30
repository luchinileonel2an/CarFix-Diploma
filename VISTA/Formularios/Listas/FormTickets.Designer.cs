namespace Vista
{
    partial class FormTickets
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
            dgvTickets = new DataGridView();
            btnSalir = new Button();
            btnEliminarTicket = new Button();
            btnModTicket = new Button();
            btnAgregarTicket = new Button();
            label1 = new Label();
            btnDetalles = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(14, 56);
            dgvTickets.Margin = new Padding(3, 4, 3, 4);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 51;
            dgvTickets.Size = new Size(887, 488);
            dgvTickets.TabIndex = 0;
            dgvTickets.SelectionChanged += dgvTickets_SelectionChanged;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Location = new Point(815, 553);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminarTicket
            // 
            btnEliminarTicket.Cursor = Cursors.Hand;
            btnEliminarTicket.Location = new Point(106, 553);
            btnEliminarTicket.Margin = new Padding(3, 4, 3, 4);
            btnEliminarTicket.Name = "btnEliminarTicket";
            btnEliminarTicket.Size = new Size(86, 31);
            btnEliminarTicket.TabIndex = 2;
            btnEliminarTicket.Text = "Eliminar";
            btnEliminarTicket.UseVisualStyleBackColor = true;
            btnEliminarTicket.Click += btnEliminarTicket_Click;
            // 
            // btnModTicket
            // 
            btnModTicket.Cursor = Cursors.Hand;
            btnModTicket.Location = new Point(14, 553);
            btnModTicket.Margin = new Padding(3, 4, 3, 4);
            btnModTicket.Name = "btnModTicket";
            btnModTicket.Size = new Size(86, 31);
            btnModTicket.TabIndex = 3;
            btnModTicket.Text = "Modificar";
            btnModTicket.UseVisualStyleBackColor = true;
            btnModTicket.Click += btnModTicket_Click;
            // 
            // btnAgregarTicket
            // 
            btnAgregarTicket.Cursor = Cursors.Hand;
            btnAgregarTicket.Location = new Point(199, 553);
            btnAgregarTicket.Margin = new Padding(3, 4, 3, 4);
            btnAgregarTicket.Name = "btnAgregarTicket";
            btnAgregarTicket.Size = new Size(86, 31);
            btnAgregarTicket.TabIndex = 1;
            btnAgregarTicket.Text = "Agregar";
            btnAgregarTicket.UseVisualStyleBackColor = true;
            btnAgregarTicket.Click += btnAgregarTicket_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 15;
            label1.Text = "Lista de Tickets";
            // 
            // btnDetalles
            // 
            btnDetalles.Cursor = Cursors.Hand;
            btnDetalles.Location = new Point(713, 555);
            btnDetalles.Name = "btnDetalles";
            btnDetalles.Size = new Size(96, 29);
            btnDetalles.TabIndex = 16;
            btnDetalles.Text = "Ver Detalles";
            btnDetalles.UseVisualStyleBackColor = true;
            btnDetalles.Click += btnDetalles_Click;
            // 
            // FormTickets
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnDetalles);
            Controls.Add(label1);
            Controls.Add(dgvTickets);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarTicket);
            Controls.Add(btnModTicket);
            Controls.Add(btnAgregarTicket);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTickets";
            Text = "Tickets";
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTickets;
        private Button btnSalir;
        private Button btnEliminarTicket;
        private Button btnModTicket;
        private Button btnAgregarTicket;
        private Label label1;
        private Button btnDetalles;
    }
}