using Controladora;
using Entidades.Compras;
using Vista.Patrones;

namespace Vista.Formularios.Datos
{
    public partial class FormDatosProducto : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Producto productoActual { get; set; }

        public FormDatosProducto()
        {
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            this.Text = "Datos del Producto";
            this.Size = new System.Drawing.Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblCodigo = new Label { Text = "Código:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 20) };
            txtCodigo = new TextBox { Location = new System.Drawing.Point(110, 20), Size = new System.Drawing.Size(300, 20) };

            var lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 20) };
            txtNombre = new TextBox { Location = new System.Drawing.Point(110, 50), Size = new System.Drawing.Size(300, 20) };

            var lblDescripcion = new Label { Text = "Descripción:", Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(80, 20) };
            txtDescripcion = new TextBox { Location = new System.Drawing.Point(110, 80), Size = new System.Drawing.Size(300, 60), Multiline = true };

            var lblCategoria = new Label { Text = "Categoría:", Location = new System.Drawing.Point(20, 150), Size = new System.Drawing.Size(80, 20) };
            cmbCategoria = new ComboBox
            {
                Location = new System.Drawing.Point(110, 150),
                Size = new System.Drawing.Size(300, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategoria.Items.AddRange(new[] { "Filtros", "Lubricantes", "Frenos", "Motor", "Electricidad", "Otros" });

            var lblPrecio = new Label { Text = "Precio:", Location = new System.Drawing.Point(20, 180), Size = new System.Drawing.Size(80, 20) };
            numPrecio = new NumericUpDown
            {
                Location = new System.Drawing.Point(110, 180),
                Size = new System.Drawing.Size(130, 20),
                DecimalPlaces = 2,
                Maximum = 999999,
                Minimum = 0
            };

            var lblStockMinimo = new Label { Text = "Stock Mín.:", Location = new System.Drawing.Point(20, 210), Size = new System.Drawing.Size(80, 20) };
            numStockMinimo = new NumericUpDown
            {
                Location = new System.Drawing.Point(110, 210),
                Size = new System.Drawing.Size(130, 20),
                Maximum = 9999,
                Minimum = 0
            };

            var lblStockActual = new Label { Text = "Stock Actual:", Location = new System.Drawing.Point(20, 240), Size = new System.Drawing.Size(80, 20) };
            numStockActual = new NumericUpDown
            {
                Location = new System.Drawing.Point(110, 240),
                Size = new System.Drawing.Size(130, 20),
                Maximum = 9999,
                Minimum = 0
            };

            btnAceptar = new Button { Text = "Aceptar", Location = new System.Drawing.Point(250, 280), Size = new System.Drawing.Size(75, 30) };
            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(335, 280), Size = new System.Drawing.Size(75, 30) };

            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblCodigo, txtCodigo, lblNombre, txtNombre, lblDescripcion, txtDescripcion,
                lblCategoria, cmbCategoria, lblPrecio, numPrecio, lblStockMinimo, numStockMinimo,
                lblStockActual, numStockActual, btnAceptar, btnCancelar
            });
        }

        public DialogResult MostrarDialogo()
        {
            return this.ShowDialog();
        }

        public void ConfigurarOperacion(Operacion operacion, object entidad = null)
        {
            ModoOperacion = operacion;
            if (entidad is Producto producto)
            {
                productoActual = producto;
                RellenarCampos();
            }

            this.Text = $"{operacion} Producto";
        }

        private void RellenarCampos()
        {
            if (productoActual != null)
            {
                txtCodigo.Text = productoActual.Codigo;
                txtNombre.Text = productoActual.Nombre;
                txtDescripcion.Text = productoActual.Descripcion;
                cmbCategoria.SelectedItem = productoActual.Categoria;
                numPrecio.Value = productoActual.PrecioUnitario;
                numStockMinimo.Value = productoActual.StockMinimo;
                numStockActual.Value = productoActual.StockActual;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    switch (ModoOperacion)
                    {
                        case Operacion.Agregar:
                            ControladoraProductos.Instancia.AgregarProducto(
                                txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                                cmbCategoria.SelectedItem.ToString(), numPrecio.Value,
                                (int)numStockMinimo.Value, (int)numStockActual.Value);
                            break;
                        case Operacion.Modificar:
                            ControladoraProductos.Instancia.ModificarProducto(
                                productoActual.Id, txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                                cmbCategoria.SelectedItem.ToString(), numPrecio.Value,
                                (int)numStockMinimo.Value, (int)numStockActual.Value);
                            break;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código del producto");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto");
                return false;
            }
            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría");
                return false;
            }
            return true;
        }
    }
}