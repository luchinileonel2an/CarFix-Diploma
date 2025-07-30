using ScottPlot.WinForms;

namespace Vista.Formularios.Reportes
{
    partial class FormReporteCompras
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
            this.Text = "FormReporteCompras";
        }

        #endregion

        private FormsPlot graficoCompras;
        private FormsPlot graficoProveedores;
        private DataGridView tablaCompras;
        private DataGridView tablaProveedores;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private Button btnGenerar;
        private Button btnExportar;
        private Label lblTotalOrdenes;
        private Label lblMontoTotal;
    }
}