using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3.Forms
{
    public partial class EditarComentario : Form
    {
        private RedSocial rs;
        private int idComment;
        private int idPost;
        private Home frm;
        private Comentario lComment;


        public EditarComentario(RedSocial rs1, Home frm1, Comentario c)
        {
            this.frm = frm1;
            this.rs = rs1;
            lComment = c;
            InitializeComponent();
            textBoxEditComentario.Text = lComment.contenido;
        }

        //GUARDAR CAMBIOS COMENTARIO EDITADO
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            lComment.contenido = textBoxEditComentario.Text;
            rs.modificarComentario(lComment);
            frm.refreshCommentsGrid();
            frm.Enabled = true;
            this.Close();
        }

    }
}
