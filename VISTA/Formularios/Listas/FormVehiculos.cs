using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormVehiculos : Form
    {

        ControladoraVehiculos controladoraVehiculos;
        Vehiculo vehiculoSeleccionado;
        public FormVehiculos()
        {
            controladoraVehiculos = ControladoraVehiculos.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarGrilla();
            ConfigurarGrilla();
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
        public void CargarGrilla()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = controladoraVehiculos.RecuperarVehiculos();
        }

        private void ConfigurarGrilla()
        {
            dgvVehiculos.AutoGenerateColumns = false;

            dgvVehiculos.Columns.Clear();

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Marca",
                HeaderText = "Marca"
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modelo",
                HeaderText = "Modelo"
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Año",
                HeaderText = "Año"
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dominio",
                HeaderText = "Dominio"
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoDueño",
                HeaderText = "Dueño"
            });
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
                MessageBox.Show("No tiene permisos para crear vehiculos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Vehiculo,
                Operacion.Agregar
            ) as FormDatosVehiculos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar vehiculos", "Acceso Denegado",
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
                ) as FormDatosCliente;

                formDatos.Owner = this;
                formDatos.ObjectCreated += (s, e) =>
                {
                    CargarGrilla();
                    formDatos.Close();
                };

                formDatos.MostrarDialogo();
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModVehiculo_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("VEHICULOS_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar vehiculos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un vehiculo para modificar");
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Vehiculo,
                Operacion.Modificar,
                vehiculoSeleccionado
            ) as FormDatosVehiculos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }
    }
}
