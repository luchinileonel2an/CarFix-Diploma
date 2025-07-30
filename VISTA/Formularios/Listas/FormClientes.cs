using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormClientes : Form
    {
        ControladoraClientes controladoraClientes;
        Cliente clienteSeleccionado;
        public FormClientes()
        {
            controladoraClientes = ControladoraClientes.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarGrilla();
            ConfigurarGrilla();
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

        public void CargarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = controladoraClientes.RecuperarClientes();
        }

        private void ConfigurarGrilla()
        {
            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Telefono"
            });
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
                CargarGrilla();
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
                    CargarGrilla();
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
                MessageBox.Show("Seleccione un cliente para modificar");
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Cliente,
                Operacion.Modificar,
                clienteSeleccionado
            ) as FormDatosCliente;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvClientes.SelectedRows[0];
                clienteSeleccionado = (Cliente)row.DataBoundItem;
            }
        }
    }
}
