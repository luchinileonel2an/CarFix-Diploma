using Controladora;
using Entidades.Tickets;
using Vista.Patrones;

namespace Vista
{
    public partial class FormTecnicos : Form
    {
        ControladoraTecnicos controladoraTecnicos;
        Tecnico tecnicoSeleccionado;
        public FormTecnicos()
        {
            controladoraTecnicos = ControladoraTecnicos.Instancia;

            InitializeComponent();
            VerificarPermisos();
            CargarGrilla();
            ConfigurarGrilla();
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

        public void CargarGrilla()
        {
            dgvTecnicos.DataSource = null;
            dgvTecnicos.DataSource = controladoraTecnicos.RecuperarTecnicos();
        }

        private void ConfigurarGrilla()
        {
            dgvTecnicos.AutoGenerateColumns = false;

            dgvTecnicos.Columns.Clear();

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI"
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido"
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo"
            });
            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad"
            });
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear tecnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Tecnico,
                Operacion.Agregar
            ) as FormDatosTecnicos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }
        private void btnEliminarTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_ELIMINAR"))
            {
                MessageBox.Show("No tiene permisos para eliminar tecnicos", "Acceso Denegado",
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
                    CargarGrilla();
                    formDatos.Close();
                };

                formDatos.MostrarDialogo();
            }
            else
            {
                MessageBox.Show("Seleccione un tecnico para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnModTecnico_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("TECNICOS_EDITAR"))
            {
                MessageBox.Show("No tiene permisos para editar tecnicos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tecnicoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un tecnico para modificar");
                return;
            }

            var formDatos = FormularioFactoryManager.Instancia.CrearFormulario(
                TipoEntidad.Tecnico,
                Operacion.Modificar,
                tecnicoSeleccionado
            ) as FormDatosTecnicos;

            formDatos.ObjectCreated += (s, e) =>
            {
                CargarGrilla();
                formDatos.Close();
            };

            formDatos.MostrarDialogo();
        }

        private void dgvTecnicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTecnicos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTecnicos.SelectedRows[0];
                tecnicoSeleccionado = (Tecnico)row.DataBoundItem;
            }
        }
    }
}
