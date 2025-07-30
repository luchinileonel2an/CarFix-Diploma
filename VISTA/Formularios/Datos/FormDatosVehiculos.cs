using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormDatosVehiculos : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Vehiculo vehiculoActual { get; set; }

        ControladoraClientes clientes;
        public FormDatosVehiculos()
        {
            InitializeComponent();
            clientes = ControladoraClientes.Instancia;
        }

        public DialogResult MostrarDialogo()
        {
            return this.ShowDialog();
        }
        public void ConfigurarOperacion(Operacion operacion, object entidad = null)
        {
            ModoOperacion = operacion;
            if (entidad is Vehiculo vehiculo)
            {
                vehiculoActual = vehiculo;
            }

            switch (operacion)
            {
                case Operacion.Agregar:
                    this.Text = "Agregar Vehiculo";
                    break;
                case Operacion.Modificar:
                    this.Text = "Modificar Vehiculo";
                    break;
                case Operacion.Eliminar:
                    this.Text = "Eliminar Vehiculo";
                    break;
            }
        }

        private void FormDatosVehiculos_Load(object sender, EventArgs e)
        {
            VerificarPermisos();

            if (!this.Visible) return;

            cmbDueño.DataSource = clientes.RecuperarClientes();
            cmbDueño.DisplayMember = "NombreCompleto";

            if (ModoOperacion == Operacion.Modificar || ModoOperacion == Operacion.Eliminar)
            {
                RellenarCampos();
            }

            if (ModoOperacion == Operacion.Eliminar)
            {
                txtMarca.Enabled = false;
                txtModelo.Enabled = false;
                txtDominio.Enabled = false;
                txtAño.Enabled = false;
                cmbDueño.Enabled = false;
            }
        }

        private void RellenarCampos()
        {
            if (vehiculoActual != null)
            {
                txtMarca.Text = vehiculoActual.Marca;
                txtModelo.Text = vehiculoActual.Modelo;
                txtAño.Text = Convert.ToString(vehiculoActual.Año);
                txtDominio.Text = vehiculoActual.Dominio;
                cmbDueño.SelectedItem = vehiculoActual.Dueño;
            }
        }

        private void VerificarPermisos()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            switch (ModoOperacion)
            {
                case Operacion.Agregar:
                    if (!controladoraSeguridad.TienePermiso("VEHICULOS_CREAR"))
                    {
                        MessageBox.Show("No tiene permisos para crear vehiculos", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Modificar:
                    if (!controladoraSeguridad.TienePermiso("VEHICULOS_EDITAR"))
                    {
                        MessageBox.Show("No tiene permisos para editar vehiculos", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Eliminar:
                    if (!controladoraSeguridad.TienePermiso("VEHICULOS_ELIMINAR"))
                    {
                        MessageBox.Show("No tiene permisos para eliminar vehiculos", "Acceso Denegado",
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
                    return controladoraSeguridad.TienePermiso("VEHICULOS_CREAR");
                case Operacion.Modificar:
                    return controladoraSeguridad.TienePermiso("VEHICULOS_EDITAR");
                case Operacion.Eliminar:
                    return controladoraSeguridad.TienePermiso("VEHICULOS_ELIMINAR");
                default:
                    return false;
            }
        }

        private bool ValidacionCampos()
        {
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Ingrese la marca.");
                return false;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo.");
                return false;
            }
            if (string.IsNullOrEmpty(txtDominio.Text))
            {
                MessageBox.Show("Ingrese el Dominio.");
                return false;
            }
            if (string.IsNullOrEmpty(txtAño.Text))
            {
                MessageBox.Show("Ingrese el año.");
                return false;
            }
            if (cmbDueño.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el dueño del vehiculo.");
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
                MessageBox.Show("No tiene permisos para realizar esta operación", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidacionCampos() == true)
            {
                switch (ModoOperacion)
                {
                    case Operacion.Agregar:
                        AgregarVehiculo();
                        break;
                    case Operacion.Modificar:
                        ModificarVehiculo();
                        break;
                    case Operacion.Eliminar:
                        EliminarVehiculo();
                        break;
                }

                ObjectCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void AgregarVehiculo()
        {
            try
            {
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                int año = Convert.ToInt32(txtAño.Text);
                string dominio = txtDominio.Text;
                int clienteId = ((Cliente)cmbDueño.SelectedItem).Id;

                ControladoraVehiculos.Instancia.AgregarVehiculo(clienteId, marca, modelo, año, dominio);

                MessageBox.Show("Vehiculo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el vehiculo: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarVehiculo()
        {
            if (vehiculoActual != null)
            {
                try
                {
                    string marca = txtMarca.Text;
                    string modelo = txtModelo.Text;
                    int año = Convert.ToInt32(txtAño.Text);
                    string dominio = txtDominio.Text;
                    int clienteId = ((Cliente)cmbDueño.SelectedItem).Id;

                    ControladoraVehiculos.Instancia.ModificarVehiculo(vehiculoActual.Id, clienteId, marca, modelo, año, dominio);

                    MessageBox.Show("Vehiculo modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el vehiculo: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarVehiculo()
        {
            if (vehiculoActual != null)
            {
                try
                {

                    ControladoraVehiculos.Instancia.EliminarVehiculo(vehiculoActual.Id);
                    MessageBox.Show("Vehiculo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el vehiculo: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
