namespace TP3.Forms
{
    partial class AdminPosts
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Posteo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editarPosteoBotton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CancelarEditPostButton = new System.Windows.Forms.Button();
            this.AceptarPost = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ElimComentButton = new System.Windows.Forms.Button();
            this.editComentButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cancelarEditComentButton = new System.Windows.Forms.Button();
            this.aceptarComment = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.salirButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Posteo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Posteo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Posteo
            // 
            this.Posteo.Controls.Add(this.label1);
            this.Posteo.Location = new System.Drawing.Point(6, 12);
            this.Posteo.Name = "Posteo";
            this.Posteo.Size = new System.Drawing.Size(557, 74);
            this.Posteo.TabIndex = 5;
            this.Posteo.TabStop = false;
            this.Posteo.Text = "Posteo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editarPosteoBotton);
            this.groupBox2.Location = new System.Drawing.Point(608, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posteo";
            // 
            // editarPosteoBotton
            // 
            this.editarPosteoBotton.Location = new System.Drawing.Point(18, 43);
            this.editarPosteoBotton.Name = "editarPosteoBotton";
            this.editarPosteoBotton.Size = new System.Drawing.Size(75, 23);
            this.editarPosteoBotton.TabIndex = 0;
            this.editarPosteoBotton.Text = "Editar";
            this.editarPosteoBotton.UseVisualStyleBackColor = true;
            this.editarPosteoBotton.Click += new System.EventHandler(this.editarPosteoBotton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CancelarEditPostButton);
            this.groupBox3.Controls.Add(this.AceptarPost);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(741, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 146);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Editar Posteo";
            this.groupBox3.Visible = false;
            // 
            // CancelarEditPostButton
            // 
            this.CancelarEditPostButton.Location = new System.Drawing.Point(261, 106);
            this.CancelarEditPostButton.Name = "CancelarEditPostButton";
            this.CancelarEditPostButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarEditPostButton.TabIndex = 1;
            this.CancelarEditPostButton.Text = "Cancelar";
            this.CancelarEditPostButton.UseVisualStyleBackColor = true;
            this.CancelarEditPostButton.Click += new System.EventHandler(this.CancelarEditPostButton_Click);
            // 
            // AceptarPost
            // 
            this.AceptarPost.Location = new System.Drawing.Point(136, 107);
            this.AceptarPost.Name = "AceptarPost";
            this.AceptarPost.Size = new System.Drawing.Size(75, 23);
            this.AceptarPost.TabIndex = 1;
            this.AceptarPost.Text = "Aceptar";
            this.AceptarPost.UseVisualStyleBackColor = true;
            this.AceptarPost.Click += new System.EventHandler(this.AceptarPost_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 78);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 321);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Comentarios";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 22);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(551, 279);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Comentario";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 450;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ElimComentButton);
            this.groupBox5.Controls.Add(this.editComentButton);
            this.groupBox5.Location = new System.Drawing.Point(608, 186);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 100);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Comentario";
            // 
            // ElimComentButton
            // 
            this.ElimComentButton.Location = new System.Drawing.Point(18, 66);
            this.ElimComentButton.Name = "ElimComentButton";
            this.ElimComentButton.Size = new System.Drawing.Size(75, 23);
            this.ElimComentButton.TabIndex = 7;
            this.ElimComentButton.Text = "Eliminar";
            this.ElimComentButton.UseVisualStyleBackColor = true;
            this.ElimComentButton.Click += new System.EventHandler(this.ElimComentButton_Click);
            // 
            // editComentButton
            // 
            this.editComentButton.Location = new System.Drawing.Point(18, 27);
            this.editComentButton.Name = "editComentButton";
            this.editComentButton.Size = new System.Drawing.Size(75, 23);
            this.editComentButton.TabIndex = 1;
            this.editComentButton.Text = "Editar";
            this.editComentButton.UseVisualStyleBackColor = true;
            this.editComentButton.Click += new System.EventHandler(this.editComentButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cancelarEditComentButton);
            this.groupBox6.Controls.Add(this.aceptarComment);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Location = new System.Drawing.Point(741, 164);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(487, 122);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Editar Comentarios";
            this.groupBox6.Visible = false;
            // 
            // cancelarEditComentButton
            // 
            this.cancelarEditComentButton.Location = new System.Drawing.Point(261, 88);
            this.cancelarEditComentButton.Name = "cancelarEditComentButton";
            this.cancelarEditComentButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarEditComentButton.TabIndex = 2;
            this.cancelarEditComentButton.Text = "Cancelar";
            this.cancelarEditComentButton.UseVisualStyleBackColor = true;
            this.cancelarEditComentButton.Click += new System.EventHandler(this.cancelarEditComentButton_Click);
            // 
            // aceptarComment
            // 
            this.aceptarComment.Location = new System.Drawing.Point(136, 88);
            this.aceptarComment.Name = "aceptarComment";
            this.aceptarComment.Size = new System.Drawing.Size(75, 23);
            this.aceptarComment.TabIndex = 1;
            this.aceptarComment.Text = "Aceptar";
            this.aceptarComment.UseVisualStyleBackColor = true;
            this.aceptarComment.Click += new System.EventHandler(this.aceptarComment_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 24);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(475, 48);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.Location = new System.Drawing.Point(614, 331);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(608, 23);
            this.textBox3.TabIndex = 6;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Location = new System.Drawing.Point(608, 297);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(620, 100);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Comentar";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(539, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Comentar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // salirButton
            // 
            this.salirButton.Location = new System.Drawing.Point(1128, 418);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(100, 40);
            this.salirButton.TabIndex = 7;
            this.salirButton.Text = "Salir";
            this.salirButton.UseVisualStyleBackColor = true;
            this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // AdminPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 470);
            this.Controls.Add(this.salirButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Name = "AdminPosts";
            this.Text = "AdminPosts";
            this.groupBox1.ResumeLayout(false);
            this.Posteo.ResumeLayout(false);
            this.Posteo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Posteo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editarPosteoBotton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button CancelarEditPostButton;
        private System.Windows.Forms.Button AceptarPost;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button editComentButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button cancelarEditComentButton;
        private System.Windows.Forms.Button aceptarComment;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ElimComentButton;
        private System.Windows.Forms.Button salirButton;
    }
}