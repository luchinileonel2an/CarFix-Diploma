using Controladora;
using Entidades.Compras;

namespace Vista.Formularios.Datos
{
    public partial class FormCambiarEstadoOrden : Form
    {
        public FormCambiarEstadoOrden(int ordenId)
        {
            this.ordenId = ordenId;
            CrearFormulario();
            CargarDatos();
        }

        private void CrearFormulario()
        {
            this.Text = "Cambiar Estado de Orden";
            this.Size = new System.Drawing.Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;

            lblEstadoActual = new Label
            {
                Text = "Estado actual: ",
                Location = new System.Drawing.Point(20, 30),
                Size = new System.Drawing.Size(300, 20)
            };

            var lblNuevoEstado = new Label
            {
                Text = "Nuevo estado:",
                Location = new System.Drawing.Point(20, 70),
                Size = new System.Drawing.Size(100, 20)
            };

            cmbNuevoEstado = new ComboBox
            {
                Location = new System.Drawing.Point(130, 70),
                Size = new System.Drawing.Size(180, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbNuevoEstado.Items.AddRange(new[] { "Pendiente", "Enviada", "Recibida", "Cancelada" });

            btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new System.Drawing.Point(150, 120),
                Size = new System.Drawing.Size(75, 30)
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(235, 120),
                Size = new System.Drawing.Size(75, 30)
            };

            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblEstadoActual, lblNuevoEstado, cmbNuevoEstado, btnAceptar, btnCancelar
            });
        }

        private void CargarDatos()
        {
            try
            {
                var ordenes = ControladoraOrdenesCompra.Instancia.RecuperarOrdenesCompra();
                var orden = ordenes.FirstOrDefault(o => o.Id == ordenId);

                if (orden != null)
                {
                    lblEstadoActual.Text = $"Estado actual: {orden.Estado}";
                    cmbNuevoEstado.SelectedItem = orden.Estado.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estado");
                return;
            }

            try
            {
                var estadoTexto = cmbNuevoEstado.SelectedItem.ToString();
                var nuevoEstado = (OrdenCompra.EstadoOrden)Enum.Parse(typeof(OrdenCompra.EstadoOrden), estadoTexto);

                ControladoraOrdenesCompra.Instancia.CambiarEstadoOrden(ordenId, nuevoEstado);

                MessageBox.Show("Estado actualizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}