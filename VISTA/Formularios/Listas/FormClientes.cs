using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormClientes : Form
    {
        private ControladoraClientes controladoraClientes;
        private Cliente clienteSeleccionado;
        private List<Cliente> listaClientesCompleta;
        private List<Cliente> listaClientesFiltrada;

        public FormClientes()
        {
            controladoraClientes = ControladoraClientes.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarDatos();
            ConfigurarGrilla();
            ConfigurarBusqueda();
        }

        private void VerificarPermisos()
        {
            var controladora = ControladoraSeguridad.Instancia;

            if (!controladora.TienePermiso("CLIENTES_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            btnAgregarCliente.Enabled = controladora.TienePermiso("CLIENTES_CREAR");
            btnModCliente.Enabled = controladora.TienePermiso("CLIENTES_EDITAR");
            btnEliminarCliente.Enabled = controladora.TienePermiso("CLIENTES_ELIMINAR");
        }

        private void CargarDatos()
        {
            try
            {
                listaClientesCompleta = controladoraClientes.RecuperarClientes().ToList();
                listaClientesFiltrada = new List<Cliente>(listaClientesCompleta);
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
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientesFiltrada;
        }

        private void ActualizarContador()
        {
            lblContador.Text = $"Mostrando {listaClientesFiltrada.Count} de {listaClientesCompleta.Count} clientes";
        }

        private void ConfigurarGrilla()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI",
                Width = 100
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 150
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 150
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Width = 200
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 120
            });

            // Configuración adicional de la grilla
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
        }

        private void ConfigurarBusqueda()
        {
            txtBuscar.Text = "Buscar por nombre, apellido, DNI o correo...";
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

                if (textoBusqueda == "buscar por nombre, apellido, dni o correo..." || string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    listaClientesFiltrada = new List<Cliente>(listaClientesCompleta);
                }
                else
                {
                    listaClientesFiltrada = listaClientesCompleta.Where(cliente =>
                        cliente.Nombre.ToLower().Contains(textoBusqueda) ||
                        cliente.Apellido.ToLower().Contains(textoBusqueda) ||
                        cliente.Dni.ToString().Contains(textoBusqueda) ||
                        cliente.Correo.ToLower().Contains(textoBusqueda) ||
                        cliente.Telefono.ToString().Contains(textoBusqueda) ||
                        cliente.NombreCompleto.ToLower().Contains(textoBusqueda)
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
            if (txtBuscar.Text == "Buscar por nombre, apellido, DNI o correo...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar por nombre, apellido, DNI o correo...";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "Buscar por nombre, apellido, DNI o correo...";
            txtBuscar.ForeColor = SystemColors.GrayText;
            listaClientesFiltrada = new List<Cliente>(listaClientesCompleta);
            ActualizarGrilla();
            ActualizarContador();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvClientes.SelectedRows[0];
                clienteSeleccionado = (Cliente)row.DataBoundItem;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("CLIENTES_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear clientes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Cliente,
                Operacion.Agregar
            ) as FormDatosCliente;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de agregar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("CLIENTES_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar clientes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvClientes.SelectedRows.Count > 0)
            {
                var cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;

                var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                    TipoEntidad.Cliente,
                    Operacion.Eliminar,
                    cliente
                ) as FormDatosCliente;

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
                MessageBox.Show("Seleccione un cliente para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModCliente_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("CLIENTES_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar clientes", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente para modificar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Cliente,
                Operacion.Modificar,
                clienteSeleccionado
            ) as FormDatosCliente;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de modificar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        // Evento para doble clic en la grilla (modificar cliente)
        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null && btnModCliente.Enabled)
            {
                btnModCliente_Click(sender, e);
            }
        }

        // Navegación por teclado
        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && clienteSeleccionado != null && btnModCliente.Enabled)
            {
                btnModCliente_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && clienteSeleccionado != null && btnEliminarCliente.Enabled)
            {
                btnEliminarCliente_Click(sender, e);
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
            else if (e.KeyCode == Keys.Down && dgvClientes.Rows.Count > 0)
            {
                dgvClientes.Focus();
                dgvClientes.Rows[0].Selected = true;
                e.Handled = true;
            }
        }
    }
}