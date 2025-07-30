using Controladora;
using Entidades.Core;

namespace Vista
{
    public partial class FormCrearEditarGrupo : Form
    {
        public FormCrearEditarGrupo(Grupo grupo = null)
        {
            grupoAEditar = grupo;
            esEdicion = grupo != null;
            InitializeComponent();

            if (esEdicion)
            {
                CargarDatosGrupo();
                this.Text = "Editar Grupo";
            }
            else
            {
                this.Text = "Crear Grupo";
            }
        }

        private void CargarDatosGrupo()
        {
            if (grupoAEditar != null)
            {
                txtNombre.Text = grupoAEditar.Nombre;
                txtDescripcion.Text = grupoAEditar.Descripcion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre del grupo es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (esEdicion)
                {
                    grupoAEditar.Nombre = txtNombre.Text;
                    grupoAEditar.Descripcion = txtDescripcion.Text;
                    ControladoraSeguridad.Instancia.ActualizarGrupo(grupoAEditar);
                }
                else
                {
                    var nuevoGrupo = new Grupo
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    };
                    ControladoraSeguridad.Instancia.CrearGrupo(nuevoGrupo);
                }

                MessageBox.Show("Grupo guardado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar grupo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
