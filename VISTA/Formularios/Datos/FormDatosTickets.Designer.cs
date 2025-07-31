namespace Vista.Formularios.Datos
{
    partial class FormDatosTickets
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
            this.nudTicket = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.groupEstados = new System.Windows.Forms.GroupBox();
            this.rbFinalizado = new System.Windows.Forms.RadioButton();
            this.rbEnProceso = new System.Windows.Forms.RadioButton();
            this.rbAsignado = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSeleccionarCliente = new System.Windows.Forms.Button();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.btnSeleccionarVehiculo = new System.Windows.Forms.Button();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.btnSeleccionarTecnico = new System.Windows.Forms.Button();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTicket)).BeginInit();
            this.groupEstados.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudTicket
            // 
            this.nudTicket.Location = new System.Drawing.Point(150, 15);
            this.nudTicket.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudTicket.Name = "nudTicket";
            this.nudTicket.ReadOnly = true;
            this.nudTicket.Size = new System.Drawing.Size(120, 22);
            this.nudTicket.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(450, 15);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 22);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Location = new System.Drawing.Point(50, 17);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(71, 16);
            this.lblTicket.TabIndex = 2;
            this.lblTicket.Text = "Nro. Ticket:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(400, 17);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(44, 16);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(50, 60);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 16);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.Window;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCliente.Location = new System.Drawing.Point(150, 57);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(200, 22);
            this.txtCliente.TabIndex = 5;
            this.txtCliente.Text = "Seleccionar cliente...";
            this.txtCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(356, 55);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(30, 25);
            this.btnSeleccionarCliente.TabIndex = 6;
            this.btnSeleccionarCliente.Text = "...";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = true;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(50, 100);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(59, 16);
            this.lblVehiculo.TabIndex = 7;
            this.lblVehiculo.Text = "Vehículo:";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.BackColor = System.Drawing.SystemColors.Window;
            this.txtVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtVehiculo.Location = new System.Drawing.Point(150, 97);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.ReadOnly = true;
            this.txtVehiculo.Size = new System.Drawing.Size(200, 22);
            this.txtVehiculo.TabIndex = 8;
            this.txtVehiculo.Text = "Seleccionar vehículo...";
            this.txtVehiculo.Click += new System.EventHandler(this.btnSeleccionarVehiculo_Click);
            // 
            // btnSeleccionarVehiculo
            // 
            this.btnSeleccionarVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarVehiculo.Location = new System.Drawing.Point(356, 95);
            this.btnSeleccionarVehiculo.Name = "btnSeleccionarVehiculo";
            this.btnSeleccionarVehiculo.Size = new System.Drawing.Size(30, 25);
            this.btnSeleccionarVehiculo.TabIndex = 9;
            this.btnSeleccionarVehiculo.Text = "...";
            this.btnSeleccionarVehiculo.UseVisualStyleBackColor = true;
            this.btnSeleccionarVehiculo.Click += new System.EventHandler(this.btnSeleccionarVehiculo_Click);
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(50, 140);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(54, 16);
            this.lblTecnico.TabIndex = 10;
            this.lblTecnico.Text = "Técnico:";
            // 
            // txtTecnico
            // 
            this.txtTecnico.BackColor = System.Drawing.SystemColors.Window;
            this.txtTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTecnico.Location = new System.Drawing.Point(150, 137);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.ReadOnly = true;
            this.txtTecnico.Size = new System.Drawing.Size(200, 22);
            this.txtTecnico.TabIndex = 11;
            this.txtTecnico.Text = "Seleccionar técnico...";
            this.txtTecnico.Click += new System.EventHandler(this.btnSeleccionarTecnico_Click);
            // 
            // btnSeleccionarTecnico
            // 
            this.btnSeleccionarTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarTecnico.Location = new System.Drawing.Point(356, 135);
            this.btnSeleccionarTecnico.Name = "btnSeleccionarTecnico";
            this.btnSeleccionarTecnico.Size = new System.Drawing.Size(30, 25);
            this.btnSeleccionarTecnico.TabIndex = 12;
            this.btnSeleccionarTecnico.Text = "...";
            this.btnSeleccionarTecnico.UseVisualStyleBackColor = true;
            this.btnSeleccionarTecnico.Click += new System.EventHandler(this.btnSeleccionarTecnico_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(50, 180);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 13;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(50, 200);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(520, 80);
            this.txtDescripcion.TabIndex = 14;
            // 
            // groupEstados
            // 
            this.groupEstados.Controls.Add(this.rbFinalizado);
            this.groupEstados.Controls.Add(this.rbEnProceso);
            this.groupEstados.Controls.Add(this.rbAsignado);
            this.groupEstados.Location = new System.Drawing.Point(50, 300);
            this.groupEstados.Name = "groupEstados";
            this.groupEstados.Size = new System.Drawing.Size(350, 60);
            this.groupEstados.TabIndex = 15;
            this.groupEstados.TabStop = false;
            this.groupEstados.Text = "Estado";
            // 
            // rbAsignado
            // 
            this.rbAsignado.AutoSize = true;
            this.rbAsignado.Checked = true;
            this.rbAsignado.Location = new System.Drawing.Point(20, 25);
            this.rbAsignado.Name = "rbAsignado";
            this.rbAsignado.Size = new System.Drawing.Size(81, 20);
            this.rbAsignado.TabIndex = 16;
            this.rbAsignado.TabStop = true;
            this.rbAsignado.Text = "Asignado";
            this.rbAsignado.UseVisualStyleBackColor = true;
            // 
            // rbEnProceso
            // 
            this.rbEnProceso.AutoSize = true;
            this.rbEnProceso.Location = new System.Drawing.Point(120, 25);
            this.rbEnProceso.Name = "rbEnProceso";
            this.rbEnProceso.Size = new System.Drawing.Size(90, 20);
            this.rbEnProceso.TabIndex = 17;
            this.rbEnProceso.Text = "En Proceso";
            this.rbEnProceso.UseVisualStyleBackColor = true;
            // 
            // rbFinalizado
            // 
            this.rbFinalizado.AutoSize = true;
            this.rbFinalizado.Location = new System.Drawing.Point(230, 25);
            this.rbFinalizado.Name = "rbFinalizado";
            this.rbFinalizado.Size = new System.Drawing.Size(87, 20);
            this.rbFinalizado.TabIndex = 18;
            this.rbFinalizado.Text = "Finalizado";
            this.rbFinalizado.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(400, 380);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 30);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(490, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.Location = new System.Drawing.Point(50, 380);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(100, 30);
            this.btnVerHistorial.TabIndex = 21;
            this.btnVerHistorial.Text = "Ver Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = true;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // FormDatosTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 430);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupEstados);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnSeleccionarTecnico);
            this.Controls.Add(this.txtTecnico);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.btnSeleccionarVehiculo);
            this.Controls.Add(this.txtVehiculo);
            this.Controls.Add(this.lblVehiculo);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.nudTicket);
            this.Controls.Add(this.btnVerHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDatosTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión Tickets";
            this.Load += new System.EventHandler(this.FormDatosTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTicket)).EndInit();
            this.groupEstados.ResumeLayout(false);
            this.groupEstados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudTicket;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox groupEstados;
        private System.Windows.Forms.RadioButton rbAsignado;
        private System.Windows.Forms.RadioButton rbEnProceso;
        private System.Windows.Forms.RadioButton rbFinalizado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVerHistorial;

        // Nuevos controles para selección
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSeleccionarCliente;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.Button btnSeleccionarVehiculo;
        private System.Windows.Forms.TextBox txtTecnico;
        private System.Windows.Forms.Button btnSeleccionarTecnico;

        // Labels
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.Label lblDescripcion;
    }
}