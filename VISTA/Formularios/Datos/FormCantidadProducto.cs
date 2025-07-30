namespace Vista.Formularios.Datos
{
    public partial class FormCantidadProducto : Form
    {
        public int Cantidad { get; private set; }

        public FormCantidadProducto()
        {
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            this.Text = "Cantidad";
            this.Size = new System.Drawing.Size(250, 150);
            this.StartPosition = FormStartPosition.CenterParent;

            var lblCantidad = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(20, 30), Size = new System.Drawing.Size(60, 20) };
            numCantidad = new NumericUpDown
            {
                Location = new System.Drawing.Point(90, 30),
                Size = new System.Drawing.Size(120, 20),
                Minimum = 1,
                Maximum = 1000,
                Value = 1
            };

            btnAceptar = new Button { Text = "Aceptar", Location = new System.Drawing.Point(50, 70), Size = new System.Drawing.Size(75, 30) };
            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(135, 70), Size = new System.Drawing.Size(75, 30) };

            btnAceptar.Click += (s, e) =>
            {
                Cantidad = (int)numCantidad.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lblCantidad, numCantidad, btnAceptar, btnCancelar });
        }
    }
}