namespace Vista.Formularios.Datos
{
    partial class FormCrearOrdenCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormCrearOrdenCompra";
        }

        #endregion

        private ComboBox cmbProveedor;
        private DataGridView dgvProductos;
        private DataGridView dgvDetalles;
        private Button btnAgregarProducto;
        private Button btnQuitarProducto;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtObservaciones;
        private Label lblTotal;
    }
}