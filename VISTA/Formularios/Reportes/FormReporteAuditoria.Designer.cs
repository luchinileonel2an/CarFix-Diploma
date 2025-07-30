using ScottPlot.WinForms;

namespace Vista.Formularios.Reportes
{
    partial class FormReporteAuditoria
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormReporteAuditoria";
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabOrdenes;
        private TabPage tabTickets;
        private TabPage tabLogin;

        // Controles para Órdenes
        private DataGridView dgvAuditoriaOrdenes;
        private FormsPlot graficoAccionesOrdenes;
        private DateTimePicker dtpDesdeOrdenes;
        private DateTimePicker dtpHastaOrdenes;
        private ComboBox cmbOrdenEspecifica;
        private Button btnGenerarOrdenes;
        private Button btnExportarOrdenes;

        // Controles para Tickets
        private DataGridView dgvAuditoriaTickets;
        private FormsPlot graficoAccionesTickets;
        private DateTimePicker dtpDesdeTickets;
        private DateTimePicker dtpHastaTickets;
        private ComboBox cmbTicketEspecifico;
        private Button btnGenerarTickets;
        private Button btnExportarTickets;

        // Controles para Login
        private DataGridView dgvAuditoriaLogin;
        private FormsPlot graficoLogin;
        private DateTimePicker dtpDesdeLogin;
        private DateTimePicker dtpHastaLogin;
        private Button btnGenerarLogin;
        private Button btnExportarLogin;
    }
}