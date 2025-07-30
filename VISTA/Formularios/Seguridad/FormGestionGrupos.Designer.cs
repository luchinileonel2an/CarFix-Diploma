using Entidades.Core;

namespace Vista
{
    partial class FormGestionGrupos
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
            this.dgvGrupos = new DataGridView();
            this.btnCrear = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnAsignarPermisos = new Button();
            this.gbGrupos = new GroupBox();
            this.gbPermisos = new GroupBox();
            this.clbPermisos = new CheckedListBox();
            this.btnGuardarPermisos = new Button();
            this.SuspendLayout();

            // gbGrupos
            this.gbGrupos.Text = "Gestión de Grupos";
            this.gbGrupos.Location = new System.Drawing.Point(12, 12);
            this.gbGrupos.Size = new System.Drawing.Size(500, 400);

            // dgvGrupos
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.Location = new System.Drawing.Point(6, 19);
            this.dgvGrupos.Size = new System.Drawing.Size(488, 300);
            this.dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.SelectionChanged += dgvGrupos_SelectionChanged;

            // Botones
            this.btnCrear.Location = new System.Drawing.Point(6, 330);
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += btnCrear_Click;

            this.btnEditar.Location = new System.Drawing.Point(87, 330);
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += btnEditar_Click;

            this.btnEliminar.Location = new System.Drawing.Point(168, 330);
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += btnEliminar_Click;

            this.btnAsignarPermisos.Location = new System.Drawing.Point(249, 330);
            this.btnAsignarPermisos.Size = new System.Drawing.Size(120, 23);
            this.btnAsignarPermisos.Text = "Asignar Permisos";
            this.btnAsignarPermisos.Click += btnAsignarPermisos_Click;

            // gbPermisos
            this.gbPermisos.Text = "Permisos del Grupo";
            this.gbPermisos.Location = new System.Drawing.Point(530, 12);
            this.gbPermisos.Size = new System.Drawing.Size(300, 400);

            // clbPermisos
            this.clbPermisos.Location = new System.Drawing.Point(6, 19);
            this.clbPermisos.Size = new System.Drawing.Size(288, 300);

            // btnGuardarPermisos
            this.btnGuardarPermisos.Location = new System.Drawing.Point(115, 330);
            this.btnGuardarPermisos.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPermisos.Text = "Guardar";
            this.btnGuardarPermisos.Click += btnGuardarPermisos_Click;

            // Agregar controles a los grupos
            this.gbGrupos.Controls.Add(this.dgvGrupos);
            this.gbGrupos.Controls.Add(this.btnCrear);
            this.gbGrupos.Controls.Add(this.btnEditar);
            this.gbGrupos.Controls.Add(this.btnEliminar);
            this.gbGrupos.Controls.Add(this.btnAsignarPermisos);

            this.gbPermisos.Controls.Add(this.clbPermisos);
            this.gbPermisos.Controls.Add(this.btnGuardarPermisos);

            // FormGestionGrupos
            this.ClientSize = new System.Drawing.Size(850, 430);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.gbPermisos);
            this.Text = "Gestión de Grupos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGrupos;
        private Button btnCrear, btnEditar, btnEliminar, btnAsignarPermisos;
        private GroupBox gbGrupos, gbPermisos;
        private CheckedListBox clbPermisos;
        private Button btnGuardarPermisos;
        private Grupo grupoSeleccionado;
    }
}