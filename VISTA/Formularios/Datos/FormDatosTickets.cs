using Controladora;
using Entidades.Tickets;
using Vista.Patrones;
using static Entidades.Tickets.Ticket;

namespace Vista
{
    public partial class FormDatosTickets : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Ticket ticketActual { get; set; }

        private readonly ControladoraTickets controladoraTickets;

        public FormDatosTickets()
        {
            InitializeComponent();
            controladoraTickets = ControladoraTickets.Instancia;
        }
        public DialogResult MostrarDialogo()
        {
            return this.ShowDialog();
        }
        public void ConfigurarOperacion(Operacion operacion, object entidad = null)
        {
            ModoOperacion = operacion;
            if (entidad is Ticket ticket)
            {
                ticketActual = ticket;
            }

            switch (operacion)
            {
                case Operacion.Agregar:
                    this.Text = "Agregar Ticket";
                    break;
                case Operacion.Modificar:
                    this.Text = "Modificar Ticket";
                    break;
                case Operacion.Eliminar:
                    this.Text = "Eliminar Ticket";
                    break;
                case Operacion.VerDetalle:
                    this.Text = "Detalles del ticket";
                    break;
            }
        }

        private void FormDatosTickets_Load(object sender, EventArgs e)
        {
            VerificarPermisos();

            if (!this.Visible) return;

            cmbCliente.DataSource = controladoraTickets.Clientes.RecuperarClientes();
            cmbCliente.DisplayMember = "NombreCompleto";

            cmbVehiculo.DataSource = controladoraTickets.Vehiculos.RecuperarVehiculos();
            cmbVehiculo.DisplayMember = "Dominio";

            cmbTecnico.DataSource = controladoraTickets.Tecnicos.RecuperarTecnicos();
            cmbTecnico.DisplayMember = "NombreCompleto";

            if (ModoOperacion == Operacion.Modificar || ModoOperacion == Operacion.Eliminar || ModoOperacion == Operacion.VerDetalle)
            {
                RellenarCampos();
            }

            if (ModoOperacion == Operacion.Eliminar || ModoOperacion == Operacion.VerDetalle)
            {
                nudTicket.Enabled = false;
                dtpFecha.Enabled = false;
                cmbCliente.Enabled = false;
                cmbTecnico.Enabled = false;
                cmbVehiculo.Enabled = false;
                txtDescripcion.Enabled = false;
                groupEstados.Enabled = false;
            }
        }

        private void VerificarPermisos()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            switch (ModoOperacion)
            {
                case Operacion.Agregar:
                    if (!controladoraSeguridad.TienePermiso("TICKETS_CREAR"))
                    {
                        MessageBox.Show("No tiene permisos para crear tickets", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Modificar:
                    if (!controladoraSeguridad.TienePermiso("TICKETS_EDITAR"))
                    {
                        MessageBox.Show("No tiene permisos para editar tickets", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Eliminar:
                    if (!controladoraSeguridad.TienePermiso("TICKETS_ELIMINAR"))
                    {
                        MessageBox.Show("No tiene permisos para eliminar tickets", "Acceso Denegado",
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
                    return controladoraSeguridad.TienePermiso("TICKETS_CREAR");
                case Operacion.Modificar:
                    return controladoraSeguridad.TienePermiso("TICKETS_EDITAR");
                case Operacion.Eliminar:
                    return controladoraSeguridad.TienePermiso("TICKETS_ELIMINAR");
                default:
                    return false;
            }
        }

        private void RellenarCampos()
        {
            if (ticketActual != null)
            {
                nudTicket.Value = ticketActual.Id;
                txtDescripcion.Text = ticketActual.Descripcion;
                dtpFecha.Value = ticketActual.FechaCreacion;
                cmbCliente.SelectedItem = ticketActual.Cliente;
                cmbTecnico.SelectedItem = ticketActual.Tecnico;
                cmbVehiculo.SelectedItem = ticketActual.Vehiculo;

                rbAsignado.Checked = false;
                rbEnProceso.Checked = false;
                rbFinalizado.Checked = false;

                switch (ticketActual.Estado)
                {
                    case EnumEstados.EnProceso:
                        rbEnProceso.Checked = true;
                        break;
                    case EnumEstados.Asignado:
                        rbAsignado.Checked = true;
                        break;
                    case EnumEstados.Finalizado:
                        rbFinalizado.Checked = true;
                        break;
                }
            }
        }

        private bool ValidacionCampos()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripcion.");
                return false;
            }
            if (string.IsNullOrEmpty(dtpFecha.Text))
            {
                MessageBox.Show("Ingrese la fecha.");
                return false;
            }
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Ingrese el cliente.");
                return false;
            }
            if (cmbTecnico.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tecnico.");
                return false;
            }

            if (cmbVehiculo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el vehiculo.");
                return false;
            }

            if (!rbAsignado.Checked && !rbEnProceso.Checked && !rbFinalizado.Checked)
            {
                MessageBox.Show("Seleccione el estado del ticket.");
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
                        AgregarTicket();
                        break;
                    case Operacion.Modificar:
                        ModificarTicket();
                        break;
                    case Operacion.Eliminar:
                        EliminarTicket();
                        break;
                }

                ObjectCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
        private EnumEstados ObtenerEstadoSeleccionado()
        {
            if (rbAsignado.Checked) return EnumEstados.Asignado;
            if (rbEnProceso.Checked) return EnumEstados.EnProceso;
            if (rbFinalizado.Checked) return EnumEstados.Finalizado;

            // Por defecto, asignado
            return EnumEstados.Asignado;
        }

        private void AgregarTicket()
        {
            try
            {
                int vehiculoId = ((Vehiculo)cmbVehiculo.SelectedItem).Id;
                int clienteId = ((Cliente)cmbCliente.SelectedItem).Id;
                int tecnicoId = ((Tecnico)cmbTecnico.SelectedItem).Id;
                string descripcion = txtDescripcion.Text;
                DateTime fechaCreacion = dtpFecha.Value;
                EnumEstados estado = ObtenerEstadoSeleccionado(); // AGREGAR ESTA LÍNEA

                // MODIFICAR la llamada para incluir el estado
                ControladoraTickets.Instancia.AgregarTicket(vehiculoId, clienteId, tecnicoId, descripcion, fechaCreacion, estado);

                MessageBox.Show("Ticket agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ticket: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarTicket()
        {
            if (ticketActual != null)
            {
                try
                {
                    int vehiculoId = ((Vehiculo)cmbVehiculo.SelectedItem).Id;
                    int clienteId = ((Cliente)cmbCliente.SelectedItem).Id;
                    int tecnicoId = ((Tecnico)cmbTecnico.SelectedItem).Id;
                    string descripcion = txtDescripcion.Text;
                    DateTime fechaCreacion = dtpFecha.Value;
                    EnumEstados estado = ObtenerEstadoSeleccionado(); // AGREGAR ESTA LÍNEA

                    // MODIFICAR la llamada para incluir el estado
                    ControladoraTickets.Instancia.ModificarTicket(ticketActual.Id, vehiculoId, clienteId, tecnicoId, descripcion, fechaCreacion, estado);

                    MessageBox.Show("Ticket modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el ticket: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarTicket()
        {
            if (ticketActual != null)
            {
                try
                {

                    ControladoraTickets.Instancia.EliminarTicket(ticketActual.Id);
                    MessageBox.Show("Ticket eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el ticket: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
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
