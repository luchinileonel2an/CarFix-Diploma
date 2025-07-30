using Controladora;
using Entidades.Core;
using System.Data;

namespace Vista
{
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarGrupos();
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = ControladoraSeguridad.Instancia.ObtenerUsuarios();
                var bindingSource = new BindingSource();
                bindingSource.DataSource = usuarios.Select(u => new
                {
                    Id = u.Id,
                    Usuario = u.NombreUsuario,
                    Email = u.Email,
                    FechaCreacion = u.FechaCreacion.ToString("dd/MM/yyyy"),
                    UltimoAcceso = u.UltimoAcceso?.ToString("dd/MM/yyyy HH:mm") ?? "Nunca",
                    Activo = u.Activo ? "Sí" : "No",
                    Grupos = string.Join(", ", u.Grupos.Select(g => g.Nombre))
                }).ToList();

                dgvUsuarios.DataSource = bindingSource;
                dgvUsuarios.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrupos()
        {
            try
            {
                var grupos = ControladoraSeguridad.Instancia.ObtenerGrupos();
                clbGrupos.Items.Clear();
                foreach (var grupo in grupos)
                {
                    clbGrupos.Items.Add(grupo, false);
                }
                clbGrupos.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                int usuarioId = (int)dgvUsuarios.CurrentRow.Cells["Id"].Value;
                usuarioSeleccionado = ControladoraSeguridad.Instancia.ObtenerUsuarios()
                    .FirstOrDefault(u => u.Id == usuarioId);

                ActualizarGruposSeleccionados();
            }
        }

        private void ActualizarGruposSeleccionados()
        {
            if (usuarioSeleccionado == null) return;

            for (int i = 0; i < clbGrupos.Items.Count; i++)
            {
                var grupo = (Grupo)clbGrupos.Items[i];
                clbGrupos.SetItemChecked(i, usuarioSeleccionado.Grupos.Any(g => g.Id == grupo.Id));
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var formCrearUsuario = new FormCrearEditarUsuario();
            if (formCrearUsuario.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formEditarUsuario = new FormCrearEditarUsuario(usuarioSeleccionado);
            if (formEditarUsuario.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar el usuario {usuarioSeleccionado.NombreUsuario}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ControladoraSeguridad.Instancia.EliminarUsuario(usuarioSeleccionado.Id);
                    CargarUsuarios();
                    MessageBox.Show("Usuario eliminado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nuevaPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese la nueva contraseña:", "Resetear Contraseña", "");

            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                try
                {
                    ControladoraSeguridad.Instancia.ResetearPassword(usuarioSeleccionado.Id, nuevaPassword);
                    MessageBox.Show("Contraseña reseteada correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al resetear contraseña: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAsignarGrupos_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gbGrupos.Enabled = true;
        }

        private void btnGuardarGrupos_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null) return;

            try
            {
                foreach (var grupo in usuarioSeleccionado.Grupos.ToList())
                {
                    ControladoraSeguridad.Instancia.RemoverUsuarioDeGrupo(usuarioSeleccionado.Id, grupo.Id);
                }

                for (int i = 0; i < clbGrupos.Items.Count; i++)
                {
                    if (clbGrupos.GetItemChecked(i))
                    {
                        var grupo = (Grupo)clbGrupos.Items[i];
                        ControladoraSeguridad.Instancia.AsignarUsuarioAGrupo(usuarioSeleccionado.Id, grupo.Id);
                    }
                }

                CargarUsuarios();
                MessageBox.Show("Grupos actualizados correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar grupos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}