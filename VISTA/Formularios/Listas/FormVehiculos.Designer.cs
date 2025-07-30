namespace Vista
{
    partial class FormVehiculos
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
            dgvVehiculos = new DataGridView();
            btnSalir = new Button();
            btnEliminarVehiculo = new Button();
            btnModVehiculo = new Button();
            btnAgregarVehiculo = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(12, 42);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.Size = new Size(776, 366);
            dgvVehiculos.TabIndex = 0;
            dgvVehiculos.SelectionChanged += dgvVehiculos_SelectionChanged;
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
            // btnEliminarVehiculo
            // 
            btnEliminarVehiculo.Cursor = Cursors.Hand;
            btnEliminarVehiculo.Location = new Point(93, 415);
            btnEliminarVehiculo.Name = "btnEliminarVehiculo";
            btnEliminarVehiculo.Size = new Size(75, 23);
            btnEliminarVehiculo.TabIndex = 2;
            btnEliminarVehiculo.Text = "Eliminar";
            btnEliminarVehiculo.UseVisualStyleBackColor = true;
            btnEliminarVehiculo.Click += btnEliminarVehiculo_Click;
            // 
            // btnModVehiculo
            // 
            btnModVehiculo.Cursor = Cursors.Hand;
            btnModVehiculo.Location = new Point(12, 415);
            btnModVehiculo.Name = "btnModVehiculo";
            btnModVehiculo.Size = new Size(75, 23);
            btnModVehiculo.TabIndex = 3;
            btnModVehiculo.Text = "Modificar";
            btnModVehiculo.UseVisualStyleBackColor = true;
            btnModVehiculo.Click += btnModVehiculo_Click;
            // 
            // btnAgregarVehiculo
            // 
            btnAgregarVehiculo.Cursor = Cursors.Hand;
            btnAgregarVehiculo.Location = new Point(174, 415);
            btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            btnAgregarVehiculo.Size = new Size(75, 23);
            btnAgregarVehiculo.TabIndex = 1;
            btnAgregarVehiculo.Text = "Agregar";
            btnAgregarVehiculo.UseVisualStyleBackColor = true;
            btnAgregarVehiculo.Click += btnAgregarVehiculo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 15;
            label1.Text = "Lista de Vehiculos";
            // 
            // FormVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvVehiculos);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarVehiculo);
            Controls.Add(btnModVehiculo);
            Controls.Add(btnAgregarVehiculo);
            Name = "FormVehiculos";
            Text = "Vehiculos";
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVehiculos;
        private Button btnSalir;
        private Button btnEliminarVehiculo;
        private Button btnModVehiculo;
        private Button btnAgregarVehiculo;
        private Label label1;
    }
}