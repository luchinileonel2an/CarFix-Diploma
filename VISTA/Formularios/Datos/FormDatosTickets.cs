using Controladora;
using Entidades.Tickets;
using Vista.Formularios.Datos;
using Vista.Patrones;
using static Entidades.Tickets.Ticket;

namespace Vista.Formularios.Datos
{
    public partial class FormDatosTickets : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Ticket ticketActual { get; set; }

        private readonly ControladoraTickets controladoraTickets;

        // Entidades seleccionadas
        private Cliente clienteSeleccionado;
        private Vehiculo vehiculoSeleccionado;
        private Tecnico tecnicoSeleccionado;

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

            if (ModoOperacion == Operacion.Modificar || ModoOperacion == Operacion.Eliminar || ModoOperacion == Operacion.VerDetalle)
            {
                RellenarCampos();
            }

            ConfigurarPermisosClienteVehiculo();

            if (ModoOperacion == Operacion.Eliminar || ModoOperacion == Operacion.VerDetalle)
            {
                nudTicket.Enabled = false;
                dtpFecha.Enabled = false;
                txtCliente.Enabled = false;
                txtTecnico.Enabled = false;
                txtVehiculo.Enabled = false;
                txtDescripcion.Enabled = false;
                groupEstados.Enabled = false;
                btnSeleccionarCliente.Enabled = false;
                btnSeleccionarVehiculo.Enabled = false;
                btnSeleccionarTecnico.Enabled = false;
            }

