using Controladora;
using Entidades.Validaciones;
using ScottPlot;
using ScottPlot.WinForms;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using Label = System.Windows.Forms.Label;


namespace Vista.Formularios.Reportes
{
    public partial class FormReporteAuditoria : Form
    {
        public FormReporteAuditoria()
        {
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Reporte de Auditoría del Sistema";
            this.Size = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            CrearTabOrdenes();
            CrearTabTickets();
            CrearTabLogin();

            tabControl.TabPages.Add(tabOrdenes);
            tabControl.TabPages.Add(tabTickets);
            tabControl.TabPages.Add(tabLogin);

            this.Controls.Add(tabControl);
        }

        private void CrearTabOrdenes()
        {
            tabOrdenes = new TabPage("Auditoría Órdenes de Compra");

            var lblTitulo = new Label
            {
                Text = "TRAZABILIDAD COMPLETA - ÓRDENES DE COMPRA",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(20, 20),
                Size = new Size(500, 25)
            };

            var lblDesde = new Label { Text = "Desde:", Location = new Point(20, 60), Size = new Size(50, 20) };
            dtpDesdeOrdenes = new DateTimePicker { Location = new Point(80, 58), Size = new Size(120, 23), Value = DateTime.Now.AddDays(-30) };

            var lblHasta = new Label { Text = "Hasta:", Location = new Point(220, 60), Size = new Size(50, 20) };
            dtpHastaOrdenes = new DateTimePicker { Location = new Point(280, 58), Size = new Size(120, 23), Value = DateTime.Now };

            var lblOrden = new Label { Text = "Orden específica:", Location = new Point(420, 60), Size = new Size(100, 20) };
            cmbOrdenEspecifica = new ComboBox { Location = new Point(530, 58), Size = new Size(150, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            btnGenerarOrdenes = new Button { Text = "Generar", Location = new Point(700, 57), Size = new Size(80, 25), BackColor = Color.LightBlue };
            btnExportarOrdenes = new Button { Text = "Exportar", Location = new Point(790, 57), Size = new Size(80, 25), BackColor = Color.LightGreen };

            dgvAuditoriaOrdenes = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(900, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            graficoAccionesOrdenes = new FormsPlot
            {
                Location = new Point(940, 100),
                Size = new Size(400, 300)
            };

            btnGenerarOrdenes.Click += (s, e) => CargarAuditoriaOrdenes();
            btnExportarOrdenes.Click += ExportarAuditoriaOrdenes;

            tabOrdenes.Controls.AddRange(new Control[]
            {
                lblTitulo, lblDesde, dtpDesdeOrdenes, lblHasta, dtpHastaOrdenes,
                lblOrden, cmbOrdenEspecifica, btnGenerarOrdenes, btnExportarOrdenes,
                dgvAuditoriaOrdenes, graficoAccionesOrdenes
            });
        }

        private void CrearTabTickets()
        {
            tabTickets = new TabPage("Auditoría Tickets");

            var lblTitulo = new Label
            {
                Text = "TRAZABILIDAD COMPLETA - TICKETS DE TRABAJO",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Location = new Point(20, 20),
                Size = new Size(500, 25)
            };

            var lblDesde = new Label { Text = "Desde:", Location = new Point(20, 60), Size = new Size(50, 20) };
            dtpDesdeTickets = new DateTimePicker { Location = new Point(80, 58), Size = new Size(120, 23), Value = DateTime.Now.AddDays(-30) };

            var lblHasta = new Label { Text = "Hasta:", Location = new Point(220, 60), Size = new Size(50, 20) };
            dtpHastaTickets = new DateTimePicker { Location = new Point(280, 58), Size = new Size(120, 23), Value = DateTime.Now };

            var lblTicket = new Label { Text = "Ticket específico:", Location = new Point(420, 60), Size = new Size(100, 20) };
            cmbTicketEspecifico = new ComboBox { Location = new Point(530, 58), Size = new Size(150, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            btnGenerarTickets = new Button { Text = "Generar", Location = new Point(700, 57), Size = new Size(80, 25), BackColor = Color.LightBlue };
            btnExportarTickets = new Button { Text = "Exportar", Location = new Point(790, 57), Size = new Size(80, 25), BackColor = Color.LightGreen };

            dgvAuditoriaTickets = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(900, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            graficoAccionesTickets = new FormsPlot
            {
                Location = new Point(940, 100),
                Size = new Size(400, 300)
            };

            btnGenerarTickets.Click += (s, e) => CargarAuditoriaTickets();
            btnExportarTickets.Click += ExportarAuditoriaTickets;

            tabTickets.Controls.AddRange(new Control[]
            {
                lblTitulo, lblDesde, dtpDesdeTickets, lblHasta, dtpHastaTickets,
                lblTicket, cmbTicketEspecifico, btnGenerarTickets, btnExportarTickets,
                dgvAuditoriaTickets, graficoAccionesTickets
            });
        }

        private void CrearTabLogin()
        {
            tabLogin = new TabPage("Auditoría Login/Logout");

            var lblTitulo = new Label
            {
                Text = "AUDITORÍA DE ACCESOS AL SISTEMA",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(20, 20),
                Size = new Size(400, 25)
            };

            var lblDesde = new Label { Text = "Desde:", Location = new Point(20, 60), Size = new Size(50, 20) };
            dtpDesdeLogin = new DateTimePicker { Location = new Point(80, 58), Size = new Size(120, 23), Value = DateTime.Now.AddDays(-7) };

            var lblHasta = new Label { Text = "Hasta:", Location = new Point(220, 60), Size = new Size(50, 20) };
            dtpHastaLogin = new DateTimePicker { Location = new Point(280, 58), Size = new Size(120, 23), Value = DateTime.Now };

            btnGenerarLogin = new Button { Text = "Generar", Location = new Point(420, 57), Size = new Size(80, 25), BackColor = Color.LightBlue };
            btnExportarLogin = new Button { Text = "Exportar", Location = new Point(510, 57), Size = new Size(80, 25), BackColor = Color.LightGreen };

            dgvAuditoriaLogin = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(900, 400),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            graficoLogin = new FormsPlot
            {
                Location = new Point(940, 100),
                Size = new Size(400, 400)
            };

            btnGenerarLogin.Click += (s, e) => CargarAuditoriaLogin();
            btnExportarLogin.Click += ExportarAuditoriaLogin;

            tabLogin.Controls.AddRange(new Control[]
            {
                lblTitulo, lblDesde, dtpDesdeLogin, lblHasta, dtpHastaLogin,
                btnGenerarLogin, btnExportarLogin, dgvAuditoriaLogin, graficoLogin
            });
        }

        private void CargarDatos()
        {
            CargarComboOrdenes();
            CargarComboTickets();
            CargarAuditoriaOrdenes();
            CargarAuditoriaTickets();
            CargarAuditoriaLogin();
        }

        private void CargarComboOrdenes()
        {
            var ordenes = ControladoraOrdenesCompra.Instancia.RecuperarOrdenesCompra();
            cmbOrdenEspecifica.Items.Clear();
            cmbOrdenEspecifica.Items.Add("Todas las órdenes");

            foreach (var orden in ordenes)
            {
                cmbOrdenEspecifica.Items.Add($"Orden {orden.Numero} (ID: {orden.Id})");
            }

            cmbOrdenEspecifica.SelectedIndex = 0;
        }

        private void CargarComboTickets()
        {
            var tickets = ControladoraTickets.Instancia.RecuperarTickets();
            cmbTicketEspecifico.Items.Clear();
            cmbTicketEspecifico.Items.Add("Todos los tickets");

            foreach (var ticket in tickets)
            {
                cmbTicketEspecifico.Items.Add($"Ticket #{ticket.Id} - {ticket.Descripcion}");
            }

            cmbTicketEspecifico.SelectedIndex = 0;
        }

        private void CargarAuditoriaOrdenes()
        {
            try
            {
                int? ordenId = null;
                if (cmbOrdenEspecifica.SelectedIndex > 0)
                {
                    var textoSeleccionado = cmbOrdenEspecifica.SelectedItem.ToString();
                    var inicio = textoSeleccionado.IndexOf("ID: ") + 4;
                    var fin = textoSeleccionado.IndexOf(")", inicio);
                    ordenId = int.Parse(textoSeleccionado.Substring(inicio, fin - inicio));
                }

                var auditoria = ServicioAuditoria.Instancia.ObtenerAuditoriaOrdenes(
                    ordenId, dtpDesdeOrdenes.Value, dtpHastaOrdenes.Value);

                var datosTabla = auditoria.Select(a => new
                {
                    Fecha = a.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    Usuario = a.Usuario?.NombreUsuario ?? "Sistema",
                    Orden = $"OC-{a.OrdenCompraId}",
                    Acción = a.Accion,
                    Campo = a.Campo,
                    Anterior = a.ValorAnterior,
                    Nuevo = a.ValorNuevo,
                    Observaciones = a.Observaciones
                }).ToList();

                dgvAuditoriaOrdenes.DataSource = datosTabla;

                foreach (DataGridViewRow fila in dgvAuditoriaOrdenes.Rows)
                {
                    var accion = fila.Cells["Acción"].Value?.ToString();
                    switch (accion)
                    {
                        case "CREATE":
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "UPDATE":
                            fila.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "DELETE":
                            fila.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case "CHANGE_STATUS":
                            fila.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case "UPDATE_STOCK":
                            fila.DefaultCellStyle.BackColor = Color.LightCyan;
                            break;
                    }
                }

                CargarGraficoAccionesOrdenes(auditoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar auditoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoAccionesOrdenes(List<AuditoriaOrdenesCompra> auditoria)
        {
            graficoAccionesOrdenes.Plot.Clear();

            if (!auditoria.Any()) return;

            var accionesPorTipo = auditoria
                .GroupBy(a => a.Accion)
                .Select(g => new { Accion = g.Key, Cantidad = g.Count() })
                .ToList();

            var acciones = accionesPorTipo.Select(a => a.Accion).ToArray();
            var cantidades = accionesPorTipo.Select(a => (double)a.Cantidad).ToArray();

            if (cantidades.Any())
            {
                var pie = graficoAccionesOrdenes.Plot.Add.Pie(cantidades);

                for (int i = 0; i < pie.Slices.Count && i < acciones.Length; i++)
                {
                    pie.Slices[i].Label = acciones[i];
                }

                graficoAccionesOrdenes.Plot.Title("Distribución de Acciones - Órdenes");
                graficoAccionesOrdenes.Plot.ShowLegend();
                graficoAccionesOrdenes.Refresh();
            }
        }

        private void CargarAuditoriaTickets()
        {
            try
            {
                int? ticketId = null;
                if (cmbTicketEspecifico.SelectedIndex > 0)
                {
                    var textoSeleccionado = cmbTicketEspecifico.SelectedItem.ToString();
                    var inicio = textoSeleccionado.IndexOf("#") + 1;
                    var fin = textoSeleccionado.IndexOf(" ", inicio);
                    ticketId = int.Parse(textoSeleccionado.Substring(inicio, fin - inicio));
                }

                var auditoria = ServicioAuditoria.Instancia.ObtenerAuditoriaTickets(
                    ticketId, dtpDesdeTickets.Value, dtpHastaTickets.Value);

                var datosTabla = auditoria.Select(a => new
                {
                    Fecha = a.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    Usuario = a.Usuario?.NombreUsuario ?? "Sistema",
                    Ticket = $"Ticket #{a.TicketId}",
                    Acción = a.Accion,
                    Campo = a.Campo,
                    Anterior = a.ValorAnterior,
                    Nuevo = a.ValorNuevo,
                    Observaciones = a.Observaciones
                }).ToList();

                dgvAuditoriaTickets.DataSource = datosTabla;

                foreach (DataGridViewRow fila in dgvAuditoriaTickets.Rows)
                {
                    var accion = fila.Cells["Acción"].Value?.ToString();
                    switch (accion)
                    {
                        case "CREATE":
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "UPDATE":
                            fila.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "DELETE":
                            fila.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case "CHANGE_STATUS":
                            fila.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                    }
                }

                CargarGraficoAccionesTickets(auditoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar auditoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoAccionesTickets(List<AuditoriaTickets> auditoria)
        {
            graficoAccionesTickets.Plot.Clear();

            if (!auditoria.Any()) return;

            var accionesPorTipo = auditoria
                .GroupBy(a => a.Accion)
                .Select(g => new { Accion = g.Key, Cantidad = g.Count() })
                .ToList();

            var acciones = accionesPorTipo.Select(a => a.Accion).ToArray();
            var cantidades = accionesPorTipo.Select(a => (double)a.Cantidad).ToArray();

            if (cantidades.Any())
            {
                var pie = graficoAccionesTickets.Plot.Add.Pie(cantidades);

                for (int i = 0; i < pie.Slices.Count && i < acciones.Length; i++)
                {
                    pie.Slices[i].Label = acciones[i];
                }

                graficoAccionesTickets.Plot.Title("Distribución de Acciones - Tickets");
                graficoAccionesTickets.Plot.ShowLegend();
                graficoAccionesTickets.Refresh();
            }
        }

        private void CargarAuditoriaLogin()
        {
            try
            {
                var auditoria = ControladoraSeguridad.Instancia.ObtenerAuditoriaLogin(
                    dtpDesdeLogin.Value, dtpHastaLogin.Value);

                var datosTabla = auditoria.Select(a => new
                {
                    Fecha = a.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    Usuario = a.Usuario?.NombreUsuario ?? a.NombreUsuario ?? "Desconocido",
                    Acción = a.TipoEvento,
                    IP = a.DireccionIP,
                    Detalles = a.TipoEvento == "LOGIN" ? "Acceso autorizado" :
                              a.TipoEvento == "LOGOUT" ? "Sesión cerrada" : "Credenciales incorrectas"
                }).ToList();

                dgvAuditoriaLogin.DataSource = datosTabla;

                foreach (DataGridViewRow fila in dgvAuditoriaLogin.Rows)
                {
                    var accion = fila.Cells["Acción"].Value?.ToString();
                    switch (accion)
                    {
                        case "LOGIN":
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "LOGOUT":
                            fila.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case "INTENTO_FALLIDO":
                            fila.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }

                CargarGraficoLogin(auditoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar auditoría de login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoLogin(List<AuditoriaLogin> auditoria)
        {
            graficoLogin.Plot.Clear();

            if (!auditoria.Any()) return;

            var loginsPorDia = auditoria
                .GroupBy(a => a.FechaHora.Date)
                .Select(g => new
                {
                    Fecha = g.Key,
                    Exitosos = g.Count(x => x.TipoEvento == "LOGIN"),
                    Fallidos = g.Count(x => x.TipoEvento == "INTENTO_FALLIDO"),
                    Logout = g.Count(x => x.TipoEvento == "LOGOUT")
                })
                .OrderBy(x => x.Fecha)
                .ToList();

            if (loginsPorDia.Any())
            {
                var fechas = loginsPorDia.Select(l => l.Fecha.ToOADate()).ToArray();
                var exitosos = loginsPorDia.Select(l => (double)l.Exitosos).ToArray();
                var fallidos = loginsPorDia.Select(l => (double)l.Fallidos).ToArray();

                var barrasExitosos = graficoLogin.Plot.Add.Bars(exitosos);
                barrasExitosos.LegendText = "Logins Exitosos";
                barrasExitosos.Color = Colors.Green;

                var barrasFallidos = graficoLogin.Plot.Add.Bars(fallidos);
                barrasFallidos.LegendText = "Intentos Fallidos";
                barrasFallidos.Color = Colors.Red;

                graficoLogin.Plot.Title("Accesos al Sistema por Día");
                graficoLogin.Plot.XLabel("Fecha");
                graficoLogin.Plot.YLabel("Cantidad de Accesos");
                graficoLogin.Plot.ShowLegend();
                graficoLogin.Refresh();
            }
        }

        private void ExportarAuditoriaOrdenes(object sender, EventArgs e)
        {
            ExportarAuditoria("AuditoriaOrdenes", dgvAuditoriaOrdenes);
        }

        private void ExportarAuditoriaTickets(object sender, EventArgs e)
        {
            ExportarAuditoria("AuditoriaTickets", dgvAuditoriaTickets);
        }

        private void ExportarAuditoriaLogin(object sender, EventArgs e)
        {
            ExportarAuditoria("AuditoriaLogin", dgvAuditoriaLogin);
        }

        private void ExportarAuditoria(string nombreArchivo, DataGridView dataGrid)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos CSV|*.csv",
                    Title = "Exportar Auditoría",
                    FileName = $"{nombreArchivo}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        var encabezados = string.Join(",", dataGrid.Columns.Cast<DataGridViewColumn>()
                            .Select(col => col.HeaderText));
                        writer.WriteLine(encabezados);

                        foreach (DataGridViewRow fila in dataGrid.Rows)
                        {
                            if (!fila.IsNewRow)
                            {
                                var valores = string.Join(",", fila.Cells.Cast<DataGridViewCell>()
                                    .Select(celda => $"\"{celda.Value?.ToString() ?? ""}\""));
                                writer.WriteLine(valores);
                            }
                        }
                    }

                    MessageBox.Show("Auditoría exportada exitosamente", "Éxito",
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