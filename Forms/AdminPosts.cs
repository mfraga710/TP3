using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3.Forms
{
    public partial class AdminPosts : Form
    {
        private RedSocial rs;
        private Post post;
        private Admin frm1;
        private Comentario c;

        public AdminPosts(RedSocial rs1, Admin frm1, Post post)
        {
            this.frm1 = frm1;
            this.rs = rs1;
            this.post = post;
            InitializeComponent();
            refreshPost();
            refreshComent();

        }

        public void refreshPost()
        {
            foreach (Post p in rs.posts)
            {
                if (p.id == post.id)
                {
                    label1.Text = p.contenido;
                }
            }
        }

        public void refreshComent()
        {
            dataGridView1.Rows.Clear();
            foreach (Comentario c in post.comentarios)
            {
                dataGridView1.Rows.Add(c.id,c.contenido);
            }
        }

        private void editarPosteoBotton_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            textBox1.Show();
            textBox1.Text = label1.Text;
            AceptarPost.Show();
            CancelarEditPostButton.Show();
        }

        private void editComentButton_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            if (selrow.Count > 0)
            {
                int comentId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                c = rs.searchComent(comentId);
                groupBox6.Show();
                textBox2.Show();
                textBox2.Text = c.contenido;
                aceptarComment.Show();
                cancelarEditComentButton.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario");
            }
        }

        private void AceptarPost_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            rs.modificarPostAdmin(post.id,textBox1.Text);
            MessageBox.Show("El post ha sido modificado");
        }

        private void aceptarComment_Click(object sender, EventArgs e)
        {
            rs.modificarCommentAdmin(post, c.id, textBox2.Text);
            refreshComent();
            MessageBox.Show("El comentario ha sido modificado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {

                rs.comentarAdmin(post, rs.usuarioActual, textBox3.Text);
                refreshComent();
                MessageBox.Show("El comentario ha sido agregado");
            }
            else
            {
                MessageBox.Show("Comenta algo, ponele volunta");
            }
        }

        private void ElimComentButton_Click(object sender, EventArgs e)
        {
            
            var selrow = dataGridView1.SelectedRows;
            if (selrow.Count > 0)
            {
                int comentId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Comentario coment = rs.obtenerEfComments(comentId);
                rs.quitarComentario(coment);
                MessageBox.Show("El comentario ha sido eliminado");
                refreshComent();
            }
            else
            {
                MessageBox.Show("Seleccione un comentario por favor");
            }

        }

        private void CancelarEditPostButton_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
        }

        private void cancelarEditComentButton_Click(object sender, EventArgs e)
        {
            groupBox6.Hide();

        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            frm1.Enabled = true;
            this.Close();
        }
    }
}
