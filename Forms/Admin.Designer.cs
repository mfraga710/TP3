namespace TP3.Forms
{
    partial class Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.listaUsuarios = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listadoPost = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verPost = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listadoTags = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EliminarTags = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.eliminarPost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTags)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios";
            // 
            // listaUsuarios
            // 
            this.listaUsuarios.AllowUserToAddRows = false;
            this.listaUsuarios.AllowUserToDeleteRows = false;
            this.listaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.listaUsuarios.Location = new System.Drawing.Point(17, 45);
            this.listaUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listaUsuarios.Name = "listaUsuarios";
            this.listaUsuarios.ReadOnly = true;
            this.listaUsuarios.RowHeadersWidth = 62;
            this.listaUsuarios.RowTemplate.Height = 25;
            this.listaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaUsuarios.Size = new System.Drawing.Size(779, 168);
            this.listaUsuarios.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre y Apellido";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // editUser
            // 
            this.editUser.Location = new System.Drawing.Point(820, 45);
            this.editUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editUser.Name = "editUser";
            this.editUser.Size = new System.Drawing.Size(159, 58);
            this.editUser.TabIndex = 2;
            this.editUser.Text = "Editar Usuario";
            this.editUser.UseVisualStyleBackColor = true;
            this.editUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Posts";
            // 
            // listadoPost
            // 
            this.listadoPost.AllowUserToAddRows = false;
            this.listadoPost.AllowUserToDeleteRows = false;
            this.listadoPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column3,
            this.Column4});
            this.listadoPost.Location = new System.Drawing.Point(17, 267);
            this.listadoPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listadoPost.Name = "listadoPost";
            this.listadoPost.ReadOnly = true;
            this.listadoPost.RowHeadersWidth = 62;
            this.listadoPost.RowTemplate.Height = 25;
            this.listadoPost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoPost.Size = new System.Drawing.Size(779, 250);
            this.listadoPost.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Usuario";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Post";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 300;
            // 
            // verPost
            // 
            this.verPost.Location = new System.Drawing.Point(820, 297);
            this.verPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.verPost.Name = "verPost";
            this.verPost.Size = new System.Drawing.Size(159, 63);
            this.verPost.TabIndex = 5;
            this.verPost.Text = "Ver Post";
            this.verPost.UseVisualStyleBackColor = true;
            this.verPost.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1041, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tags";
            // 
            // listadoTags
            // 
            this.listadoTags.AllowUserToAddRows = false;
            this.listadoTags.AllowUserToDeleteRows = false;
            this.listadoTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.listadoTags.Location = new System.Drawing.Point(1041, 62);
            this.listadoTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listadoTags.Name = "listadoTags";
            this.listadoTags.ReadOnly = true;
            this.listadoTags.RowHeadersWidth = 62;
            this.listadoTags.RowTemplate.Height = 25;
            this.listadoTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoTags.Size = new System.Drawing.Size(637, 258);
            this.listadoTags.TabIndex = 7;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Id";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Tags";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // EliminarTags
            // 
            this.EliminarTags.Location = new System.Drawing.Point(1259, 330);
            this.EliminarTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EliminarTags.Name = "EliminarTags";
            this.EliminarTags.Size = new System.Drawing.Size(159, 63);
            this.EliminarTags.TabIndex = 8;
            this.EliminarTags.Text = "Eliminar Tag";
            this.EliminarTags.UseVisualStyleBackColor = true;
            this.EliminarTags.Click += new System.EventHandler(this.eliminarTag_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1526, 658);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 57);
            this.button4.TabIndex = 9;
            this.button4.Text = "Cerrar Sesion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // eliminarPost
            // 
            this.eliminarPost.Location = new System.Drawing.Point(820, 418);
            this.eliminarPost.Name = "eliminarPost";
            this.eliminarPost.Size = new System.Drawing.Size(159, 58);
            this.eliminarPost.TabIndex = 10;
            this.eliminarPost.Text = "Eliminar Post";
            this.eliminarPost.UseVisualStyleBackColor = true;
            this.eliminarPost.Click += new System.EventHandler(this.eliminarPost_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 750);
            this.Controls.Add(this.eliminarPost);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.EliminarTags);
            this.Controls.Add(this.listadoTags);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.verPost);
            this.Controls.Add(this.listadoPost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editUser);
            this.Controls.Add(this.listaUsuarios);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button editUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView listadoPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button verPost;
        public System.Windows.Forms.DataGridView listaUsuarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView listadoTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button EliminarTags;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button eliminarPost;
    }
}