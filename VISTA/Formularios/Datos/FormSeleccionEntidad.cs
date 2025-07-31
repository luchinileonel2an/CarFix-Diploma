using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Formularios.Datos
{
    public partial class FormSeleccionEntidad : Form
    {
        public object EntidadSeleccionada { get; private set; }
        private List<object> listaEntidades;
        private string propiedadDisplay;
        private string propiedadBusqueda;

        public FormSeleccionEntidad()
        {
            InitializeComponent();
        }

        public void ConfigurarSeleccion<T>(List<T> entidades, string displayMember, string searchProperty, string titulo)
        {
            this.Text = titulo;
            listaEntidades = entidades.Cast<object>().ToList();
            propiedadDisplay = displayMember;
            propiedadBusqueda = searchProperty;

            ConfigurarDataGridView();
            CargarDatos();
        }

        private void ConfigurarDataGridView()
        {
            dgvEntidades.AutoGenerateColumns = false;
            dgvEntidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntidades.MultiSelect = false;
            dgvEntidades.ReadOnly = true;
            dgvEntidades.AllowUserToAddRows = false;
            dgvEntidades.AllowUserToDeleteRows = false;

            // Configurar columnas dinámicamente según el tipo de entidad
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvEntidades.Columns.Clear();

            if (listaEntidades.Any())
            {
                var tipoEntidad = listaEntidades.First().GetType();

                // Configurar columnas específicas según el tipo
                if (tipoEntidad.Name == "Cliente")
                {
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NombreCompleto",
                        HeaderText = "Nombre Completo",
                        Width = 200
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Dni",
                        HeaderText = "DNI",
                        Width = 100
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Correo",
                        HeaderText = "Correo",
                        Width = 200
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Telefono",
                        HeaderText = "Teléfono",
                        Width = 120
                    });
                }
                else if (tipoEntidad.Name == "Vehiculo")
                {
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Dominio",
                        HeaderText = "Dominio",
                        Width = 100
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NombreCompleto",
                        HeaderText = "Marca/Modelo",
                        Width = 200
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Año",
                        HeaderText = "Año",
                        Width = 80
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NombreCompletoDueño",
                        HeaderText = "Propietario",
                        Width = 200
                    });
                }
                else if (tipoEntidad.Name == "Tecnico")
                {
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NombreCompleto",
                        HeaderText = "Nombre Completo",
                        Width = 200
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Especialidad",
                        HeaderText = "Especialidad",
                        Width = 150
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Dni",
                        HeaderText = "DNI",
                        Width = 100
                    });
                    dgvEntidades.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Correo",
                        HeaderText = "Correo",
                        Width = 200
                    });
                }
            }
        }

        private void CargarDatos()
        {
            dgvEntidades.DataSource = listaEntidades;
            lblTotal.Text = $"Total: {listaEntidades.Count} registros";
        }

        private void FiltrarDatos()
        {
            string filtro = txtBuscar.Text.ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvEntidades.DataSource = listaEntidades;
            }
            else
            {
                var listaFiltrada = listaEntidades.Where(entidad =>
                {
                    var propiedades = entidad.GetType().GetProperties();

                    // Buscar en múltiples propiedades
                    foreach (var propiedad in propiedades)
                    {
                        var valor = propiedad.GetValue(entidad)?.ToString()?.ToLower();
                        if (!string.IsNullOrEmpty(valor) && valor.Contains(filtro))
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();

                dgvEntidades.DataSource = listaFiltrada;
            }

            lblTotal.Text = $"Total: {((List<object>)dgvEntidades.DataSource).Count} registros";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEntidades.SelectedRows.Count > 0)
            {
                EntidadSeleccionada = dgvEntidades.SelectedRows[0].DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento de la lista.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvEntidades_DoubleClick(object sender, EventArgs e)
        {
            btnSeleccionar_Click(sender, e);
        }

        private void FormSeleccionEntidad_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvEntidades.Rows.Count > 0)
                {
                    dgvEntidades.Rows[0].Selected = true;
                    dgvEntidades.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down && dgvEntidades.Rows.Count > 0)
            {
                dgvEntidades.Focus();
                dgvEntidades.Rows[0].Selected = true;
            }
        }

        private void dgvEntidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
