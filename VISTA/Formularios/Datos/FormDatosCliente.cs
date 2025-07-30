using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormDatosCliente : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Cliente clienteActual { get; set; }
        public FormDatosCliente()
        {
            InitializeComponent();
        }
        public DialogResult MostrarDialogo()
        {
            return this.ShowDialog();
        }

        public void ConfigurarOperacion(Operacion operacion, object entidad = null)
        {
            ModoOperacion = operacion;
            if (entidad is Cliente cliente)
            {
                clienteActual = cliente;
            }

            // Configurar título según operación
            switch (operacion)
            {
                case Operacion.Agregar:
                    this.Text = "Agregar Cliente";
                    break;
                case Operacion.Modificar:
                    this.Text = "Modificar Cliente";
                    break;
                case Operacion.Eliminar:
                    this.Text = "Eliminar Cliente";
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDatosCliente_Load(object sender, EventArgs e)
        {
            VerificarPermisos();

            // Solo continuar si el formulario no se cerró por falta de permisos
            if (!this.Visible) return;

            if (ModoOperacion == Operacion.Modificar || ModoOperacion == Operacion.Eliminar)
            {
                RellenarCampos();
            }

            if (ModoOperacion == Operacion.Eliminar)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDNI.Enabled = false;
                txtCorreo.Enabled = false;
                txtTelefono.Enabled = false;
            }
        }

        private void RellenarCampos()
        {
            if (clienteActual != null)
            {
                txtNombre.Text = clienteActual.Nombre;
                txtApellido.Text = clienteActual.Apellido;
                txtDNI.Text = Convert.ToString(clienteActual.Dni);
                txtCorreo.Text = clienteActual.Correo;
                txtTelefono.Text = Convert.ToString(clienteActual.Telefono);
            }
        }

        private void VerificarPermisos()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            switch (ModoOperacion)
            {
                case Operacion.Agregar:
                    if (!controladoraSeguridad.TienePermiso("CLIENTES_CREAR"))
                    {
                        MessageBox.Show("No tiene permisos para crear clientes", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Modificar:
                    if (!controladoraSeguridad.TienePermiso("CLIENTES_EDITAR"))
                    {
                        MessageBox.Show("No tiene permisos para editar clientes", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Eliminar:
                    if (!controladoraSeguridad.TienePermiso("CLIENTES_ELIMINAR"))
                    {
                        MessageBox.Show("No tiene permisos para eliminar clientes", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;
            }
            btnAceptar.Enabled = TienePermisoParaOperacion();
        }

        private bool TienePermisoParaOperacion()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            switch (ModoOperacion)
            {
                case Operacion.Agregar:
                    return controladoraSeguridad.TienePermiso("CLIENTES_CREAR");
                case Operacion.Modificar:
                    return controladoraSeguridad.TienePermiso("CLIENTES_EDITAR");
                case Operacion.Eliminar:
                    return controladoraSeguridad.TienePermiso("CLIENTES_ELIMINAR");
                default:
                    return false;
            }
        }

        private bool ValidacionCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.");
                return false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido.");
                return false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                MessageBox.Show("Ingrese el DNI.");
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo.");
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el telefono.");
                return false;
            }

            return true;

        }

        public delegate void ObjectCreatedEventHandler(object sender, EventArgs e);
        public event ObjectCreatedEventHandler ObjectCreated;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!TienePermisoParaOperacion())
            {
                MessageBox.Show("No tiene permisos para realizar esta operación.", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidacionCampos() == true)
            {
                switch (ModoOperacion)
                {
                    case Operacion.Agregar:
                        AgregarCliente();
                        break;
                    case Operacion.Modificar:
                        ModificarCliente();
                        break;
                    case Operacion.Eliminar:
                        EliminarCliente();
                        break;
                }

                ObjectCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
        private void AgregarCliente()
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int dni = Convert.ToInt32(txtDNI.Text);
                string correo = txtCorreo.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);

                ControladoraClientes.Instancia.AgregarCliente(nombre, apellido, dni, correo, telefono);

                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el cliente: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarCliente()
        {
            if (clienteActual != null)
            {
                try
                {
                    int id = clienteActual.Id;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    int dni = Convert.ToInt32(txtDNI.Text);
                    string correo = txtCorreo.Text;
                    int telefono = Convert.ToInt32(txtTelefono.Text);

                    ControladoraClientes.Instancia.ModificarCliente(id, nombre, apellido, dni, correo, telefono);

                    MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el cliente: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EliminarCliente()
        {
            if (clienteActual != null)
            {
                try
                {

                    ControladoraClientes.Instancia.EliminarCliente(clienteActual.Id);
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el cliente: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
