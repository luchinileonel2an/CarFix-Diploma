using Entidades.Core;

namespace Vista
{
    partial class FormGestionUsuarios
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
            this.dgvUsuarios = new DataGridView();
            this.btnCrear = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnResetPassword = new Button();
            this.btnAsignarGrupos = new Button();
            this.gbUsuarios = new GroupBox();
            this.gbGrupos = new GroupBox();
            this.clbGrupos = new CheckedListBox();
            this.btnGuardarGrupos = new Button();
            this.SuspendLayout();

            // gbUsuarios
            this.gbUsuarios.Text = "Gestión de Usuarios";
            this.gbUsuarios.Location = new System.Drawing.Point(12, 12);
            this.gbUsuarios.Size = new System.Drawing.Size(600, 400);

            // dgvUsuarios
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 19);
            this.dgvUsuarios.Size = new System.Drawing.Size(588, 300);
            this.dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;

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

            this.btnResetPassword.Location = new System.Drawing.Point(249, 330);
            this.btnResetPassword.Size = new System.Drawing.Size(100, 23);
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Click += btnResetPassword_Click;

            this.btnAsignarGrupos.Location = new System.Drawing.Point(355, 330);
            this.btnAsignarGrupos.Size = new System.Drawing.Size(100, 23);
            this.btnAsignarGrupos.Text = "Asignar Grupos";
            this.btnAsignarGrupos.Click += btnAsignarGrupos_Click;

            // gbGrupos
            this.gbGrupos.Text = "Grupos del Usuario";
            this.gbGrupos.Location = new System.Drawing.Point(630, 12);
            this.gbGrupos.Size = new System.Drawing.Size(250, 400);

            // clbGrupos
            this.clbGrupos.Location = new System.Drawing.Point(6, 19);
            this.clbGrupos.Size = new System.Drawing.Size(238, 300);

            // btnGuardarGrupos
            this.btnGuardarGrupos.Location = new System.Drawing.Point(85, 330);
            this.btnGuardarGrupos.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarGrupos.Text = "Guardar";
            this.btnGuardarGrupos.Click += btnGuardarGrupos_Click;

            // Agregar controles a los grupos
            this.gbUsuarios.Controls.Add(this.dgvUsuarios);
            this.gbUsuarios.Controls.Add(this.btnCrear);
            this.gbUsuarios.Controls.Add(this.btnEditar);
            this.gbUsuarios.Controls.Add(this.btnEliminar);
            this.gbUsuarios.Controls.Add(this.btnResetPassword);
            this.gbUsuarios.Controls.Add(this.btnAsignarGrupos);

            this.gbGrupos.Controls.Add(this.clbGrupos);
            this.gbGrupos.Controls.Add(this.btnGuardarGrupos);

            // FormGestionUsuarios
            this.ClientSize = new System.Drawing.Size(900, 430);
            this.Controls.Add(this.gbUsuarios);
            this.Controls.Add(this.gbGrupos);
            this.Text = "Gestión de Usuarios";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnCrear, btnEditar, btnEliminar, btnResetPassword, btnAsignarGrupos;
        private GroupBox gbUsuarios, gbGrupos;
        private CheckedListBox clbGrupos;
        private Button btnGuardarGrupos;
        private Usuario usuarioSeleccionado;
    }
}