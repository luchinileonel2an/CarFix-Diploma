using Controladora;
using Entidades.Core;

namespace Vista
{
    public partial class FormCrearEditarUsuario : Form
    {
        public FormCrearEditarUsuario(Usuario usuario = null)
        {
            usuarioAEditar = usuario;
            esEdicion = usuario != null;
            InitializeComponent();

            if (esEdicion)
            {
                CargarDatosUsuario();
                this.Text = "Editar Usuario";
            }
            else
            {
                this.Text = "Crear Usuario";
            }
        }

        private void CargarDatosUsuario()
        {
            if (usuarioAEditar != null)
            {
                txtUsuario.Text = usuarioAEditar.NombreUsuario;
                txtEmail.Text = usuarioAEditar.Email;
                chkActivo.Checked = usuarioAEditar.Activo;

                lblPassword.Text = "Nueva Contraseña:";
                lblConfirmarPassword.Text = "Confirmar Nueva:";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("El email es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!esEdicion && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtConfirmarPassword.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (esEdicion)
                {
                    usuarioAEditar.NombreUsuario = txtUsuario.Text;
                    usuarioAEditar.Email = txtEmail.Text;
                    usuarioAEditar.Activo = chkActivo.Checked;

                    ControladoraSeguridad.Instancia.ActualizarUsuario(usuarioAEditar);

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        ControladoraSeguridad.Instancia.ResetearPassword(usuarioAEditar.Id, txtPassword.Text);
                    }
                }
                else
                {
                    var nuevoUsuario = new Usuario
                    {
                        NombreUsuario = txtUsuario.Text,
                        Email = txtEmail.Text,
                        Activo = chkActivo.Checked
                    };

                    ControladoraSeguridad.Instancia.CrearUsuario(nuevoUsuario, txtPassword.Text);
                }

                MessageBox.Show("Usuario guardado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error",
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