using Controladora;
using Entidades.Tickets;
using Vista.Patrones;
using Vista.Formularios.Datos;

namespace Vista
{
    public partial class FormTickets : Form
    {
        ControladoraTickets controladoraTickets;
        Ticket ticketSeleccionado;
        public FormTickets()
        {
            controladoraTickets = ControladoraTickets.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarGrilla();
            ConfigurarGrilla();
        }

        private BindingSource bsTickets = new BindingSource();

        private void VerificarPermisos()
        {
            var controladora = ControladoraSeguridad.Instancia;

            if (!controladora.TienePermiso("TICKETS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            btnAgregarTicket.Enabled = controladora.TienePermiso("TICKETS_CREAR");
            btnModTicket.Enabled = controladora.TienePermiso("TICKETS_EDITAR");
            btnEliminarTicket.Enabled = controladora.TienePermiso("TICKETS_ELIMINAR");
        }

        public void CargarGrilla()
        {
            dgvTickets.DataSource = null;
            var tickets = controladoraTickets.RecuperarTickets();
            bsTickets.DataSource = tickets;
            dgvTickets.DataSource = bsTickets;
            bsTickets.ResetBindings(false);
        }

        private void ConfigurarGrilla()
        {
            dgvTickets.AutoGenerateColumns = false;

            dgvTickets.Columns.Clear();

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Nro.Ticket"
            });
            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoVehiculo",
                HeaderText = "Vehiculo"
            });
            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoCliente",
                HeaderText = "Cliente"
            });
            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoTecnico",
                HeaderText = "Tecnico"
            });
            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado"
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaCreacion",
                HeaderText = "Fecha de Creacion"
            });
        }

        private void dgvTickets_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTickets.SelectedRows[0];
                ticketSeleccionado = (Ticket)row.DataBoundItem;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarTicket_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TICKETS_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Ticket,
                Operacion.Agregar
            ) as FormDatosTickets;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnEliminarTicket_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TICKETS_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvTickets.SelectedRows.Count > 0)
            {
                var ticket = (Ticket)dgvTickets.SelectedRows[0].DataBoundItem;

                var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                    TipoEntidad.Ticket,
                    Operacion.Eliminar,
                    ticket
                ) as FormDatosTickets;

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
                MessageBox.Show("Seleccione un ticket para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModTicket_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TICKETS_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ticketSeleccionado == null)
            {
                MessageBox.Show("Seleccione un ticket para modificar");
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Ticket,
                Operacion.Modificar,
                ticketSeleccionado
            ) as FormDatosTickets;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TICKETS_VER"))
            {
                MessageBox.Show("No tiene permisos para ver detalles de tickets", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvTickets.SelectedRows.Count > 0)
            {
                var ticket = (Ticket)dgvTickets.SelectedRows[0].DataBoundItem;

                var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                    TipoEntidad.Ticket,
                    Operacion.VerDetalle,
                    ticket
                ) as FormDatosTickets;

                formDatos.ObjectCreated += (s, e) =>
                {
                    CargarGrilla();
                    formDatos.Close();
                };

                formDatos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para ver detalles", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
