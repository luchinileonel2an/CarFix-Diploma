using Controladora;
using Entidades.Core;
using System.Data;

namespace Vista
{
    public partial class FormGestionGrupos : Form
    {
        public FormGestionGrupos()
        {
            InitializeComponent();
            CargarGrupos();
            CargarPermisos();
        }

        private void CargarGrupos()
        {
            try
            {
                var grupos = ControladoraSeguridad.Instancia.ObtenerGrupos();
                var bindingSource = new BindingSource();
                bindingSource.DataSource = grupos.Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Descripcion = g.Descripcion,
                    CantidadUsuarios = g.Usuarios.Count,
                    CantidadPermisos = g.Permisos.Count
                }).ToList();

                dgvGrupos.DataSource = bindingSource;
                dgvGrupos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPermisos()
        {
            try
            {
                var permisos = ControladoraSeguridad.Instancia.ObtenerPermisos();
                clbPermisos.Items.Clear();
                foreach (var permiso in permisos.OrderBy(p => p.Modulo).ThenBy(p => p.Nombre))
                {
                    clbPermisos.Items.Add(permiso, false);
                }
                clbPermisos.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentRow != null)
            {
                int grupoId = (int)dgvGrupos.CurrentRow.Cells["Id"].Value;
                grupoSeleccionado = ControladoraSeguridad.Instancia.ObtenerGrupos()
                    .FirstOrDefault(g => g.Id == grupoId);

                ActualizarPermisosSeleccionados();
            }
        }

        private void ActualizarPermisosSeleccionados()
        {
            if (grupoSeleccionado == null) return;

            for (int i = 0; i < clbPermisos.Items.Count; i++)
            {
                var permiso = (Permiso)clbPermisos.Items[i];
                clbPermisos.SetItemChecked(i, grupoSeleccionado.Permisos.Any(p => p.Id == permiso.Id));
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var formCrearGrupo = new FormCrearEditarGrupo();
            if (formCrearGrupo.ShowDialog() == DialogResult.OK)
            {
                CargarGrupos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un grupo para editar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formEditarGrupo = new FormCrearEditarGrupo(grupoSeleccionado);
            if (formEditarGrupo.ShowDialog() == DialogResult.OK)
            {
                CargarGrupos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un grupo para eliminar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar el grupo {grupoSeleccionado.Nombre}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ControladoraSeguridad.Instancia.EliminarGrupo(grupoSeleccionado.Id);
                    CargarGrupos();
                    MessageBox.Show("Grupo eliminado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar grupo: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAsignarPermisos_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un grupo", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gbPermisos.Enabled = true;
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null) return;

            try
            {
                foreach (var permiso in grupoSeleccionado.Permisos.ToList())
                {
                    ControladoraSeguridad.Instancia.RemoverPermisoDeGrupo(grupoSeleccionado.Id, permiso.Id);
                }

                for (int i = 0; i < clbPermisos.Items.Count; i++)
                {
                    if (clbPermisos.GetItemChecked(i))
                    {
                        var permiso = (Permiso)clbPermisos.Items[i];
                        ControladoraSeguridad.Instancia.AsignarPermisoAGrupo(grupoSeleccionado.Id, permiso.Id);
                    }
                }

                CargarGrupos();
                MessageBox.Show("Permisos actualizados correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar permisos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}