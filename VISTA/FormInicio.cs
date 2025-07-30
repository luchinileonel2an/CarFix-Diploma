using Controladora;
using Entidades.Compras;
using Entidades.Patrones;
using Vista.Formularios.Listas;
using Vista.Formularios.Reportes;

namespace Vista
{
    public partial class FormInicio : Form, IObserver
    {
        public FormInicio()
        {
            InitializeComponent();
            NotificadorOrdenesCompra.Instancia.AddObserver(this);
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            ConfigurarSeguridad();
            AgregarMenuCompras();
            AgregarMenuAuditoria();
            ActualizarInterfazSegunPermisos();
            MostrarBienvenida();
        }

        private void AgregarMenuCompras()
        {
            MenuStrip menuPrincipal = this.MainMenuStrip ?? this.Controls.OfType<MenuStrip>().FirstOrDefault();

            if (menuPrincipal == null) return;

            var menuCompras = new ToolStripMenuItem("Compras");

            var menuProveedores = new ToolStripMenuItem("Proveedores");
            menuProveedores.Click += MenuProveedores_Click;

            var menuProductos = new ToolStripMenuItem("Productos");
            menuProductos.Click += MenuProductos_Click;

            var menuOrdenesCompra = new ToolStripMenuItem("Órdenes de Compra");
            menuOrdenesCompra.Click += MenuOrdenesCompra_Click;

            var menuReporteCompras = new ToolStripMenuItem("Reporte de Compras");
            menuReporteCompras.Click += MenuReporteCompras_Click;

            var separador = new ToolStripSeparator();

            var menuStockBajo = new ToolStripMenuItem("Productos con Stock Bajo");
            menuStockBajo.Click += MenuStockBajo_Click;

            menuCompras.DropDownItems.AddRange(new ToolStripItem[]
            {
                menuProveedores,
                menuProductos,
                separador,
                menuOrdenesCompra,
                menuReporteCompras,
                separador,
                menuStockBajo
            });

            menuPrincipal.Items.Add(menuCompras);
        }

        private void AgregarMenuAuditoria()
        {
            MenuStrip menuPrincipal = this.MainMenuStrip ?? this.Controls.OfType<MenuStrip>().FirstOrDefault();

            if (menuPrincipal == null) return;

            var menuAuditoriaCompleta = new ToolStripMenuItem("Auditoría");

            var menuAuditoriaGeneral = new ToolStripMenuItem("Reporte de Auditoría Completa");
            menuAuditoriaGeneral.Click += MenuAuditoriaCompleta_Click;

            var menuTrazabilidadOrdenes = new ToolStripMenuItem("Trazabilidad Órdenes");
            menuTrazabilidadOrdenes.Click += MenuTrazabilidadOrdenes_Click;

            var menuTrazabilidadTickets = new ToolStripMenuItem("Trazabilidad Tickets");
            menuTrazabilidadTickets.Click += MenuTrazabilidadTickets_Click;

            var menuAuditoriaAccesos = new ToolStripMenuItem("Auditoría de Accesos");
            menuAuditoriaAccesos.Click += MenuAuditoriaAccesos_Click;

            menuAuditoriaCompleta.DropDownItems.Add(menuAuditoriaGeneral);
            menuAuditoriaCompleta.DropDownItems.Add(new ToolStripSeparator());
            menuAuditoriaCompleta.DropDownItems.Add(menuTrazabilidadOrdenes);
            menuAuditoriaCompleta.DropDownItems.Add(menuTrazabilidadTickets);
            menuAuditoriaCompleta.DropDownItems.Add(new ToolStripSeparator());
            menuAuditoriaCompleta.DropDownItems.Add(menuAuditoriaAccesos);

            menuPrincipal.Items.Add(menuAuditoriaCompleta);
        }

