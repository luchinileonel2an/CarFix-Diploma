using Controladora;
using Entidades.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Formularios.Datos
{
    public partial class FormHistorialDescripciones : Form
    {
        private int ticketId;
        private ControladoraHistorialDescripciones controladora;

        public FormHistorialDescripciones(int ticketId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            controladora = ControladoraHistorialDescripciones.Instancia;
        }

        private void FormHistorialDescripciones_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarHistorial();
        }

        private void ConfigurarDataGridView()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaCambio",
                HeaderText = "Fecha",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario",
                Width = 100
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescripcionAnterior",
                HeaderText = "Descripción Anterior",
                Width = 300,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescripcionNueva",
                HeaderText = "Descripción Nueva",
                Width = 300,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Motivo",
                HeaderText = "Motivo",
                Width = 150
            });

            dgvHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CargarHistorial()
        {
            try
            {
                var historial = controladora.ObtenerHistorialPorTicket(ticketId);
                dgvHistorial.DataSource = historial;

                lblTotal.Text = $"Total de cambios: {historial.Count}";

                if (historial.Count == 0)
                {
                    lblTotal.Text = "No hay cambios en la descripción registrados.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count > 0)
            {
                var historial = (HistorialDescripcion)dgvHistorial.SelectedRows[0].DataBoundItem;
                MostrarDetalleEnPanel(historial);
            }
        }

        private void MostrarDetalleEnPanel(HistorialDescripcion historial)
        {
            txtDescripcionAnterior.Text = historial.DescripcionAnterior;
            txtDescripcionNueva.Text = historial.DescripcionNueva;
            lblFechaCambio.Text = $"Cambio realizado el {historial.FechaCambio:dd/MM/yyyy HH:mm} por {historial.Usuario}";

            if (!string.IsNullOrEmpty(historial.Motivo))
            {
                lblMotivo.Text = $"Motivo: {historial.Motivo}";
                lblMotivo.Visible = true;
            }
            else
            {
                lblMotivo.Visible = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivos CSV|*.csv|Archivos de texto|*.txt";
                    sfd.Title = "Exportar Historial de Descripciones";
                    sfd.FileName = $"Historial_Ticket_{ticketId}_{DateTime.Now:yyyyMMdd}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportarHistorial(sfd.FileName);
                        MessageBox.Show("Historial exportado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarHistorial(string rutaArchivo)
        {
            var historial = controladora.ObtenerHistorialPorTicket(ticketId);

            using (var writer = new StreamWriter(rutaArchivo, false, System.Text.Encoding.UTF8))
            {
                // Encabezados
                writer.WriteLine("Fecha,Usuario,Descripción Anterior,Descripción Nueva,Motivo");

                // Datos
                foreach (var item in historial)
                {
                    var fechaStr = item.FechaCambio.ToString("dd/MM/yyyy HH:mm");
                    var anteriorStr = EscaparCSV(item.DescripcionAnterior);
                    var nuevaStr = EscaparCSV(item.DescripcionNueva);
                    var motivoStr = EscaparCSV(item.Motivo ?? "");

                    writer.WriteLine($"{fechaStr},{item.Usuario},{anteriorStr},{nuevaStr},{motivoStr}");
                }
            }
        }

        private string EscaparCSV(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            texto = texto.Replace("\"", "\"\"");
            if (texto.Contains(",") || texto.Contains("\"") || texto.Contains("\n") || texto.Contains("\r"))
            {
                texto = $"\"{texto}\"";
            }
            return texto;
        }
    }
}
