namespace Vista
{
    partial class FormClientes
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
            btnAgregarCliente = new Button();
            btnModCliente = new Button();
            btnEliminarCliente = new Button();
            btnSalir = new Button();
            dgvClientes = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Cursor = Cursors.Hand;
            btnAgregarCliente.Location = new Point(174, 415);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(75, 23);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // btnModCliente
            // 
            btnModCliente.Cursor = Cursors.Hand;
            btnModCliente.Location = new Point(12, 415);
            btnModCliente.Name = "btnModCliente";
            btnModCliente.Size = new Size(75, 23);
            btnModCliente.TabIndex = 3;
            btnModCliente.Text = "Modificar";
            btnModCliente.UseVisualStyleBackColor = true;
            btnModCliente.Click += btnModCliente_Click;
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.Cursor = Cursors.Hand;
            btnEliminarCliente.Location = new Point(93, 415);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(75, 23);
            btnEliminarCliente.TabIndex = 2;
            btnEliminarCliente.Text = "Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = true;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Location = new Point(713, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 42);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(776, 366);
            dgvClientes.TabIndex = 0;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(122, 21);
            label1.TabIndex = 10;
            label1.Text = "Lista de Clientes";
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvClientes);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarCliente);
            Controls.Add(btnModCliente);
            Controls.Add(btnAgregarCliente);
            Name = "FormClientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregarCliente;
        private Button btnModCliente;
        private Button btnEliminarCliente;
        private Button btnSalir;
        private DataGridView dgvClientes;
        private Label label1;
    }
}