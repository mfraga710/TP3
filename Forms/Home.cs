using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3.Forms
{
    public partial class Home : Form
    {
        private RedSocial rs;
        private Login frm;
        public Home(RedSocial rs1, Login formLogin)
        {
            this.rs = rs1;
            frm = formLogin;
            InitializeComponent();

            // AGREGA NOMBRE DE USUARIO
            labelNombreUsuario.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;

            refreshAmigos();            
            refreshNoAmigos();            
            refreshHomePosts(rs.obtenerPosts());

            //dataGridViewPosts.Rows.Clear();
        }
       
        // PICTURE BOX - MUESTRA LOS AMIGOS A AGREGAR
        private void pBoxAbrirBuscarAmigos_Click(object sender, EventArgs e)
        {
            labelBuscarAmigos.Show();
            dataGridViewBuscarAmigos.Show();
            btnAgregarAmigo.Show();
            btnSalirBuscarAmigos.Show();            
        }

        // BUTTON - AGREGA AMIGO
        private void btnAgregarAmigo_Click(object sender, EventArgs e)
        {
            agregarAmigo();
        }
        private void agregarAmigo()
        {
            var selrow = dataGridViewBuscarAmigos.SelectedRows;
            int amigoId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            Usuario u = rs.searchUser(amigoId);
            rs.agregarAmigo(u);
            refreshAmigos();
            refreshNoAmigos();
        }

        // BUTTON - CIERRA LISTBOX 2
        private void btnSalirBuscarAmigos_Click(object sender, EventArgs e)
        {
            labelBuscarAmigos.Visible = false;
            labelBuscarAmigos.Visible = false;
            dataGridViewBuscarAmigos.Visible = false;
            btnAgregarAmigo.Visible = false;
            btnSalirBuscarAmigos.Visible = false;
        }

        // PICTUREBOX - ELIMINA AMIGO
        private void pBoxEliminarAmigo_Click(object sender, EventArgs e)
        {
            eliminarAmigo();
        }

        private void eliminarAmigo()
        {
            var selrow = dataGridViewAmigos.SelectedRows;
            int amigoId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            Usuario u = rs.searchUser(amigoId);
            
            rs.quitarAmigo(u);
            refreshAmigos();
            refreshNoAmigos();
        }       

        // BUTTON - POSTEA
        private void btnPublicarPost_Click(object sender, EventArgs e)
        {
            rs.efPostear(rs.usuarioActual, textBoxNuevoPost.Text, crearTag());            
            refreshHomePosts(rs.obtenerPosts());
            textBoxNuevoPost.Clear();
            MessageBox.Show("Su posteo ha sido publicado correctamente");
            
            //string[] sTags = textBoxNuevoTag.Text.Split('#');
            //textBoxNuevoTag.Clear();           
        }
        //corregir y ver si lo cambio a la clase red social
        private List<Tag> crearTag()
        {
            string[] sTags = textBoxNuevoTag.Text.Split('#');
            List<Tag> listTags = new List<Tag>();

            foreach (var word in sTags)
            {
                if (word.Length > 1)
                {
                    if (rs.tags.Count > 0)
                    {
                        foreach (Tag tag in rs.tags)
                        {             
                            if (!tag.palabra.Equals("#" + word))
                            {
                                listTags.Add(new Tag("#" + word));
                            }
                        }
                    }
                    else
                    {
                        listTags.Add(new Tag("#" + word));
                    }
                }
            }
            return listTags;
        }

        // BUTTON - COMENTA EL POST
        private void btnComentarPost_Click(object sender, EventArgs e)
        {
            var selrow = dataGridViewPosts.SelectedRows;

            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());

                crearContenido(postId);

                textBoxComentarPost.Clear();
                MessageBox.Show("Su comentario ha sido ingresado correctamente");
            }
            else 
            {
                MessageBox.Show("Debe seleccionar un post para comentarlo");
            }
        }

        private void crearContenido(int idP)
        {
            foreach (Post p in rs.obtenerPosts())
            {
                if (p.id == idP)
                {
                    string contenido = textBoxComentarPost.Text;
                    Comentario coment = new Comentario(p, rs.usuarioActual, contenido);
                    rs.comentar(p,coment);
                    rs.obtenerComentario();
                    refreshList(p);
                }
            }
        }
        // BUTTON - EDITAR USUARIO
        private void btnModUsuario_Click(object sender, EventArgs e)
        {
            EditarUsuario edit = new EditarUsuario(rs,this, rs.searchUser(rs.usuarioActual.id), frm);
            this.Enabled = false;         
            edit.Show();            
        }

        // BUTTON - MODIFICAR POST
        private void btnVerPost_Click(object sender, EventArgs e)
        {
            var selrow = dataGridViewPosts.SelectedRows;
            if (selrow.Count >0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Posteos edit = new Posteos(rs, this, postId);
                this.Enabled = false;
                edit.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }            
        }
        // BUTTON - ELIMINAR POST
        private void btnEliminarPost_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void eliminarRegistro()
        {
            Post pBorrar = null;
            var selrow = dataGridViewPosts.SelectedRows;
            int sel = dataGridViewPosts.CurrentRow.Index;
            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                foreach (Post p in rs.obtenerPosts())
                {
                    if (p.id == postId)
                    {
                        pBorrar = p;
                        break;
                    }
                }
                if (pBorrar == null)
                {
                    MessageBox.Show("El registro seleccionado no existe");
                }
                else
                {
                    if (rs.usuarioActual.id == pBorrar.user.id || rs.usuarioActual.isAdm)
                    {
                        //Se realiza el -1 ya que los indices del datgriu empiezan en 0, en la DB en 1                    
                        dataGridViewPosts.Rows.RemoveAt(sel);
                        rs.eliminarPost(pBorrar);
                        dataGridViewComentarios.Rows.Clear();
                        
                        MessageBox.Show("Su posteo ha sido eliminado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El post no se puede eliminar ya que no es de su usuario.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un post a eliminar");
            }
        }

        // CERRAR SESION
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            rs.cerrarSesion(this,frm);
        }

        // BUTTON - MOSTRAR DATOS
        private void btnVerUsuario_Click(object sender, EventArgs e)
        {
            MostrarUsuario mostrar = new MostrarUsuario(rs, this, rs.usuarioActual);
            this.Enabled = false;
            mostrar.Show();
        }

        // BUTTON - EDITAR COMENTARIO
        private void btnEditarComentario_Click(object sender, EventArgs e)
        {
            editarComent();
        }

        private void editarComent()
        {
            var selrow = dataGridViewComentarios.SelectedRows;
            if (selrow.Count > 0) 
            {
                // selrow.Count para que no pinche cuando no se selecciona ningún comentario
                if (selrow == null || selrow.Count <= 0)
                {
                    MessageBox.Show("Por favor seleccione un comentario a modificar");
                }
                else
                {
                    int comtId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                    Comentario coment = rs.obtenerEfComments(comtId);
                    EditarComentario edit = new EditarComentario(rs, this, coment);
                    this.Enabled = false;
                    edit.Show();
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un comentario para editar");
            }            
        }
        // BUTTON - ELIMINA COMENTARIO
        private void btnEliminarComentario_Click(object sender, EventArgs e)
        {
            var selrow = dataGridViewComentarios.SelectedRows;
            if (selrow.Count > 0) 
            {
                int comtId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Comentario coment = rs.obtenerEfComments(comtId);
                rs.quitarComentario(coment);
                refreshCommentsGrid();
            }
            else 
            {
                MessageBox.Show("Debe seleccionar un comentario para eliminar");
            }
        }
        
        // IDENTIFICADOR DEL ID DEL POST
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selrow = dataGridViewPosts.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            Post p = rs.searchPost(postId);
            refreshList(p);
        }

        // RECARGAR COMENTARIOS
        public void refreshCommentsGrid()
        {
            dataGridViewComentarios.Rows.Clear();
            foreach (Post p in rs.obtenerPosts())
            {
                foreach (Comentario c in p.comentarios)
                {
                    dataGridViewComentarios.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
                }
            }
        }
        // FUNCION QUE REFRESCA LISTA NO AMIGO
        public void refreshNoAmigos()
        {
            dataGridViewBuscarAmigos.Rows.Clear();
            // VERIFICA QUE NO TENGA AMIGOS
            if (rs.usuarioActual.misAmigos.Count <= 0)
            {   // CARGA TODOS LOS USUARIOS
                foreach (Usuario user in rs.getAllUsers())
                {   
                    if (!user.isAdm)
                    {
                        if (user.id != rs.usuarioActual.id)
                        {
                            dataGridViewBuscarAmigos.Rows.Add(user.id, user.nombre + " " + user.apellido);
                        }

                    }
                }
            }
            else
            {
                bool isFriend=false;
                foreach (Usuario user in rs.getAllUsers())
                {
                    if (!user.isAdm)
                    {
                        if (rs.usuarioActual.id != user.id)
                        {
                            foreach (UsuarioAmigo amigo in rs.usuarioActual.misAmigos)
                            {
                                if (user.id == amigo.idUser)
                                {
                                    isFriend = true;
                                    break;
                                }
                                else
                                {
                                    isFriend = false;
                                }
                            }
                            if (!isFriend)
                            {
                                dataGridViewBuscarAmigos.Rows.Add(user.id, user.nombre + " " + user.apellido);
                            }
                        }
                    }
                }
            }
        }

        // FUNCION QUE REFRESCA LISTA DE AMIGO
        public void refreshAmigos()
        {
            dataGridViewAmigos.Rows.Clear();
            foreach (UsuarioAmigo user in rs.usuarioActual.misAmigos)
            {
                dataGridViewAmigos.Rows.Add(user.amigo.id, user.amigo.nombre + " " + user.amigo.apellido);
            }
        }
        // RECARGAR LA LISTA DE POST
        private void refreshList(Post p)
        {
            if(p != null) { 
                dataGridViewComentarios.Rows.Clear();
                foreach (Comentario c in p.comentarios)
                {
                    dataGridViewComentarios.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
                }
            }
        }
        // BOTON MOSTRAR MIS POSTS
        private void btnVerMisPost_Click(object sender, EventArgs e)
        {
            refreshHomePosts(rs.mostrarPosts());
        }

        //buscador de post a traves de tags
        private void btnBuscarPost_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dateTimePicker1.Value;
            DateTime fechaHasta = dateTimePicker2.Value;
            string pContenido = textBoxBuscarContenido.Text;
            List<string> tags = new List<string>();
            string[] sTags = textBoxBuscarTags.Text.Split('#');

            foreach (var word in sTags)
            {
                if (word.Length > 1)
                {
                        tags.Add("#" + word);
                }                                       
            }
            List<Post> listaPost = rs.buscarPosts(pContenido, fechaDesde, fechaHasta, tags);

            if (listaPost.Count > 0)
            {
                MessageBox.Show("Su busqueda se ha realizado con exito");
                refreshHomePosts(listaPost);
            }
            else
            {
                MessageBox.Show("Su busqueda devolvio 0 coincidencias");
                refreshHomePosts(rs.obtenerPosts());
            }
        }
        // BUTTON - VER POSTS DE AMIGOS
        private void btnVerPostAmigos_Click(object sender, EventArgs e)
        {
            List<Post> listaPost = rs.mostrarPostsAmigos();

            if (listaPost.Count > 0)
            {
                refreshHomePosts(listaPost);
            }
            else
            {
                MessageBox.Show("Usted no tiene amigos");
            }
        }
        // BUTTON - VER TODOS LOS POSTS
        private void btnVerAllPosts_Click(object sender, EventArgs e)
        {
            refreshHomePosts(rs.obtenerPosts());
        }

        private void btnSalirApp_Click(object sender, EventArgs e)
        {
            rs.cerrarContextP();
            Application.Exit();
        }

        private void refreshHomePosts(List<Post> listaPost)
        {

            dataGridViewPosts.Rows.Clear();
            
            foreach (Post p in listaPost)
            {
                string pTags = "";
                foreach (Tag t in p.Tag)
                {                    
                    pTags = pTags + t.palabra + " ";
                }
                dataGridViewPosts.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contenido, pTags);
            }            
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void textBoxBuscarTags_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
