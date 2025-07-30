using Controladora;
using Entidades.Patrones;
using System.Globalization;
using Vista.Formularios.Datos;

namespace Vista.Formularios.Listas
{
    public partial class FormOrdenesCompra : Form, IObserver
    {
        public FormOrdenesCompra()
        {
            CrearFormulario();
            CargarDatos();
            NotificadorOrdenesCompra.Instancia.AddObserver(this);
        }

        private void CrearFormulario()
        {
            this.Text = "Órdenes de Compra";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblFiltro = new Label { Text = "Estado:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(50, 20) };
            cmbEstadoFiltro = new ComboBox
            {
                Location = new System.Drawing.Point(80, 20),
                Size = new System.Drawing.Size(120, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbEstadoFiltro.Items.AddRange(new[] { "Todos", "Pendiente", "Enviada", "Recibida", "Cancelada" });
            cmbEstadoFiltro.SelectedIndex = 0;
            cmbEstadoFiltro.SelectedIndexChanged += (s, e) => CargarDatos();

            btnNuevaOrden = new Button { Text = "Nueva Orden", Location = new System.Drawing.Point(220, 18), Size = new System.Drawing.Size(100, 25) };
            btnCambiarEstado = new Button { Text = "Cambiar Estado", Location = new System.Drawing.Point(330, 18), Size = new System.Drawing.Size(100, 25) };

            dgvOrdenes = new DataGridView
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(750, 500),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnNuevaOrden.Click += BtnNuevaOrden_Click;
            btnCambiarEstado.Click += BtnCambiarEstado_Click;

            this.Controls.AddRange(new Control[] { lblFiltro, cmbEstadoFiltro, btnNuevaOrden, btnCambiarEstado, dgvOrdenes });
        }

        private void CargarDatos()
        {
            var ordenes = ControladoraOrdenesCompra.Instancia.RecuperarOrdenesCompra();

            var filtroEstado = cmbEstadoFiltro.SelectedItem?.ToString();
            if (filtroEstado != "Todos")
            {
                ordenes = ordenes.Where(o => o.Estado.ToString() == filtroEstado).ToList().AsReadOnly();
            }

            var datosTabla = ordenes.Select(o => new
            {
                Id = o.Id,
                Numero = o.Numero,
                Proveedor = o.Proveedor?.Nombre,
                FechaCreacion = o.FechaCreacion.ToString("dd/MM/yyyy"),
                Estado = o.Estado.ToString(),
                Total = o.Total.ToString("C"),
                CantidadItems = o.Detalles?.Count ?? 0
            }).ToList();

            dgvOrdenes.DataSource = datosTabla;
        }

        private void BtnNuevaOrden_Click(object sender, EventArgs e)
        {
            using (var form = new FormCrearOrdenCompra())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una orden");
                return;
            }

            var ordenId = (int)dgvOrdenes.SelectedRows[0].Cells["Id"].Value;

            using (var form = new FormCambiarEstadoOrden(ordenId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        public void Update(string mensaje, object datos)
        {
            if (mensaje == "ORDEN_CREADA" || mensaje == "ESTADO_CAMBIADO")
            {
                CargarDatos();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NotificadorOrdenesCompra.Instancia.RemoveObserver(this);
            base.OnFormClosed(e);
        }
    }
}