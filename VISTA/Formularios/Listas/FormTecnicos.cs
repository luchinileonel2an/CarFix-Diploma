using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormTecnicos : Form
    {
        private ControladoraTecnicos controladoraTecnicos;
        private Tecnico tecnicoSeleccionado;
        private List<Tecnico> listaTecnicosCompleta;
        private List<Tecnico> listaTecnicosFiltrada;

        public FormTecnicos()
        {
            controladoraTecnicos = ControladoraTecnicos.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarDatos();
            ConfigurarGrilla();
            ConfigurarBusqueda();
        }

        private void VerificarPermisos()
        {
            var controladora = ControladoraSeguridad.Instancia;

            if (!controladora.TienePermiso("TECNICOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            btnAgregarTecnico.Enabled = controladora.TienePermiso("TECNICOS_CREAR");
            btnModTecnico.Enabled = controladora.TienePermiso("TECNICOS_EDITAR");
            btnEliminarTecnico.Enabled = controladora.TienePermiso("TECNICOS_ELIMINAR");
        }

        private void CargarDatos()
        {
            try
            {
                listaTecnicosCompleta = controladoraTecnicos.RecuperarTecnicos().ToList();
                listaTecnicosFiltrada = new List<Tecnico>(listaTecnicosCompleta);
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
            dgvTecnicos.DataSource = null;
            dgvTecnicos.DataSource = listaTecnicosFiltrada;
        }

        private void ActualizarContador()
        {
            lblContador.Text = $"Mostrando {listaTecnicosFiltrada.Count} de {listaTecnicosCompleta.Count} técnicos";
        }

        private void ConfigurarGrilla()
        {
            dgvTecnicos.AutoGenerateColumns = false;
            dgvTecnicos.Columns.Clear();

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI",
                Width = 100
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 150
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 150
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Width = 200
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                Width = 150
            });

            // Configuración adicional de la grilla
            dgvTecnicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTecnicos.MultiSelect = false;
            dgvTecnicos.ReadOnly = true;
            dgvTecnicos.AllowUserToAddRows = false;
            dgvTecnicos.AllowUserToDeleteRows = false;
        }

        private void ConfigurarBusqueda()
        {
            txtBuscar.Text = "Buscar por nombre, apellido, DNI, correo o especialidad...";
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

                if (textoBusqueda == "buscar por nombre, apellido, dni, correo o especialidad..." || string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    listaTecnicosFiltrada = new List<Tecnico>(listaTecnicosCompleta);
                }
                else
                {
                    listaTecnicosFiltrada = listaTecnicosCompleta.Where(tecnico =>
                        tecnico.Nombre.ToLower().Contains(textoBusqueda) ||
                        tecnico.Apellido.ToLower().Contains(textoBusqueda) ||
                        tecnico.Dni.ToString().Contains(textoBusqueda) ||
                        tecnico.Correo.ToLower().Contains(textoBusqueda) ||
                        tecnico.Especialidad.ToString().ToLower().Contains(textoBusqueda) ||
                        tecnico.NombreCompleto.ToLower().Contains(textoBusqueda)
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
            if (txtBuscar.Text == "Buscar por nombre, apellido, DNI, correo o especialidad...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar por nombre, apellido, DNI, correo o especialidad...";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "Buscar por nombre, apellido, DNI, correo o especialidad...";
            txtBuscar.ForeColor = SystemColors.GrayText;
            listaTecnicosFiltrada = new List<Tecnico>(listaTecnicosCompleta);
            ActualizarGrilla();
            ActualizarContador();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvTecnicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTecnicos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTecnicos.SelectedRows[0];
                tecnicoSeleccionado = (Tecnico)row.DataBoundItem;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear técnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Tecnico,
                Operacion.Agregar
            ) as FormDatosTecnicos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de agregar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnEliminarTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar técnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvTecnicos.SelectedRows.Count > 0)
            {
                var tecnico = (Tecnico)dgvTecnicos.SelectedRows[0].DataBoundItem;

                var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                    TipoEntidad.Tecnico,
                    Operacion.Eliminar,
                    tecnico
                ) as FormDatosTecnicos;

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
                MessageBox.Show("Seleccione un técnico para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar técnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tecnicoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un técnico para modificar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Tecnico,
                Operacion.Modificar,
                tecnicoSeleccionado
            ) as FormDatosTecnicos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarDatos(); // Recargar datos después de modificar
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        // Evento para doble clic en la grilla (modificar técnico)
        private void dgvTecnicos_DoubleClick(object sender, EventArgs e)
        {
            if (tecnicoSeleccionado != null && btnModTecnico.Enabled)
            {
                btnModTecnico_Click(sender, e);
            }
        }

        // Navegación por teclado
        private void dgvTecnicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tecnicoSeleccionado != null && btnModTecnico.Enabled)
            {
                btnModTecnico_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && tecnicoSeleccionado != null && btnEliminarTecnico.Enabled)
            {
                btnEliminarTecnico_Click(sender, e);
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
            else if (e.KeyCode == Keys.Down && dgvTecnicos.Rows.Count > 0)
            {
                dgvTecnicos.Focus();
                dgvTecnicos.Rows[0].Selected = true;
                e.Handled = true;
            }
        }
    }
}