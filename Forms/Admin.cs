using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TP3.Forms
{
    public partial class Admin : Form
    {
        private RedSocial rs;
        private Login frm;
        public Admin(RedSocial rs1, Login formLogin)
        {
            this.rs = rs1;
            frm = formLogin;

            InitializeComponent();
            refreshUsuariosEF();
            refreshTags();
            refreshPost();
        }


        public void refreshUsuariosEF()
        {
            listaUsuarios.Rows.Clear();
            foreach (List<string> usuario in rs.obtenerUsuarios())
                listaUsuarios.Rows.Add(usuario.ToArray());
        }
        public void refreshPost()
        {
            listadoPost.Rows.Clear();
            foreach (Post post in rs.obtenerPosts())
            {
                listadoPost.Rows.Add(post.id, post.user.nombre + " " + post.user.apellido, post.contenido);
            }
        }


        public void refreshTags()
        {
            listadoTags.Rows.Clear();
            foreach (Tag t in rs.obtenerEfTags())
            {
                listadoTags.Rows.Add(t.id, t.palabra);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selrow = listaUsuarios.SelectedRows;
            if (selrow.Count > 0)
            {
                int userId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Usuario u = rs.searchUser(userId);
                EditarUsuario mostrar = new EditarUsuario(rs, this, u);
                this.Enabled = false;
                mostrar.Show();
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rs.cerrarSesionAdm(this, frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selrow = listadoPost.SelectedRows;
            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Post p = rs.searchPost(postId);
                AdminPosts adminPost = new AdminPosts(rs, this, p);
                this.Enabled = false;
                adminPost.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }
        }

        private void eliminarTag_Click(object sender, EventArgs e)
        {
            var selrow = listadoTags.SelectedRows;
            if (selrow.Count > 0)
            {                
                int tagId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                rs.eliminarTag(tagId);
                refreshTags();


                MessageBox.Show("El tag fue borrado");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tag");
            }
        }

        private void eliminarPost_Click(object sender, EventArgs e)
        {
            var selrow = listadoPost.SelectedRows;
            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Post p = rs.searchPost(postId);
                rs.eliminarPost(p);
                refreshPost();
                MessageBox.Show("El post fue borrado");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }
        }


    }
}
