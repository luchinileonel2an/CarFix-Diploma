using Controladora;
using Vista.Formularios.Datos;

namespace Vista.Formularios.Listas
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Gestión de Proveedores";
            this.Size = new System.Drawing.Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblBuscar = new Label { Text = "Buscar:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(60, 20) };
            txtBuscar = new TextBox { Location = new System.Drawing.Point(90, 20), Size = new System.Drawing.Size(200, 20) };
            txtBuscar.TextChanged += (s, e) => CargarDatos();

            btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(320, 18), Size = new System.Drawing.Size(80, 25) };
            btnModificar = new Button { Text = "Modificar", Location = new System.Drawing.Point(410, 18), Size = new System.Drawing.Size(80, 25) };
            btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(500, 18), Size = new System.Drawing.Size(80, 25) };
            btnCerrar = new Button { Text = "Cerrar", Location = new System.Drawing.Point(690, 18), Size = new System.Drawing.Size(80, 25) };

            dgvProveedores = new DataGridView
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(750, 380),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnCerrar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblBuscar, txtBuscar, btnAgregar, btnModificar, btnEliminar, btnCerrar, dgvProveedores
            });
        }

        private void CargarDatos()
        {
            var proveedores = ControladoraProveedores.Instancia.RecuperarProveedores();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                var filtro = txtBuscar.Text.ToLower();
                proveedores = proveedores.Where(p =>
                    p.Nombre.ToLower().Contains(filtro) ||
                    p.Cuit.Contains(filtro)).ToList().AsReadOnly();
            }

            var datosTabla = proveedores.Select(p => new
            {
                Id = p.Id,
                Nombre = p.Nombre,
                CUIT = p.Cuit,
                Teléfono = p.Telefono,
                Email = p.Email,
                Dirección = p.Direccion
            }).ToList();

            dgvProveedores.DataSource = datosTabla;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("PROVEEDORES_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear proveedores");
                return;
            }

            using (var form = new FormDatosProveedor())
            {
                form.ConfigurarOperacion(Operacion.Agregar);
                if (form.MostrarDialogo() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            var proveedorId = (int)dgvProveedores.SelectedRows[0].Cells["Id"].Value;
            var proveedor = ControladoraProveedores.Instancia.RecuperarProveedores()
                .FirstOrDefault(p => p.Id == proveedorId);

            if (proveedor != null)
            {
                using (var form = new FormDatosProveedor())
                {
                    form.ConfigurarOperacion(Operacion.Modificar, proveedor);
                    if (form.MostrarDialogo() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar el proveedor?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var proveedorId = (int)dgvProveedores.SelectedRows[0].Cells["Id"].Value;
                    ControladoraProveedores.Instancia.EliminarProveedor(proveedorId);
                    CargarDatos();
                    MessageBox.Show("Proveedor eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
