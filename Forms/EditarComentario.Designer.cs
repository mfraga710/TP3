namespace TP3.Forms
{
    partial class EditarComentario
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
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.textBoxEditComentario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(55, 120);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(120, 31);
            this.btnGuardarCambios.TabIndex = 33;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // textBoxEditComentario
            // 
            this.textBoxEditComentario.Location = new System.Drawing.Point(11, 26);
            this.textBoxEditComentario.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEditComentario.Multiline = true;
            this.textBoxEditComentario.Name = "textBoxEditComentario";
            this.textBoxEditComentario.Size = new System.Drawing.Size(209, 73);
            this.textBoxEditComentario.TabIndex = 32;
            // 
            // EditarComentario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 162);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.textBoxEditComentario);
            this.Name = "EditarComentario";
            this.Text = "Editar Comentario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.TextBox textBoxEditComentario;
    }
}