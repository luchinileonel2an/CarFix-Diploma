namespace Vista
{
    partial class FormTecnicos
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvTecnicos = new System.Windows.Forms.DataGridView();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarTecnico = new System.Windows.Forms.Button();
            this.btnModTecnico = new System.Windows.Forms.Button();
            this.btnAgregarTecnico = new System.Windows.Forms.Button();
            this.panelSuperior.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicos)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Padding = new System.Windows.Forms.Padding(10);
            this.panelSuperior.Size = new System.Drawing.Size(800, 50);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Lista de Técnicos";
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.btnRefrescar);
            this.panelBusqueda.Controls.Add(this.btnLimpiarFiltros);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Location = new System.Drawing.Point(0, 50);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Padding = new System.Windows.Forms.Padding(10);
            this.panelBusqueda.Size = new System.Drawing.Size(800, 60);
            this.panelBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(13, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(71, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(400, 22);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(480, 15);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(80, 25);
            this.btnLimpiarFiltros.TabIndex = 2;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(570, 15);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(80, 25);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvTecnicos
            // 
            this.dgvTecnicos.AllowUserToAddRows = false;
            this.dgvTecnicos.AllowUserToDeleteRows = false;
            this.dgvTecnicos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTecnicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTecnicos.Location = new System.Drawing.Point(0, 110);
            this.dgvTecnicos.MultiSelect = false;
            this.dgvTecnicos.Name = "dgvTecnicos";
            this.dgvTecnicos.ReadOnly = true;
            this.dgvTecnicos.RowHeadersVisible = false;
            this.dgvTecnicos.RowHeadersWidth = 51;
            this.dgvTecnicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTecnicos.Size = new System.Drawing.Size(800, 340);
            this.dgvTecnicos.TabIndex = 2;
            this.dgvTecnicos.SelectionChanged += new System.EventHandler(this.dgvTecnicos_SelectionChanged);
            this.dgvTecnicos.DoubleClick += new System.EventHandler(this.dgvTecnicos_DoubleClick);
            this.dgvTecnicos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTecnicos_KeyDown);
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.lblContador);
            this.panelInferior.Controls.Add(this.btnSalir);
            this.panelInferior.Controls.Add(this.btnEliminarTecnico);
            this.panelInferior.Controls.Add(this.btnModTecnico);
            this.panelInferior.Controls.Add(this.btnAgregarTecnico);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 400);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Padding = new System.Windows.Forms.Padding(10);
            this.panelInferior.Size = new System.Drawing.Size(800, 50);
            this.panelInferior.TabIndex = 3;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(13, 17);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(124, 16);
            this.lblContador.TabIndex = 0;
            this.lblContador.Text = "Total: 0 registros";
            // 
            // btnAgregarTecnico
            // 
            this.btnAgregarTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTecnico.Location = new System.Drawing.Point(450, 10);
            this.btnAgregarTecnico.Name = "btnAgregarTecnico";
            this.btnAgregarTecnico.Size = new System.Drawing.Size(80, 30);
            this.btnAgregarTecnico.TabIndex = 1;
            this.btnAgregarTecnico.Text = "Agregar";
            this.btnAgregarTecnico.UseVisualStyleBackColor = true;
            this.btnAgregarTecnico.Click += new System.EventHandler(this.btnAgregarTecnico_Click);
            // 
            // btnModTecnico
            // 
            this.btnModTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModTecnico.Location = new System.Drawing.Point(540, 10);
            this.btnModTecnico.Name = "btnModTecnico";
            this.btnModTecnico.Size = new System.Drawing.Size(80, 30);
            this.btnModTecnico.TabIndex = 2;
            this.btnModTecnico.Text = "Modificar";
            this.btnModTecnico.UseVisualStyleBackColor = true;
            this.btnModTecnico.Click += new System.EventHandler(this.btnModTecnico_Click);
            // 
            // btnEliminarTecnico
            // 
            this.btnEliminarTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTecnico.Location = new System.Drawing.Point(630, 10);
            this.btnEliminarTecnico.Name = "btnEliminarTecnico";
            this.btnEliminarTecnico.Size = new System.Drawing.Size(80, 30);
            this.btnEliminarTecnico.TabIndex = 3;
            this.btnEliminarTecnico.Text = "Eliminar";
            this.btnEliminarTecnico.UseVisualStyleBackColor = true;
            this.btnEliminarTecnico.Click += new System.EventHandler(this.btnEliminarTecnico_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Location = new System.Drawing.Point(720, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 30);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormTecnicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTecnicos);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.panelSuperior);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormTecnicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Técnicos";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicos)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvTecnicos;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnAgregarTecnico;
        private System.Windows.Forms.Button btnModTecnico;
        private System.Windows.Forms.Button btnEliminarTecnico;
        private System.Windows.Forms.Button btnSalir;
    }
}