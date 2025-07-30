using Controladora;
using Entidades.Compras;

namespace Vista.Formularios.Datos
{
    public partial class FormCrearOrdenCompra : Form
    {
        private List<DetalleOrdenCompra> detalles = new List<DetalleOrdenCompra>();

        public FormCrearOrdenCompra()
        {
            CrearFormulario();
            CargarProveedores();
            CargarProductos();
        }

        private void CrearFormulario()
        {
            this.Text = "Nueva Orden de Compra";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblProveedor = new Label { Text = "Proveedor:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 20) };
            cmbProveedor = new ComboBox
            {
                Location = new System.Drawing.Point(110, 20),
                Size = new System.Drawing.Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var lblProductos = new Label { Text = "Productos Disponibles:", Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(150, 20) };
            dgvProductos = new DataGridView
            {
                Location = new System.Drawing.Point(20, 85),
                Size = new System.Drawing.Size(400, 200),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnAgregarProducto = new Button { Text = "Agregar", Location = new System.Drawing.Point(440, 150), Size = new System.Drawing.Size(80, 30) };
            btnQuitarProducto = new Button { Text = "Quitar", Location = new System.Drawing.Point(440, 190), Size = new System.Drawing.Size(80, 30) };

            var lblDetalles = new Label { Text = "Productos en la Orden:", Location = new System.Drawing.Point(20, 300), Size = new System.Drawing.Size(150, 20) };
            dgvDetalles = new DataGridView
            {
                Location = new System.Drawing.Point(20, 325),
                Size = new System.Drawing.Size(500, 150),
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            lblTotal = new Label
            {
                Text = "Total: $0,00",
                Location = new System.Drawing.Point(400, 480),
                Size = new System.Drawing.Size(200, 20),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };

            var lblObservaciones = new Label { Text = "Observaciones:", Location = new System.Drawing.Point(540, 325), Size = new System.Drawing.Size(100, 20) };
            txtObservaciones = new TextBox
            {
                Location = new System.Drawing.Point(540, 350),
                Size = new System.Drawing.Size(320, 100),
                Multiline = true
            };

            btnGuardar = new Button { Text = "Guardar", Location = new System.Drawing.Point(700, 480), Size = new System.Drawing.Size(80, 30) };
            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(790, 480), Size = new System.Drawing.Size(80, 30) };

            btnAgregarProducto.Click += BtnAgregarProducto_Click;
            btnQuitarProducto.Click += BtnQuitarProducto_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblProveedor, cmbProveedor, lblProductos, dgvProductos,
                btnAgregarProducto, btnQuitarProducto, lblDetalles, dgvDetalles,
                lblTotal, lblObservaciones, txtObservaciones, btnGuardar, btnCancelar
            });
        }

        private void CargarProveedores()
        {
            var proveedores = ControladoraProveedores.Instancia.RecuperarProveedores();
            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "Id";
        }

        private void CargarProductos()
        {
            var productos = ControladoraProductos.Instancia.RecuperarProductos();
            var datosProductos = productos.Select(p => new
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Precio = p.PrecioUnitario,
                Stock = p.StockActual
            }).ToList();

            dgvProductos.DataSource = datosProductos;
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            var productoId = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            var precio = (decimal)dgvProductos.SelectedRows[0].Cells["Precio"].Value;

            using (var form = new FormCantidadProducto())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var detalle = new DetalleOrdenCompra
                    {
                        ProductoId = productoId,
                        Cantidad = form.Cantidad,
                        PrecioUnitario = precio,
                        Subtotal = form.Cantidad * precio
                    };

                    detalles.Add(detalle);
                    ActualizarTablaDetalles();
                }
            }
        }

        private void BtnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto de la orden");
                return;
            }

            var index = dgvDetalles.SelectedRows[0].Index;
            detalles.RemoveAt(index);
            ActualizarTablaDetalles();
        }

        private void ActualizarTablaDetalles()
        {
            var productos = ControladoraProductos.Instancia.RecuperarProductos();
            var datosDetalles = detalles.Select(d => new
            {
                Producto = productos.FirstOrDefault(p => p.Id == d.ProductoId)?.Nombre,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Subtotal
            }).ToList();

            dgvDetalles.DataSource = datosDetalles;
            lblTotal.Text = $"Total: {detalles.Sum(d => d.Subtotal).ToString("C")}";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            if (!detalles.Any())
            {
                MessageBox.Show("Agregue al menos un producto a la orden");
                return;
            }

            try
            {
                var proveedorId = (int)cmbProveedor.SelectedValue;
                ControladoraOrdenesCompra.Instancia.CrearOrdenCompra(proveedorId, detalles, txtObservaciones.Text);

                MessageBox.Show("Orden de compra creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
