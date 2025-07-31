using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormVehiculos : Form
    {
        private ControladoraVehiculos controladoraVehiculos;
        private Vehiculo vehiculoSeleccionado;
        private List<Vehiculo> listaVehiculosCompleta;
        private List<Vehiculo> listaVehiculosFiltrada;

        public FormVehiculos()
        {
            controladoraVehiculos = ControladoraVehiculos.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarDatos();
            ConfigurarGrilla();
            ConfigurarBusqueda();
        }

        private void VerificarPermisos()
        {
            var controladora = ControladoraSeguridad.Instancia;

            if (!controladora.TienePermiso("VEHICULOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            btnAgregarVehiculo.Enabled = controladora.TienePermiso("VEHICULOS_CREAR");
            btnModVehiculo.Enabled = controladora.TienePermiso("VEHICULOS_EDITAR");
            btnEliminarVehiculo.Enabled = controladora.TienePermiso("VEHICULOS_ELIMINAR");
        }

        private void CargarDatos()
        {
            try
            {
                listaVehiculosCompleta = controladoraVehiculos.RecuperarVehiculos().ToList();
                listaVehiculosFiltrada = new List<Vehiculo>(listaVehiculosCompleta);
                ActualizarGrilla();
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrilla()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = listaVehiculosFiltrada;
        }

        private void ActualizarContador()
        {
            lblContador.Text = $"Mostrando {listaVehiculosFiltrada.Count} de {listaVehiculosCompleta.Count} vehículos";
        }

        private void ConfigurarGrilla()
        {
            dgvVehiculos.AutoGenerateColumns = false;
            dgvVehiculos.Columns.Clear();

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Marca",
                HeaderText = "Marca",
                Width = 120
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modelo",
                HeaderText = "Modelo",
                Width = 150
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Año",
                HeaderText = "Año",
                Width = 80
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dominio",
                HeaderText = "Dominio",
                Width = 100
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoDueño",
                HeaderText = "Dueño",
                Width = 200
            });

            // Configuración adicional de la grilla
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
        }

        private void ConfigurarBusqueda()
        {
            txtBuscar.Text = "Buscar por marca, modelo, año, dominio o dueño...";
            txtBuscar.ForeColor = SystemColors.GrayText;

            var timerBusqueda = new System.Windows.Forms.Timer();
            timerBusqueda.Interval = 300; // 300ms de delay
            timerBusqueda.Tick += (s, e) =>
            {
                timerBusqueda.Stop();
                AplicarFiltros();
            };

            txtBuscar.TextChanged += (s, e) =>
            {
                timerBusqueda.Stop();
                timerBusqueda.Start();
            };
        }

        private void AplicarFiltros()
        {
            try
            {
                string textoBusqueda = txtBuscar.Text.ToLower();

                if (textoBusqueda == "buscar por marca, modelo, año, dominio o dueño..." || string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    listaVehiculosFiltrada = new List<Vehiculo>(listaVehiculosCompleta);
                }
                else
                {
                    listaVehiculosFiltrada = listaVehiculosCompleta.Where(vehiculo =>
                        vehiculo.Marca.ToLower().Contains(textoBusqueda) ||
                        vehiculo.Modelo.ToLower().Contains(textoBusqueda) ||
                        vehiculo.Año.ToString().Contains(textoBusqueda) ||
                        vehiculo.Dominio.ToLower().Contains(textoBusqueda) ||
                        vehiculo.NombreCompletoDueño.ToLower().Contains(textoBusqueda)
                    ).ToList();
                }

                ActualizarGrilla();
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por marca, modelo, año, dominio o dueño...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar por marca, modelo, año, dominio o dueño...";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "Buscar por marca, modelo, año, dominio o dueño...";
            txtBuscar.ForeColor = SystemColors.GrayText;
            listaVehiculosFiltrada = new List<Vehiculo>(listaVehiculosCompleta);
            ActualizarGrilla();
            ActualizarContador();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvVehiculos.SelectedRows[0];
                vehiculoSeleccionado = (Vehiculo)row.DataBoundItem;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear vehículos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Vehiculo,
                Operacion.Agregar
            ) as FormDatosVehiculos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de agregar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar vehículos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVehiculos.SelectedRows.Count > 0)
            {
                var vehiculo = (Vehiculo)dgvVehiculos.SelectedRows[0].DataBoundItem;

                var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                    TipoEntidad.Vehiculo,
                    Operacion.Eliminar,
                    vehiculo
                ) as FormDatosVehiculos; // CORREGIDO: era FormDatosCliente, ahora es FormDatosVehiculos

                formDatos.Owner = this;
                formDatos.ObjectCreated += (s, e) =>
                {
                    CargarDatos(); // Recargar datos después de eliminar
                    formDatos.Close();
                };

                formDatos.MostrarDialogo();
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModVehiculo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar vehículos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un vehículo para modificar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Vehiculo,
                Operacion.Modificar,
                vehiculoSeleccionado
            ) as FormDatosVehiculos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de modificar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        // Evento para doble clic en la grilla (modificar vehículo)
        private void dgvVehiculos_DoubleClick(object sender, EventArgs e)
        {
            if (vehiculoSeleccionado != null && btnModVehiculo.Enabled)
            {
                btnModVehiculo_Click(sender, e);
            }
        }

        // Navegación por teclado
        private void dgvVehiculos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && vehiculoSeleccionado != null && btnModVehiculo.Enabled)
            {
                btnModVehiculo_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && vehiculoSeleccionado != null && btnEliminarVehiculo.Enabled)
            {
                btnEliminarVehiculo_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnRefrescar_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnLimpiarFiltros_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down && dgvVehiculos.Rows.Count > 0)
            {
                dgvVehiculos.Focus();
                dgvVehiculos.Rows[0].Selected = true;
                e.Handled = true;
            }
        }
    }
}