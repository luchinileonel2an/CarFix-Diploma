using ScottPlot;
using ScottPlot.WinForms;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using Label = System.Windows.Forms.Label;

namespace Vista.Formularios.Reportes
{
    partial class FormDashboardTickets
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
            this.dgvEstados = new DataGridView();
            this.dgvTendencia = new DataGridView();
            this.dgvTecnicos = new DataGridView();
            this.lblTitulo = new Label();
            this.lblTotalTickets = new Label();
            this.lblTicketsHoy = new Label();
            this.lblTicketsEsteMes = new Label();
            this.gbEstados = new GroupBox();
            this.gbTendencia = new GroupBox();
            this.gbTecnicos = new GroupBox();
            this.gbIndicadores = new GroupBox();
            this.btnActualizar = new Button();
            this.btnCerrar = new Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.lblTitulo.Location = new Point(12, 9);
            this.lblTitulo.Size = new Size(500, 35);
            this.lblTitulo.Text = "Dashboard de Tickets - CarFix";
            this.lblTitulo.ForeColor = Color.DarkBlue;

            // gbIndicadores
            this.gbIndicadores.Text = "📊 Indicadores Clave";
            this.gbIndicadores.Location = new Point(12, 50);
            this.gbIndicadores.Size = new Size(800, 80);

            // Crear indicadores
            CrearIndicador(this.lblTotalTickets, "Total\n0", Color.LightBlue, new Point(20, 20));
            CrearIndicador(this.lblTicketsHoy, "Hoy\n0", Color.LightGreen, new Point(200, 20));
            CrearIndicador(this.lblTicketsEsteMes, "Este Mes\n0", Color.LightYellow, new Point(380, 20));

            this.btnActualizar.Location = new Point(600, 30);
            this.btnActualizar.Size = new Size(80, 30);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += BtnActualizar_Click;

            // gbEstados
            this.gbEstados.Text = "Estados de Tickets";
            this.gbEstados.Location = new Point(12, 140);
            this.gbEstados.Size = new Size(250, 200);

            this.dgvEstados.Location = new Point(10, 20);
            this.dgvEstados.Size = new Size(230, 170);
            this.dgvEstados.ReadOnly = true;
            this.dgvEstados.AllowUserToAddRows = false;

            // gbTendencia
            this.gbTendencia.Text = "Tendencia Mensual";
            this.gbTendencia.Location = new Point(280, 140);
            this.gbTendencia.Size = new Size(250, 200);

            this.dgvTendencia.Location = new Point(10, 20);
            this.dgvTendencia.Size = new Size(230, 170);
            this.dgvTendencia.ReadOnly = true;
            this.dgvTendencia.AllowUserToAddRows = false;

            // gbTecnicos
            this.gbTecnicos.Text = "Top Técnicos";
            this.gbTecnicos.Location = new Point(550, 140);
            this.gbTecnicos.Size = new Size(300, 200);

            this.dgvTecnicos.Location = new Point(10, 20);
            this.dgvTecnicos.Size = new Size(280, 170);
            this.dgvTecnicos.ReadOnly = true;
            this.dgvTecnicos.AllowUserToAddRows = false;

            // btnCerrar
            this.btnCerrar.Location = new Point(770, 350);
            this.btnCerrar.Size = new Size(75, 25);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += (s, e) => this.Close();

            // Agregar controles
            this.gbIndicadores.Controls.Add(this.lblTotalTickets);
            this.gbIndicadores.Controls.Add(this.lblTicketsHoy);
            this.gbIndicadores.Controls.Add(this.lblTicketsEsteMes);
            this.gbIndicadores.Controls.Add(this.btnActualizar);

            this.gbEstados.Controls.Add(this.dgvEstados);
            this.gbTendencia.Controls.Add(this.dgvTendencia);
            this.gbTecnicos.Controls.Add(this.dgvTecnicos);

            // Form
            this.ClientSize = new Size(870, 390);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbIndicadores);
            this.Controls.Add(this.gbEstados);
            this.Controls.Add(this.gbTendencia);
            this.Controls.Add(this.gbTecnicos);
            this.Controls.Add(this.btnCerrar);
            this.Text = "Dashboard de Tickets";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEstados, dgvTendencia, dgvTecnicos;
        private Label lblTitulo, lblTotalTickets, lblTicketsHoy, lblTicketsEsteMes;
        private GroupBox gbEstados, gbTendencia, gbTecnicos, gbIndicadores;
        private Button btnActualizar, btnCerrar;
    }
}