using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public enum Operacion
    {
        Agregar,
        Modificar,
        Eliminar,
        VerDetalle
    }
    public partial class FormDatosTecnicos : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Tecnico tecnicoActual { get; set; }
        public FormDatosTecnicos()
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
            if (entidad is Tecnico tecnico)
            {
                tecnicoActual = tecnico;
            }

            switch (operacion)
            {
                case Operacion.Agregar:
                    this.Text = "Agregar Tecnico";
                    break;
                case Operacion.Modificar:
                    this.Text = "Modificar Tecnico";
                    break;
                case Operacion.Eliminar:
                    this.Text = "Eliminar Tecnico";
                    break;
            }
        }
        private void FormDatosTecnicos_Load(object sender, EventArgs e)
        {
            VerificarPermisos();

            // Solo continuar si el formulario no se cerró por falta de permisos
            if (!this.Visible) return;

            cmbEspecialidad.DataSource = Enum.GetValues(typeof(Tecnico.EnumEspecialidad));

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
                cmbEspecialidad.Enabled = false;
            }
        }

        private void VerificarPermisos()
        {
            var controladoraSeguridad = ControladoraSeguridad.Instancia;

            switch (ModoOperacion)
            {
                case Operacion.Agregar:
                    if (!controladoraSeguridad.TienePermiso("TECNICOS_CREAR"))
                    {
                        MessageBox.Show("No tiene permisos para crear tecnicos", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Modificar:
                    if (!controladoraSeguridad.TienePermiso("TECNICOS_EDITAR"))
                    {
                        MessageBox.Show("No tiene permisos para editar tecnicos", "Acceso Denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    break;

                case Operacion.Eliminar:
                    if (!controladoraSeguridad.TienePermiso("TECNICOS_ELIMINAR"))
                    {
                        MessageBox.Show("No tiene permisos para eliminar tecnicos", "Acceso Denegado",
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
                    return controladoraSeguridad.TienePermiso("TECNICOS_CREAR");
                case Operacion.Modificar:
                    return controladoraSeguridad.TienePermiso("TECNICOS_EDITAR");
                case Operacion.Eliminar:
                    return controladoraSeguridad.TienePermiso("TECNICOS_ELIMINAR");
                default:
                    return false;
            }
        }
        private void RellenarCampos()
        {
            if (tecnicoActual != null)
            {
                txtNombre.Text = tecnicoActual.Nombre;
                txtApellido.Text = tecnicoActual.Apellido;
                txtDNI.Text = Convert.ToString(tecnicoActual.Dni);
                txtCorreo.Text = tecnicoActual.Correo;
                cmbEspecialidad.SelectedItem = tecnicoActual.Especialidad;
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
            if (cmbEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la especialidad.");
                return false;
            }

            return true;

        }

        public delegate void ObjectCreatedEventHandler(object sender, EventArgs e);
        public event ObjectCreatedEventHandler ObjectCreated;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidacionCampos() == true)
            {
                switch (ModoOperacion)
                {
                    case Operacion.Agregar:
                        AgregarTecnico();
                        break;
                    case Operacion.Modificar:
                        ModificarTecnico();
                        break;
                    case Operacion.Eliminar:
                        EliminarTecnico();
                        break;
                }

                ObjectCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
        private void AgregarTecnico()
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int dni = Convert.ToInt32(txtDNI.Text);
                string correo = txtCorreo.Text;
                Tecnico.EnumEspecialidad especialidad = (Tecnico.EnumEspecialidad)cmbEspecialidad.SelectedItem;

                ControladoraTecnicos.Instancia.AgregarTecnico(nombre, apellido, dni, correo, especialidad);

                MessageBox.Show("Tecnico agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el tecnico: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarTecnico()
        {
            if (tecnicoActual != null)
            {
                try
                {
                    int id = tecnicoActual.Id;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    int dni = Convert.ToInt32(txtDNI.Text);
                    string correo = txtCorreo.Text;
                    Tecnico.EnumEspecialidad especialidad = (Tecnico.EnumEspecialidad)cmbEspecialidad.SelectedItem;

                    ControladoraTecnicos.Instancia.ModificarTecnico(id, nombre, apellido, dni, correo, especialidad);

                    MessageBox.Show("Tecnico modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el tecnico: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EliminarTecnico()
        {
            if (tecnicoActual != null)
            {
                try
                {

                    ControladoraTecnicos.Instancia.EliminarTecnico(tecnicoActual.Id);
                    MessageBox.Show("Tecnico eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el tecnico: {ex.Message}\nDetalles: {ex.InnerException?.Message}",
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
