namespace Vista
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            nudTicket = new NumericUpDown();
            txtDescripcion = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbCliente = new ComboBox();
            cmbVehiculo = new ComboBox();
            cmbTecnico = new ComboBox();
            groupEstados = new GroupBox();
            rbFinalizado = new RadioButton();
            rbAsignado = new RadioButton();
            rbEnProceso = new RadioButton();
            dtpFecha = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)nudTicket).BeginInit();
            groupEstados.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(420, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 50);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 12F);
            btnAceptar.Location = new Point(534, 370);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(80, 50);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // nudTicket
            // 
            nudTicket.Enabled = false;
            nudTicket.Location = new Point(133, 36);
            nudTicket.Name = "nudTicket";
            nudTicket.Size = new Size(100, 23);
            nudTicket.TabIndex = 0;
            nudTicket.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(35, 167);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(579, 125);
            txtDescripcion.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(237, 85);
            label5.Name = "label5";
            label5.Size = new Size(58, 21);
            label5.TabIndex = 28;
            label5.Text = "Cliente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(428, 85);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 26;
            label4.Text = "Tecnico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(35, 85);
            label3.Name = "label3";
            label3.Size = new Size(69, 21);
            label3.TabIndex = 25;
            label3.Text = "Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(35, 143);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 23;
            label2.Text = "Descripcion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(35, 35);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 21;
            label1.Text = "Nro. Ticket";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(301, 84);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 3;
            // 
            // cmbVehiculo
            // 
            cmbVehiculo.FormattingEnabled = true;
            cmbVehiculo.Location = new Point(110, 85);
            cmbVehiculo.Name = "cmbVehiculo";
            cmbVehiculo.Size = new Size(121, 23);
            cmbVehiculo.TabIndex = 2;
            // 
            // cmbTecnico
            // 
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(494, 85);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(121, 23);
            cmbTecnico.TabIndex = 4;
            // 
            // groupEstados
            // 
            groupEstados.Controls.Add(rbFinalizado);
            groupEstados.Controls.Add(rbAsignado);
            groupEstados.Controls.Add(rbEnProceso);
            groupEstados.Location = new Point(35, 320);
            groupEstados.Name = "groupEstados";
            groupEstados.Size = new Size(132, 100);
            groupEstados.TabIndex = 38;
            groupEstados.TabStop = false;
            groupEstados.Text = "Estado";
            // 
            // rbFinalizado
            // 
            rbFinalizado.AutoSize = true;
            rbFinalizado.Location = new Point(18, 70);
            rbFinalizado.Margin = new Padding(3, 2, 3, 2);
            rbFinalizado.Name = "rbFinalizado";
            rbFinalizado.Size = new Size(78, 19);
            rbFinalizado.TabIndex = 41;
            rbFinalizado.TabStop = true;
            rbFinalizado.Text = "Finalizado";
            rbFinalizado.UseVisualStyleBackColor = true;
            // 
            // rbAsignado
            // 
            rbAsignado.AutoSize = true;
            rbAsignado.Location = new Point(18, 20);
            rbAsignado.Margin = new Padding(3, 2, 3, 2);
            rbAsignado.Name = "rbAsignado";
            rbAsignado.Size = new Size(75, 19);
            rbAsignado.TabIndex = 39;
            rbAsignado.TabStop = true;
            rbAsignado.Text = "Asignado";
            rbAsignado.UseVisualStyleBackColor = true;
            // 
            // rbEnProceso
            // 
            rbEnProceso.AutoSize = true;
            rbEnProceso.Location = new Point(18, 46);
            rbEnProceso.Margin = new Padding(3, 2, 3, 2);
            rbEnProceso.Name = "rbEnProceso";
            rbEnProceso.Size = new Size(83, 19);
            rbEnProceso.TabIndex = 40;
            rbEnProceso.TabStop = true;
            rbEnProceso.Text = "En Proceso";
            rbEnProceso.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(494, 33);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.RightToLeft = RightToLeft.No;
            dtpFecha.Size = new Size(121, 23);
            dtpFecha.TabIndex = 1;
            // 
            // FormDatosTickets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 437);
            Controls.Add(dtpFecha);
            Controls.Add(groupEstados);
            Controls.Add(cmbTecnico);
            Controls.Add(cmbVehiculo);
            Controls.Add(cmbCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudTicket);
            Controls.Add(txtDescripcion);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormDatosTickets";
            Text = "Gestion Tickets";
            Load += FormDatosTickets_Load;
            ((System.ComponentModel.ISupportInitialize)nudTicket).EndInit();
            groupEstados.ResumeLayout(false);
            groupEstados.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnAceptar;
        private NumericUpDown nudTicket;
        private TextBox txtDescripcion;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbCliente;
        private ComboBox cmbVehiculo;
        private ComboBox cmbTecnico;
        private GroupBox groupEstados;
        private DateTimePicker dtpFecha;
        private RadioButton rbAsignado;
        private RadioButton rbEnProceso;
        private RadioButton rbFinalizado;
    }
}