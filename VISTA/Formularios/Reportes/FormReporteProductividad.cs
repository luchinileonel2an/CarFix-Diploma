using Controladora;
using Entidades.Validaciones;
using ScottPlot;
using ScottPlot.WinForms;
using FontStyle = System.Drawing.FontStyle;
using Label = System.Windows.Forms.Label;

namespace Vista.Formularios.Reportes
{
    public partial class FormReporteProductividad : Form
    {
        public FormReporteProductividad()
        {
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Reporte de Productividad";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitulo = new Label
            {
                Text = "Productividad por Técnico",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkBlue,
                Location = new Point(20, 20),
                Size = new Size(400, 30)
            };

            var lblDesde = new Label
            {
                Text = "Desde:",
                Location = new Point(20, 70),
                Size = new Size(50, 20)
            };

            fechaDesde = new DateTimePicker
            {
                Location = new Point(80, 67),
                Size = new Size(120, 25),
                Value = DateTime.Now.AddMonths(-6)
            };

            var lblHasta = new Label
            {
                Text = "Hasta:",
                Location = new Point(220, 70),
                Size = new Size(50, 20)
            };

            fechaHasta = new DateTimePicker
            {
                Location = new Point(280, 67),
                Size = new Size(120, 25),
                Value = DateTime.Now
            };

            btnGenerar = new Button
            {
                Text = "Generar",
                Location = new Point(420, 65),
                Size = new Size(80, 30),
                BackColor = System.Drawing.Color.LightBlue
            };
            btnGenerar.Click += (s, e) => CargarDatos();

            lblTotal = new Label
            {
                Text = "Total: 0",
                Location = new Point(520, 70),
                Size = new Size(100, 25),
                BackColor = System.Drawing.Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };

            lblDestacado = new Label
            {
                Text = "Destacado: N/A",
                Location = new Point(630, 70),
                Size = new Size(150, 25),
                BackColor = System.Drawing.Color.LightYellow,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };

            grafico = new FormsPlot
            {
                Location = new Point(20, 110),
                Size = new Size(500, 350)
            };

            tabla = new DataGridView
            {
                Location = new Point(540, 110),
                Size = new Size(430, 350),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(880, 480),
                Size = new Size(80, 30),
                BackColor = System.Drawing.Color.LightCoral
            };
            btnCerrar.Click += (s, e) => this.Close();

            var btnExportar = new Button
            {
                Text = "Exportar CSV",
                Location = new Point(780, 480),
                Size = new Size(100, 30),
                BackColor = System.Drawing.Color.LightGreen
            };
            btnExportar.Click += ExportarCSV;
            this.Controls.Add(btnExportar);

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblDesde);
            this.Controls.Add(fechaDesde);
            this.Controls.Add(lblHasta);
            this.Controls.Add(fechaHasta);
            this.Controls.Add(btnGenerar);
            this.Controls.Add(lblTotal);
            this.Controls.Add(lblDestacado);
            this.Controls.Add(grafico);
            this.Controls.Add(tabla);
            this.Controls.Add(btnCerrar);
        }

        private void CargarDatos()
        {
            try
            {
                var datos = ControladoraReportes.Instancia.GenerarReporteProductividadTecnicos(
                    fechaDesde.Value, fechaHasta.Value);

                CargarTabla(datos);

                CargarGrafico(datos);

                ActualizarIndicadores(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTabla(List<ProductividadTecnico> datos)
        {
            var datosTabla = datos.Select(d => new
            {
                Técnico = d.NombreTecnico,
                Especialidad = d.Especialidad,
                Total = d.TotalTickets,
                Finalizados = d.TicketsFinalizados,
                Eficiencia = $"{d.PorcentajeFinalizados:F1}%",
                Rendimiento = d.RendimientoTexto
            }).ToList();

            tabla.DataSource = datosTabla;

            foreach (DataGridViewRow fila in tabla.Rows)
            {
                var rendimiento = fila.Cells["Rendimiento"].Value?.ToString();
                switch (rendimiento)
                {
                    case "Excelente":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "Bueno":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        break;
                    case "Regular":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        break;
                    case "Necesita Mejora":
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        break;
                }
            }
        }

        private void CargarGrafico(List<ProductividadTecnico> datos)
        {
            grafico.Plot.Clear();

            if (!datos.Any()) return;

            var top6 = datos.Take(6).ToList();

            var nombres = top6.Select(d => d.NombreTecnico.Split(' ')[0]).ToArray();
            var totales = top6.Select(d => (double)d.TotalTickets).ToArray();
            var finalizados = top6.Select(d => (double)d.TicketsFinalizados).ToArray();
            var posiciones = Enumerable.Range(0, nombres.Length).Select(i => (double)i).ToArray();

            var barras1 = grafico.Plot.Add.Bars(totales);
            barras1.LegendText = "Total Tickets";
            barras1.Color = Colors.Blue;

            var barras2 = grafico.Plot.Add.Bars(finalizados);
            barras2.LegendText = "Finalizados";
            barras2.Color = Colors.Green;

            grafico.Plot.Title("Productividad por Técnico");
            grafico.Plot.XLabel("Técnicos");
            grafico.Plot.YLabel("Cantidad de Tickets");

            var ticks = posiciones.Select((pos, i) => new Tick(pos, nombres[i])).ToArray();
            grafico.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            grafico.Plot.ShowLegend();

            grafico.Refresh();
        }

        private void ActualizarIndicadores(List<ProductividadTecnico> datos)
        {
            if (datos.Any())
            {
                var total = datos.Sum(d => d.TotalTickets);
                var destacado = datos.OrderByDescending(d => d.TotalTickets).First();

                lblTotal.Text = $"Total: {total}";
                lblDestacado.Text = $"Destacado: {destacado.NombreTecnico.Split(' ')[0]}";
            }
            else
            {
                lblTotal.Text = "Total: 0";
                lblDestacado.Text = "Destacado: N/A";
            }
        }
        private void ExportarCSV(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos CSV|*.csv",
                    Title = "Exportar Reporte",
                    FileName = $"Productividad_Tecnicos_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var datos = ControladoraReportes.Instancia.GenerarReporteProductividadTecnicos(
                        fechaDesde.Value, fechaHasta.Value);

                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        // Encabezados
                        writer.WriteLine("Técnico,Especialidad,Total Tickets,Finalizados,En Proceso,Asignados,% Finalizados,Promedio Mensual,Rendimiento");

                        // Datos
                        foreach (var dato in datos)
                        {
                            writer.WriteLine($"{dato.NombreTecnico},{dato.Especialidad},{dato.TotalTickets}," +
                                           $"{dato.TicketsFinalizados},{dato.TicketsEnProceso},{dato.TicketsAsignados}," +
                                           $"{dato.PorcentajeFinalizados},{dato.PromedioTicketsPorMes},{dato.RendimientoTexto}");
                        }
                    }

                    MessageBox.Show("Archivo CSV exportado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}