        private void ConfigurarSeguridad()
        {
            MenuStrip menuPrincipal = this.Controls.OfType<MenuStrip>().FirstOrDefault();

            if (menuPrincipal == null)
            {
                menuPrincipal = new MenuStrip();
                menuPrincipal.Dock = DockStyle.Top;
                this.Controls.Add(menuPrincipal);
                this.MainMenuStrip = menuPrincipal;
            }

            var menuSeguridad = new ToolStripMenuItem("Seguridad");

            var menuUsuarios = new ToolStripMenuItem("Gestión de Usuarios");
            menuUsuarios.Click += MenuUsuarios_Click;

            var menuGrupos = new ToolStripMenuItem("Gestión de Grupos");
            menuGrupos.Click += MenuGrupos_Click;

            var menuCambiarPassword = new ToolStripMenuItem("Cambiar Contraseña");
            menuCambiarPassword.Click += MenuCambiarPassword_Click;

            var menuCerrarSesion = new ToolStripMenuItem("Cerrar Sesión");
            menuCerrarSesion.Click += MenuCerrarSesion_Click;

            menuSeguridad.DropDownItems.Add(menuUsuarios);
            menuSeguridad.DropDownItems.Add(menuGrupos);
            menuSeguridad.DropDownItems.Add(new ToolStripSeparator());
            menuSeguridad.DropDownItems.Add(menuCambiarPassword);
            menuSeguridad.DropDownItems.Add(new ToolStripSeparator());
            menuSeguridad.DropDownItems.Add(menuCerrarSesion);

            menuPrincipal.Items.Add(menuSeguridad);

            var menuReportes = new ToolStripMenuItem("Reportes");

            var menuProductividad = new ToolStripMenuItem("Productividad por Técnico");
            menuProductividad.Click += MenuProductividad_Click;

            var menuDashboard = new ToolStripMenuItem("Dashboard de Tickets");
            menuDashboard.Click += MenuDashboard_Click;

            var menuEstadisticas = new ToolStripMenuItem("Estadísticas Rápidas");
            menuEstadisticas.Click += MenuEstadisticas_Click;

            menuReportes.DropDownItems.Add(menuProductividad);
            menuReportes.DropDownItems.Add(menuDashboard);
            menuReportes.DropDownItems.Add(menuEstadisticas);

            menuPrincipal.Items.Add(menuReportes);

            StatusStrip statusStrip = this.Controls.OfType<StatusStrip>().FirstOrDefault();
            if (statusStrip == null)
            {
                statusStrip = new StatusStrip();
                this.Controls.Add(statusStrip);
            }

            var itemsUsuario = statusStrip.Items.OfType<ToolStripStatusLabel>()
                .Where(item => item.Name == "lblUsuarioLogueado").ToList();
            foreach (var item in itemsUsuario)
            {
                statusStrip.Items.Remove(item);
            }

            var lblUsuario = new ToolStripStatusLabel($"Usuario: {ControladoraSeguridad.Instancia.UsuarioActual?.NombreUsuario}")
            {
                Name = "lblUsuarioLogueado",
                Spring = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            };
            statusStrip.Items.Add(lblUsuario);

            var lblFechaHora = new ToolStripStatusLabel(DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
            {
                Name = "lblFechaHora"
            };
            statusStrip.Items.Add(lblFechaHora);

            var timer = new System.Windows.Forms.Timer { Interval = 60000 }; // 1 minuto
            timer.Tick += (s, e) => lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timer.Start();
        }

        private void ActualizarInterfazSegunPermisos()
        {
            var controladora = ControladoraSeguridad.Instancia;

            if (this.Controls.Find("btnClientes", true).FirstOrDefault() is Button btnClientes)
            {
                btnClientes.Enabled = controladora.TienePermiso("CLIENTES_VER");
                if (!btnClientes.Enabled)
                {
                    btnClientes.Text = "Clientes (Sin acceso)";
                    btnClientes.ForeColor = System.Drawing.Color.Gray;
                }
            }

            if (this.Controls.Find("btnTecnicos", true).FirstOrDefault() is Button btnTecnicos)
            {
                btnTecnicos.Enabled = controladora.TienePermiso("TECNICOS_VER");
                if (!btnTecnicos.Enabled)
                {
                    btnTecnicos.Text = "Técnicos (Sin acceso)";
                    btnTecnicos.ForeColor = System.Drawing.Color.Gray;
                }
            }

            if (this.Controls.Find("btnVehiculos", true).FirstOrDefault() is Button btnVehiculos)
            {
                btnVehiculos.Enabled = controladora.TienePermiso("VEHICULOS_VER");
                if (!btnVehiculos.Enabled)
                {
                    btnVehiculos.Text = "Vehículos (Sin acceso)";
                    btnVehiculos.ForeColor = System.Drawing.Color.Gray;
                }
            }

            if (this.Controls.Find("btnTickets", true).FirstOrDefault() is Button btnTickets)
            {
                btnTickets.Enabled = controladora.TienePermiso("TICKETS_VER");
                if (!btnTickets.Enabled)
                {
                    btnTickets.Text = "Tickets (Sin acceso)";
                    btnTickets.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void MostrarBienvenida()
        {
            var usuario = ControladoraSeguridad.Instancia.UsuarioActual;
            if (usuario != null)
            {
                this.Text = $"Sistema CarFix - Bienvenido {usuario.NombreUsuario}";
            }
        }

        private void MenuProveedores_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("PROVEEDORES_VER"))
            {
                MessageBox.Show("No tiene permisos para ver proveedores", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new FormProveedores();
            form.ShowDialog();
        }

        private void MenuProductos_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("PRODUCTOS_VER"))
            {
                MessageBox.Show("No tiene permisos para ver productos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new FormProductos();
            form.ShowDialog();
        }

        private void MenuOrdenesCompra_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("COMPRAS_VER"))
            {
                MessageBox.Show("No tiene permisos para ver órdenes de compra", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new FormOrdenesCompra();
            form.ShowDialog();
        }

        private void MenuReporteCompras_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("COMPRAS_VER"))
            {
                MessageBox.Show("No tiene permisos para ver reportes de compras", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new FormReporteCompras();
            form.ShowDialog();
        }

        private void MenuStockBajo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("PRODUCTOS_VER"))
            {
                MessageBox.Show("No tiene permisos para ver productos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var productosBajoStock = ControladoraReportesCompras.Instancia.RecuperarProductosBajoStock();

                if (!productosBajoStock.Any())
                {
                    MessageBox.Show("No hay productos con stock bajo", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var mensaje = "Productos con stock bajo:\n\n";
                foreach (var producto in productosBajoStock.Take(10))
                {
                    mensaje += $"• {producto.Nombre} - Stock: {producto.StockActual} (Min: {producto.StockMinimo})\n";
                }

                if (productosBajoStock.Count > 10)
                {
                    mensaje += $"\n... y {productosBajoStock.Count - 10} productos más.";
                }

                MessageBox.Show(mensaje, "Productos con Stock Bajo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuAuditoriaCompleta_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("ADMIN_USUARIOS"))
            {
                var form = new FormReporteAuditoria();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a los reportes de auditoría", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuTrazabilidadOrdenes_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("COMPRAS_VER"))
            {
                var form = new FormReporteAuditoria();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para ver la trazabilidad de órdenes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuTrazabilidadTickets_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                var form = new FormReporteAuditoria();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para ver la trazabilidad de tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuAuditoriaAccesos_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("ADMIN_USUARIOS"))
            {
                var form = new FormReporteAuditoria();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a la auditoría de accesos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Update(string mensaje, object datos)
        {
            switch (mensaje)
            {
                case "ORDEN_CREADA":
                    if (datos is OrdenCompra orden)
                    {
                        MostrarNotificacion($"Nueva orden de compra creada: {orden.Numero}");
                    }
                    break;
                case "ESTADO_CAMBIADO":
                    if (datos is OrdenCompra ordenCambiada)
                    {
                        MostrarNotificacion($"Orden {ordenCambiada.Numero} cambió a estado: {ordenCambiada.Estado}");
                    }
                    break;
            }
        }

        private void MostrarNotificacion(string mensaje)
        {
            var statusStrip = this.Controls.OfType<StatusStrip>().FirstOrDefault();
            if (statusStrip != null && statusStrip.Items.Count > 0)
            {
                var label = statusStrip.Items.OfType<ToolStripStatusLabel>()
                    .FirstOrDefault(l => l.Name == "lblUsuarioLogueado");

                if (label != null)
                {
                    var textoOriginal = label.Text;
                    label.Text = mensaje;

                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 5000;
                    timer.Tick += (s, e) =>
                    {
                        label.Text = textoOriginal;
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NotificadorOrdenesCompra.Instancia.RemoveObserver(this);
            base.OnFormClosed(e);
        }

        private void MenuUsuarios_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("ADMIN_USUARIOS"))
            {
                var formUsuarios = new FormGestionUsuarios();
                formUsuarios.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de usuarios", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuGrupos_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("ADMIN_GRUPOS"))
            {
                var formGrupos = new FormGestionGrupos();
                formGrupos.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de grupos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuCambiarPassword_Click(object sender, EventArgs e)
        {
            var formCambiarPassword = new FormCambiarPassword();
            formCambiarPassword.ShowDialog();
        }

        private void MenuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar la sesión?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ControladoraSeguridad.Instancia.CerrarSesion();
                Application.Restart();
            }
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de técnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FormTecnicos formTecnicos = new FormTecnicos();
            formTecnicos.Owner = this;
            formTecnicos.ShowDialog();
            this.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("CLIENTES_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de clientes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FormClientes formClientes = new FormClientes();
            formClientes.Owner = this;
            formClientes.ShowDialog();
            this.Show();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de vehículos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FormVehiculos formVehiculos = new FormVehiculos();
            formVehiculos.Owner = this;
            formVehiculos.ShowDialog();
            this.Show();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FormTickets formTickets = new FormTickets();
            formTickets.Owner = this;
            formTickets.ShowDialog();
            this.Show();
        }

        private void MenuProductividad_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                var formReporte = new FormReporteProductividad();
                formReporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a los reportes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuDashboard_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                var formDashboard = new FormDashboardTickets();
                formDashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder al dashboard", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuEstadisticas_Click(object sender, EventArgs e)
        {
            if (ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                try
                {
                    var estadisticas = ControladoraReportes.Instancia.ObtenerEstadisticasGenerales();

                    var mensaje = $"ESTADÍSTICAS GENERALES DEL SISTEMA\n\n" +
                                 $"Total de Tickets: {estadisticas["TotalTickets"]}\n" +
                                 $"Tickets Hoy: {estadisticas["TicketsHoy"]}\n" +
                                 $"Tickets Este Mes: {estadisticas["TicketsEsteMes"]}\n" +
                                 $"Técnico Más Productivo: {estadisticas["TecnicoMasProductivo"]}\n" +
                                 $"Promedio Tickets/Técnico: {estadisticas["PromedioTicketsPorTecnico"]:F1}";

                    MessageBox.Show(mensaje, "Estadísticas del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener estadísticas: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a las estadísticas", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}