using Controladora;
using Entidades.Compras;
using Vista.Patrones;

namespace Vista.Formularios.Datos
{
    public partial class FormDatosProveedor : Form, IFormularioDatos
    {
        public Operacion ModoOperacion { get; set; }
        public Proveedor proveedorActual { get; set; }

        public FormDatosProveedor()
        {
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            this.Text = "Datos del Proveedor";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 20) };
            txtNombre = new TextBox { Location = new System.Drawing.Point(110, 20), Size = new System.Drawing.Size(250, 20) };

            var lblTelefono = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 20) };
            txtTelefono = new TextBox { Location = new System.Drawing.Point(110, 50), Size = new System.Drawing.Size(250, 20) };

            var lblEmail = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(80, 20) };
            txtEmail = new TextBox { Location = new System.Drawing.Point(110, 80), Size = new System.Drawing.Size(250, 20) };

            var lblDireccion = new Label { Text = "Dirección:", Location = new System.Drawing.Point(20, 110), Size = new System.Drawing.Size(80, 20) };
            txtDireccion = new TextBox { Location = new System.Drawing.Point(110, 110), Size = new System.Drawing.Size(250, 60), Multiline = true };

            var lblCuit = new Label { Text = "CUIT:", Location = new System.Drawing.Point(20, 180), Size = new System.Drawing.Size(80, 20) };
            txtCuit = new TextBox { Location = new System.Drawing.Point(110, 180), Size = new System.Drawing.Size(250, 20) };

            btnAceptar = new Button { Text = "Aceptar", Location = new System.Drawing.Point(200, 220), Size = new System.Drawing.Size(75, 30) };
            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(285, 220), Size = new System.Drawing.Size(75, 30) };

            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblTelefono, txtTelefono, lblEmail, txtEmail, lblDireccion, txtDireccion, lblCuit, txtCuit, btnAceptar, btnCancelar });
        }

        public DialogResult MostrarDialogo()
        {
            return this.ShowDialog();
        }

        public void ConfigurarOperacion(Operacion operacion, object entidad = null)
        {
            ModoOperacion = operacion;
            if (entidad is Proveedor proveedor)
            {
                proveedorActual = proveedor;
                RellenarCampos();
            }

            this.Text = $"{operacion} Proveedor";
        }

        private void RellenarCampos()
        {
            if (proveedorActual != null)
            {
                txtNombre.Text = proveedorActual.Nombre;
                txtTelefono.Text = proveedorActual.Telefono;
                txtEmail.Text = proveedorActual.Email;
                txtDireccion.Text = proveedorActual.Direccion;
                txtCuit.Text = proveedorActual.Cuit;
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
                            ControladoraProveedores.Instancia.AgregarProveedor(
                                txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtCuit.Text);
                            break;
                        case Operacion.Modificar:
                            ControladoraProveedores.Instancia.ModificarProveedor(
                                proveedorActual.Id, txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtCuit.Text);
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del proveedor");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show("Ingrese el CUIT del proveedor");
                return false;
            }
            return true;
        }
    }
}
