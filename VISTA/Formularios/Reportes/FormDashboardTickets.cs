using Controladora;

namespace Vista.Formularios.Reportes
{
    public partial class FormDashboardTickets : Form
    {
        public FormDashboardTickets()
        {
            InitializeComponent();
            CargarDashboard();
        }

        private void CrearIndicador(Label label, string texto, Color color, Point ubicacion)
        {
            label.Location = ubicacion;
            label.Size = new Size(150, 40);
            label.Text = texto;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.BackColor = color;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        private void CargarDashboard()
        {
            try
            {
                CargarIndicadores();
                CargarTablaEstados();
                CargarTablaTendencia();
                CargarTablaTecnicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarIndicadores()
        {
            var estadisticas = ControladoraReportes.Instancia.ObtenerEstadisticasGenerales();

            lblTotalTickets.Text = $"Total\n{estadisticas["TotalTickets"]}";
            lblTicketsHoy.Text = $"Hoy\n{estadisticas["TicketsHoy"]}";
            lblTicketsEsteMes.Text = $"Este Mes\n{estadisticas["TicketsEsteMes"]}";
        }

        private void CargarTablaEstados()
        {
            var estados = ControladoraReportes.Instancia.ObtenerTicketsPorEstado();
            var datosEstados = estados.Select(e => new { Estado = e.Key, Cantidad = e.Value }).ToList();
            dgvEstados.DataSource = datosEstados;
        }

        private void CargarTablaTendencia()
        {
            var tendencia = ControladoraReportes.Instancia.ObtenerTicketsPorMes(6);
            dgvTendencia.DataSource = tendencia;
        }

        private void CargarTablaTecnicos()
        {
            var tecnicos = ControladoraReportes.Instancia.GenerarReporteProductividadTecnicos()
                .Take(5).Select(t => new
                {
                    Técnico = t.NombreTecnico,
                    Tickets = t.TotalTickets,
                    Eficiencia = $"{t.PorcentajeFinalizados:F1}%"
                }).ToList();
            dgvTecnicos.DataSource = tecnicos;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDashboard();
            MessageBox.Show("Dashboard actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
