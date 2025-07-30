using Controladora;

namespace Vista
{
    public partial class FormCambiarPassword : Form
    {
        public FormCambiarPassword()
        {
            InitializeComponent();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPasswordActual.Text) ||
                    string.IsNullOrWhiteSpace(txtPasswordNuevo.Text) ||
                    string.IsNullOrWhiteSpace(txtConfirmarPassword.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPasswordNuevo.Text != txtConfirmarPassword.Text)
                {
                    MessageBox.Show("La nueva contraseña y su confirmación no coinciden", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuarioActual = ControladoraSeguridad.Instancia.UsuarioActual;
                if (ControladoraSeguridad.Instancia.CambiarPassword(usuarioActual.Id,
                    txtPasswordActual.Text, txtPasswordNuevo.Text))
                {
                    MessageBox.Show("Contraseña cambiada correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña actual es incorrecta", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar contraseña: {ex.Message}", "Error",
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
