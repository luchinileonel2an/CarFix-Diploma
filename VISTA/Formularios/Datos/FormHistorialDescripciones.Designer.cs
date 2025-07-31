namespace Vista.Formularios.Datos
{
    partial class FormHistorialDescripciones
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
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.lblDescripcionAnterior = new System.Windows.Forms.Label();
            this.txtDescripcionAnterior = new System.Windows.Forms.TextBox();
            this.lblDescripcionNueva = new System.Windows.Forms.Label();
            this.txtDescripcionNueva = new System.Windows.Forms.TextBox();
            this.lblFechaCambio = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.splitterPrincipal = new System.Windows.Forms.Splitter();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelDetalle.SuspendLayout();
            this.groupBoxDetalle.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.lblTotal);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Padding = new System.Windows.Forms.Padding(10);
            this.panelSuperior.Size = new System.Drawing.Size(1000, 60);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(225, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial de Descripciones";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(13, 37);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(38, 16);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total:";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 60);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1000, 300);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.SelectionChanged += new System.EventHandler(this.dgvHistorial_SelectionChanged);
            // 
            // splitterPrincipal
            // 
            this.splitterPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterPrincipal.Location = new System.Drawing.Point(0, 360);
            this.splitterPrincipal.Name = "splitterPrincipal";
            this.splitterPrincipal.Size = new System.Drawing.Size(1000, 3);
            this.splitterPrincipal.TabIndex = 2;
            this.splitterPrincipal.TabStop = false;
            // 
            // panelDetalle
            // 
            this.panelDetalle.Controls.Add(this.groupBoxDetalle);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(0, 363);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetalle.Size = new System.Drawing.Size(1000, 287);
            this.panelDetalle.TabIndex = 3;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Controls.Add(this.lblMotivo);
            this.groupBoxDetalle.Controls.Add(this.lblFechaCambio);
            this.groupBoxDetalle.Controls.Add(this.txtDescripcionNueva);
            this.groupBoxDetalle.Controls.Add(this.lblDescripcionNueva);
            this.groupBoxDetalle.Controls.Add(this.txtDescripcionAnterior);
            this.groupBoxDetalle.Controls.Add(this.lblDescripcionAnterior);
            this.groupBoxDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetalle.Location = new System.Drawing.Point(10, 10);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Size = new System.Drawing.Size(980, 217);
            this.groupBoxDetalle.TabIndex = 0;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle del Cambio";
            // 
            // lblDescripcionAnterior
            // 
            this.lblDescripcionAnterior.AutoSize = true;
            this.lblDescripcionAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionAnterior.Location = new System.Drawing.Point(15, 45);
            this.lblDescripcionAnterior.Name = "lblDescripcionAnterior";
            this.lblDescripcionAnterior.Size = new System.Drawing.Size(127, 13);
            this.lblDescripcionAnterior.TabIndex = 0;
            this.lblDescripcionAnterior.Text = "Descripción Anterior:";
            // 
            // txtDescripcionAnterior
            // 
            this.txtDescripcionAnterior.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescripcionAnterior.Location = new System.Drawing.Point(18, 61);
            this.txtDescripcionAnterior.Multiline = true;
            this.txtDescripcionAnterior.Name = "txtDescripcionAnterior";
            this.txtDescripcionAnterior.ReadOnly = true;
            this.txtDescripcionAnterior.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionAnterior.Size = new System.Drawing.Size(450, 60);
            this.txtDescripcionAnterior.TabIndex = 1;
            // 
            // lblDescripcionNueva
            // 
            this.lblDescripcionNueva.AutoSize = true;
            this.lblDescripcionNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionNueva.Location = new System.Drawing.Point(512, 45);
            this.lblDescripcionNueva.Name = "lblDescripcionNueva";
            this.lblDescripcionNueva.Size = new System.Drawing.Size(117, 13);
            this.lblDescripcionNueva.TabIndex = 2;
            this.lblDescripcionNueva.Text = "Descripción Nueva:";
            // 
            // txtDescripcionNueva
            // 
            this.txtDescripcionNueva.BackColor = System.Drawing.SystemColors.Info;
            this.txtDescripcionNueva.Location = new System.Drawing.Point(515, 61);
            this.txtDescripcionNueva.Multiline = true;
            this.txtDescripcionNueva.Name = "txtDescripcionNueva";
            this.txtDescripcionNueva.ReadOnly = true;
            this.txtDescripcionNueva.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionNueva.Size = new System.Drawing.Size(450, 60);
            this.txtDescripcionNueva.TabIndex = 3;
            // 
            // lblFechaCambio
            // 
            this.lblFechaCambio.AutoSize = true;
            this.lblFechaCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCambio.Location = new System.Drawing.Point(15, 24);
            this.lblFechaCambio.Name = "lblFechaCambio";
            this.lblFechaCambio.Size = new System.Drawing.Size(85, 15);
            this.lblFechaCambio.TabIndex = 4;
            this.lblFechaCambio.Text = "Fecha cambio:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(15, 135);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 5;
            this.lblMotivo.Text = "Motivo:";
            this.lblMotivo.Visible = false;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Controls.Add(this.btnExportar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 600);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10);
            this.panelBotones.Size = new System.Drawing.Size(1000, 50);
            this.panelBotones.TabIndex = 4;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Location = new System.Drawing.Point(820, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(80, 30);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(910, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormHistorialDescripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.splitterPrincipal);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormHistorialDescripciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Descripciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHistorialDescripciones_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            this.groupBoxDetalle.ResumeLayout(false);
            this.groupBoxDetalle.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Splitter splitterPrincipal;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        private System.Windows.Forms.Label lblDescripcionAnterior;
        private System.Windows.Forms.TextBox txtDescripcionAnterior;
        private System.Windows.Forms.Label lblDescripcionNueva;
        private System.Windows.Forms.TextBox txtDescripcionNueva;
        private System.Windows.Forms.Label lblFechaCambio;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCerrar;
    }
}