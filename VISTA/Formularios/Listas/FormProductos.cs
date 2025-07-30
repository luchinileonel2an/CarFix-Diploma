using Controladora;
using System.Globalization;
using Vista.Formularios.Datos;

namespace Vista.Formularios.Listas
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Gestión de Productos";
            this.Size = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblBuscar = new Label { Text = "Buscar:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(60, 20) };
            txtBuscar = new TextBox { Location = new System.Drawing.Point(90, 20), Size = new System.Drawing.Size(150, 20) };
            txtBuscar.TextChanged += (s, e) => CargarDatos();

            var lblCategoria = new Label { Text = "Categoría:", Location = new System.Drawing.Point(260, 20), Size = new System.Drawing.Size(70, 20) };
            cmbCategoria = new ComboBox
            {
                Location = new System.Drawing.Point(340, 20),
                Size = new System.Drawing.Size(120, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategoria.Items.AddRange(new[] { "Todas", "Filtros", "Lubricantes", "Frenos", "Motor", "Electricidad" });
            cmbCategoria.SelectedIndex = 0;
            cmbCategoria.SelectedIndexChanged += (s, e) => CargarDatos();

            btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(480, 18), Size = new System.Drawing.Size(80, 25) };
            btnModificar = new Button { Text = "Modificar", Location = new System.Drawing.Point(570, 18), Size = new System.Drawing.Size(80, 25) };
            btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(660, 18), Size = new System.Drawing.Size(80, 25) };
            btnCerrar = new Button { Text = "Cerrar", Location = new System.Drawing.Point(750, 18), Size = new System.Drawing.Size(80, 25) };

            dgvProductos = new DataGridView
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(850, 380),
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
                lblBuscar, txtBuscar, lblCategoria, cmbCategoria,
                btnAgregar, btnModificar, btnEliminar, btnCerrar, dgvProductos
            });
        }

        private void CargarDatos()
        {
            var productos = ControladoraProductos.Instancia.RecuperarProductos();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                var filtro = txtBuscar.Text.ToLower();
                productos = productos.Where(p =>
                    p.Nombre.ToLower().Contains(filtro) ||
                    p.Codigo.ToLower().Contains(filtro) ||
                    p.Descripcion.ToLower().Contains(filtro)).ToList().AsReadOnly();
            }

            if (cmbCategoria.SelectedItem?.ToString() != "Todas")
            {
                var categoria = cmbCategoria.SelectedItem.ToString();
                productos = productos.Where(p => p.Categoria == categoria).ToList().AsReadOnly();
            }

            var datosTabla = productos.Select(p => new
            {
                Id = p.Id,
                Código = p.Codigo,
                Nombre = p.Nombre,
                Categoría = p.Categoria,
                Precio = p.PrecioUnitario.ToString("C"),
                Stock = p.StockActual,
                Mínimo = p.StockMinimo,
                Estado = p.StockActual <= p.StockMinimo ? "BAJO STOCK" : "OK"
            }).ToList();

            dgvProductos.DataSource = datosTabla;

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Cells["Estado"].Value?.ToString() == "BAJO STOCK")
                {
                    fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!ControladoraSeguridad.Instancia.TienePermiso("PRODUCTOS_CREAR"))
            {
                MessageBox.Show("No tiene permisos para crear productos");
                return;
            }

            using (var form = new FormDatosProducto())
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
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            var productoId = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            var producto = ControladoraProductos.Instancia.RecuperarProductos()
                .FirstOrDefault(p => p.Id == productoId);

            if (producto != null)
            {
                using (var form = new FormDatosProducto())
                {
                    form.ConfigurarOperacion(Operacion.Modificar, producto);
                    if (form.MostrarDialogo() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar el producto?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var productoId = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
                    ControladoraProductos.Instancia.EliminarProducto(productoId);
                    CargarDatos();
                    MessageBox.Show("Producto eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}