            if (ModoOperacion == Operacion.Eliminar || ModoOperacion == Operacion.VerDetalle)
            {
                nudTicket.Enabled = false;
                dtpFecha.Enabled = false;
                txtCliente.Enabled = false;
                txtTecnico.Enabled = false;
                txtVehiculo.Enabled = false;
                txtDescripcion.Enabled = false;
                groupEstados.Enabled = false;
                btnSeleccionarCliente.Enabled = false;
                btnSeleccionarVehiculo.Enabled = false;
                btnSeleccionarTecnico.Enabled = false;
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

        private void ConfigurarPermisosClienteVehiculo()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            if (ModoOperacion == Operacion.Agregar)
            {
                return;
            }

            if (ModoOperacion == Operacion.Modificar)
            {
                bool puedeModificarCliente = controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_CLIENTE");
                txtCliente.Enabled = puedeModificarCliente;
                btnSeleccionarCliente.Enabled = puedeModificarCliente;

                if (!puedeModificarCliente)
                {
                    txtCliente.BackColor = SystemColors.Control;
                    txtCliente.Cursor = Cursors.No;
                    btnSeleccionarCliente.Cursor = Cursors.No;

                    var toolTip = new ToolTip();
                    toolTip.SetToolTip(txtCliente, "No tiene permisos para modificar el cliente");
                    toolTip.SetToolTip(btnSeleccionarCliente, "No tiene permisos para modificar el cliente");
                }

                bool puedeModificarVehiculo = controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_VEHICULO");
                txtVehiculo.Enabled = puedeModificarVehiculo;
                btnSeleccionarVehiculo.Enabled = puedeModificarVehiculo;

                if (!puedeModificarVehiculo)
                {
                    txtVehiculo.BackColor = SystemColors.Control;
                    txtVehiculo.Cursor = Cursors.No;
                    btnSeleccionarVehiculo.Cursor = Cursors.No;

                    var toolTip = new ToolTip();
                    toolTip.SetToolTip(txtVehiculo, "No tiene permisos para modificar el vehículo");
                    toolTip.SetToolTip(btnSeleccionarVehiculo, "No tiene permisos para modificar el vehículo");
                }
            }
        }
        private void RellenarCampos()
        {
            if (ticketActual != null)
            {
                nudTicket.Value = ticketActual.Id;
                txtDescripcion.Text = ticketActual.Descripcion;
                dtpFecha.Value = ticketActual.FechaCreacion;

                // Establecer las entidades seleccionadas
                clienteSeleccionado = ticketActual.Cliente;
                vehiculoSeleccionado = ticketActual.Vehiculo;
                tecnicoSeleccionado = ticketActual.Tecnico;

                // Mostrar la información en los TextBox
                ActualizarTextoCliente();
                ActualizarTextoVehiculo();
                ActualizarTextoTecnico();

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

        private void ActualizarTextoCliente()
        {
            txtCliente.Text = clienteSeleccionado?.NombreCompleto ?? "Seleccionar cliente...";
        }

        private void ActualizarTextoVehiculo()
        {
            if (vehiculoSeleccionado != null)
            {
                txtVehiculo.Text = $"{vehiculoSeleccionado.Dominio} - {vehiculoSeleccionado.NombreCompleto}";
            }
            else
            {
                txtVehiculo.Text = "Seleccionar vehículo...";
            }
        }

        private void ActualizarTextoTecnico()
        {
            if (tecnicoSeleccionado != null)
            {
                txtTecnico.Text = $"{tecnicoSeleccionado.NombreCompleto} ({tecnicoSeleccionado.Especialidad})";
            }
            else
            {
                txtTecnico.Text = "Seleccionar técnico...";
            }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (ModoOperacion == Operacion.Modificar)
            {
                var controladoraSeguridad = ControladoraSeguridad.Instancia;
                if (!controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_CLIENTE"))
                {
                    MessageBox.Show("No tiene permisos para modificar el cliente del ticket.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var formSeleccion = new FormSeleccionEntidad();
            var clientes = controladoraTickets.Clientes.RecuperarClientes().ToList();

            formSeleccion.ConfigurarSeleccion(clientes, "NombreCompleto", "NombreCompleto", "Seleccionar Cliente");

            if (formSeleccion.ShowDialog() == DialogResult.OK)
            {
                clienteSeleccionado = (Cliente)formSeleccion.EntidadSeleccionada;
                ActualizarTextoCliente();
            }
        }

        private void btnSeleccionarVehiculo_Click(object sender, EventArgs e)
        {
            if (ModoOperacion == Operacion.Modificar)
            {
                var controladoraSeguridad = ControladoraSeguridad.Instancia;
                if (!controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_VEHICULO"))
                {
                    MessageBox.Show("No tiene permisos para modificar el vehículo del ticket.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var formSeleccion = new FormSeleccionEntidad();
            var vehiculos = controladoraTickets.Vehiculos.RecuperarVehiculos().ToList();

            formSeleccion.ConfigurarSeleccion(vehiculos, "NombreCompleto", "Dominio", "Seleccionar Vehículo");

            if (formSeleccion.ShowDialog() == DialogResult.OK)
            {
                vehiculoSeleccionado = (Vehiculo)formSeleccion.EntidadSeleccionada;
                ActualizarTextoVehiculo();
            }
        }

        private void btnSeleccionarTecnico_Click(object sender, EventArgs e)
        {
            var formSeleccion = new FormSeleccionEntidad();
            var tecnicos = controladoraTickets.Tecnicos.RecuperarTecnicos().ToList();

            formSeleccion.ConfigurarSeleccion(tecnicos, "NombreCompleto", "NombreCompleto", "Seleccionar Técnico");

            if (formSeleccion.ShowDialog() == DialogResult.OK)
            {
                tecnicoSeleccionado = (Tecnico)formSeleccion.EntidadSeleccionada;
                ActualizarTextoTecnico();
            }
        }

        private bool ValidacionCampos()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tecnicoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un técnico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rbAsignado.Checked && !rbEnProceso.Checked && !rbFinalizado.Checked)
            {
                MessageBox.Show("Seleccione el estado del ticket.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ModoOperacion == Operacion.Modificar && ticketActual != null)
            {
                var controladoraSeguridad = ControladoraSeguridad.Instancia;

                if (ticketActual.Cliente?.Id != clienteSeleccionado.Id)
                {
                    if (!controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_CLIENTE"))
                    {
                        MessageBox.Show("No tiene permisos para modificar el cliente del ticket.",
                            "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (ticketActual.Vehiculo?.Id != vehiculoSeleccionado.Id)
                {
                    if (!controladoraSeguridad.TienePermiso("TICKETS_MODIFICAR_VEHICULO"))
                    {
                        MessageBox.Show("No tiene permisos para modificar el vehículo del ticket.",
                            "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
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

            if (ValidacionCampos())
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

            return EnumEstados.Asignado;
        }

        private void AgregarTicket()
        {
            try
            {
                int vehiculoId = vehiculoSeleccionado.Id;
                int clienteId = clienteSeleccionado.Id;
                int tecnicoId = tecnicoSeleccionado.Id;
                string descripcion = txtDescripcion.Text;
                DateTime fechaCreacion = dtpFecha.Value;
                EnumEstados estado = ObtenerEstadoSeleccionado();

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
                    int vehiculoId = vehiculoSeleccionado.Id;
                    int clienteId = clienteSeleccionado.Id;
                    int tecnicoId = tecnicoSeleccionado.Id;
                    string descripcion = txtDescripcion.Text;
                    DateTime fechaCreacion = dtpFecha.Value;
                    EnumEstados estado = ObtenerEstadoSeleccionado();

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
                    var confirmacion = MessageBox.Show(
                        $"¿Está seguro que desea eliminar el ticket #{ticketActual.Id}?\n\nEsta acción no se puede deshacer.",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        ControladoraTickets.Instancia.EliminarTicket(ticketActual.Id);
                        MessageBox.Show("Ticket eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return; // No cerrar el formulario si cancela
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el ticket: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (ticketActual != null)
            {
                var formHistorial = new FormHistorialDescripciones(ticketActual.Id);
                formHistorial.ShowDialog();
            }
            else if (ModoOperacion == Operacion.Agregar)
            {
                MessageBox.Show("Debe guardar el ticket primero para ver el historial.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}