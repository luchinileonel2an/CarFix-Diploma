namespace Vista
{
    partial class FormTecnicos
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
            dgvTecnicos = new DataGridView();
            btnSalir = new Button();
            btnEliminarTecnico = new Button();
            btnModTecnico = new Button();
            btnAgregarTecnico = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            SuspendLayout();
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Location = new Point(12, 42);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.Size = new Size(776, 366);
            dgvTecnicos.TabIndex = 0;
            dgvTecnicos.SelectionChanged += dgvTecnicos_SelectionChanged;
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
            // btnEliminarTecnico
            // 
            btnEliminarTecnico.Cursor = Cursors.Hand;
            btnEliminarTecnico.Location = new Point(93, 415);
            btnEliminarTecnico.Name = "btnEliminarTecnico";
            btnEliminarTecnico.Size = new Size(75, 23);
            btnEliminarTecnico.TabIndex = 2;
            btnEliminarTecnico.Text = "Eliminar";
            btnEliminarTecnico.UseVisualStyleBackColor = true;
            btnEliminarTecnico.Click += btnEliminarTecnico_Click;
            // 
            // btnModTecnico
            // 
            btnModTecnico.Cursor = Cursors.Hand;
            btnModTecnico.Location = new Point(12, 415);
            btnModTecnico.Name = "btnModTecnico";
            btnModTecnico.Size = new Size(75, 23);
            btnModTecnico.TabIndex = 3;
            btnModTecnico.Text = "Modificar";
            btnModTecnico.UseVisualStyleBackColor = true;
            btnModTecnico.Click += btnModTecnico_Click;
            // 
            // btnAgregarTecnico
            // 
            btnAgregarTecnico.Cursor = Cursors.Hand;
            btnAgregarTecnico.Location = new Point(174, 415);
            btnAgregarTecnico.Name = "btnAgregarTecnico";
            btnAgregarTecnico.Size = new Size(75, 23);
            btnAgregarTecnico.TabIndex = 1;
            btnAgregarTecnico.Text = "Agregar";
            btnAgregarTecnico.UseVisualStyleBackColor = true;
            btnAgregarTecnico.Click += btnAgregarTecnico_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 15;
            label1.Text = "Lista de Tecnicos";
            // 
            // FormTecnicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvTecnicos);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarTecnico);
            Controls.Add(btnModTecnico);
            Controls.Add(btnAgregarTecnico);
            Name = "FormTecnicos";
            Text = "Tecnicos";
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTecnicos;
        private Button btnSalir;
        private Button btnEliminarTecnico;
        private Button btnModTecnico;
        private Button btnAgregarTecnico;
        private Label label1;
    }
}