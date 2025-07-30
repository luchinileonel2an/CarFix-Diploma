using Controladora;
using ScottPlot;
using ScottPlot.WinForms;
using System.Globalization;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using Label = System.Windows.Forms.Label;

namespace Vista.Formularios.Reportes
{
    public partial class FormReporteCompras : Form
    {
        public FormReporteCompras()
        {
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Reporte de Compras";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblTitulo = new Label
            {
                Text = "Reporte de Órdenes de Compra",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(20, 20),
                Size = new Size(400, 30)
            };

            var lblDesde = new Label { Text = "Desde:", Location = new Point(20, 70), Size = new Size(50, 20) };
            fechaDesde = new DateTimePicker
            {
                Location = new Point(80, 67),
                Size = new Size(120, 25),
                Value = DateTime.Now.AddMonths(-6)
            };

            var lblHasta = new Label { Text = "Hasta:", Location = new Point(220, 70), Size = new Size(50, 20) };
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
                BackColor = Color.LightBlue
            };
            btnGenerar.Click += (s, e) => CargarDatos();

            btnExportar = new Button
            {
                Text = "Exportar CSV",
                Location = new Point(510, 65),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };
            btnExportar.Click += ExportarCSV;

            lblTotalOrdenes = new Label
            {
                Text = "Órdenes: 0",
                Location = new Point(630, 70),
                Size = new Size(100, 25),
                BackColor = Color.LightYellow,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };

            lblMontoTotal = new Label
            {
                Text = "Total: $0,00",
                Location = new Point(740, 70),
                Size = new Size(120, 25),
                BackColor = Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };

            graficoCompras = new FormsPlot
            {
                Location = new Point(20, 110),
                Size = new Size(580, 250)
            };

            graficoProveedores = new FormsPlot
            {
                Location = new Point(620, 110),
                Size = new Size(550, 250)
            };

            tablaCompras = new DataGridView
            {
                Location = new Point(20, 380),
                Size = new Size(580, 250),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            tablaProveedores = new DataGridView
            {
                Location = new Point(620, 380),
                Size = new Size(550, 250),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.AddRange(new Control[]
            {
                lblTitulo, lblDesde, fechaDesde, lblHasta, fechaHasta,
                btnGenerar, btnExportar, lblTotalOrdenes, lblMontoTotal,
                graficoCompras, graficoProveedores, tablaCompras, tablaProveedores
            });
        }

        private void CargarDatos()
        {
            try
            {
                var reporteCompras = ControladoraReportesCompras.Instancia.GenerarReporteComprasPorMes(
                    fechaDesde.Value, fechaHasta.Value);

                var reporteProveedores = ControladoraReportesCompras.Instancia.GenerarReporteProveedores(
                    fechaDesde.Value, fechaHasta.Value);

                CargarGraficoCompras(reporteCompras);
                CargarGraficoProveedores(reporteProveedores);
                CargarTablaCompras(reporteCompras);
                CargarTablaProveedores(reporteProveedores);
                ActualizarIndicadores(reporteCompras);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoCompras(List<ReporteCompras> datos)
        {
            graficoCompras.Plot.Clear();

            if (!datos.Any()) return;

            var periodos = datos.Select(d => d.Periodo).ToArray();
            var montos = datos.Select(d => (double)d.MontoTotal).ToArray();
            var posiciones = Enumerable.Range(0, periodos.Length).Select(i => (double)i).ToArray();

            var barras = graficoCompras.Plot.Add.Bars(montos);
            barras.Color = Colors.Blue;

            graficoCompras.Plot.Title("Compras por Mes");
            graficoCompras.Plot.XLabel("Período");
            graficoCompras.Plot.YLabel("Monto Total");

            var ticks = posiciones.Select((pos, i) => new Tick(pos, periodos[i])).ToArray();
            graficoCompras.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            graficoCompras.Refresh();
        }

        private void CargarGraficoProveedores(List<ReporteProveedor> datos)
        {
            graficoProveedores.Plot.Clear();

            if (!datos.Any()) return;

            var top5 = datos.Take(5).ToList();
            var proveedores = top5.Select(d => d.NombreProveedor).ToArray();
            var montos = top5.Select(d => (double)d.MontoTotal).ToArray();

            var pie = graficoProveedores.Plot.Add.Pie(montos);

            for (int i = 0; i < pie.Slices.Count && i < proveedores.Length; i++)
            {
                pie.Slices[i].Label = proveedores[i];
            }

            graficoProveedores.Plot.Title("Top 5 Proveedores por Monto");
            graficoProveedores.Plot.ShowLegend();

            graficoProveedores.Refresh();
        }

        private void CargarTablaCompras(List<ReporteCompras> datos)
        {
            var datosTabla = datos.Select(d => new
            {
                Período = d.Periodo,
                Órdenes = d.CantidadOrdenes,
                Productos = d.ProductosComprados,
                Monto = d.MontoTotal.ToString("C")
            }).ToList();

            tablaCompras.DataSource = datosTabla;
        }

        private void CargarTablaProveedores(List<ReporteProveedor> datos)
        {
            var datosTabla = datos.Select(d => new
            {
                Proveedor = d.NombreProveedor,
                Órdenes = d.CantidadOrdenes,
                Monto = d.MontoTotal.ToString("C"),
                Porcentaje = $"{d.PorcentajeTotal:F1}%"
            }).ToList();

            tablaProveedores.DataSource = datosTabla;
        }

        private void ActualizarIndicadores(List<ReporteCompras> datos)
        {
            if (datos.Any())
            {
                var totalOrdenes = datos.Sum(d => d.CantidadOrdenes);
                var montoTotal = datos.Sum(d => d.MontoTotal);

                lblTotalOrdenes.Text = $"Órdenes: {totalOrdenes}";
                lblMontoTotal.Text = $"Total: {montoTotal.ToString("C")}";
            }
            else
            {
                lblTotalOrdenes.Text = "Órdenes: 0";
                lblMontoTotal.Text = "Total: $0,00";
            }
        }

        private void ExportarCSV(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos CSV|*.csv",
                    Title = "Exportar Reporte de Compras",
                    FileName = $"Reporte_Compras_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var reporteCompras = ControladoraReportesCompras.Instancia.GenerarReporteComprasPorMes(
                        fechaDesde.Value, fechaHasta.Value);

                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        writer.WriteLine("Período,Cantidad Órdenes,Monto Total,Productos Comprados");

                        foreach (var dato in reporteCompras)
                        {
                            writer.WriteLine($"{dato.Periodo},{dato.CantidadOrdenes},{dato.MontoTotal},{dato.ProductosComprados}");
                        }
                    }

                    MessageBox.Show("Archivo CSV exportado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}