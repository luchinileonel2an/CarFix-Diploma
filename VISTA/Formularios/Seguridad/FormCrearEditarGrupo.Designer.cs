using Entidades.Core;

namespace Vista
{
    partial class FormCrearEditarGrupo
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

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.txtDescripcion = new TextBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.lblNombre = new Label();
            this.lblDescripcion = new Label();
            this.SuspendLayout();

            // Labels y TextBoxes
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(12, 15);
            this.lblNombre.Size = new System.Drawing.Size(100, 23);

            this.txtNombre.Location = new System.Drawing.Point(120, 12);
            this.txtNombre.Size = new System.Drawing.Size(250, 20);

            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Location = new System.Drawing.Point(12, 45);
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);

            this.txtDescripcion.Location = new System.Drawing.Point(120, 42);
            this.txtDescripcion.Size = new System.Drawing.Size(250, 60);
            this.txtDescripcion.Multiline = true;

            // Botones
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(210, 120);
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.Click += btnGuardar_Click;

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(295, 120);
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Click += btnCancelar_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(390, 170);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre, txtDescripcion;
        private Button btnGuardar, btnCancelar;
        private Label lblNombre, lblDescripcion;
        private Grupo grupoAEditar;
        private bool esEdicion;
    }
}