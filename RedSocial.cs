using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace TP3
{
     public class RedSocial
     {
        public List<Usuario> usuarios { get; set; }

        private DbSet<Usuario> misUsuarios;
        public List<Post> posts { get; set; }
        private DbSet<Post> efPosts { get; set; }
        public List<Tag> tags { get; set; }
        public Usuario usuarioActual { get; set; }        
        private DbSet<Comentario> efComent { get; set; }
        private DbSet<Reaccion> efReacciones { get; set; }

        private MyContext context;

        private DAL DB;
        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
            tags = new List<Tag>();
            DB = new DAL();
            inicializarAtributos();

        }

        private void inicializarAtributos()
        {
            try
            {
                //creo contexto
                context = new MyContext();
                context.usuarios.Load();
                misUsuarios = context.usuarios;
                context.post.Load();
                efPosts = context.post;
                context.comentarios.Load();
                efComent = context.comentarios;
                context.reacciones.Load();
                efReacciones = context.reacciones;
                context.usuarios.Include(u => u.misAmigos).ThenInclude(ua => ua.user).Include(u => u.amigosMios).ThenInclude(ua => ua.amigo).Load();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            posts = DB.inicializarPosts();
            tags = DB.inicializarTags();

            List<Reaccion> reacciones = DB.inicializarReaccion();
            foreach (Reaccion reaccion in reacciones)
            {
                foreach (Post p in posts)
                {
                    if (p.id == reaccion.post.id)
                    {
                        p.reacciones.Add(reaccion);
                    }
                }
            }
            List<Comentario> comentarios = DB.inicializarComentarios();
            foreach (Post p in posts)
            {
                foreach (Comentario c in comentarios)
                {
                    if (p.id == c.post.id)
                    {
                        p.comentarios.Add(c);
                    }
                }
            }

            //foreach (Tag t in tags)
            //{
            //    foreach (Post pT in t.posts)
            //    {
            //        foreach (Post p in posts)
            //        {
            //            if (pT.id == p.id)
            //            {
            //                p.tags.Add(t);
            //            }
            //        }
            //    }
            //}

        }       
        public void registrarUsuario(string nombre, string apellido, string mail, int dni, string pass, bool isAdm)
        {
            Usuario nuevo = new Usuario(nombre,apellido, mail, dni, pass, isAdm);
            misUsuarios.Add(nuevo);
            context.SaveChanges();
        }
        public bool modificaUsuario(Usuario usuarioModificado)
        {
            bool salida = false;
            foreach (Usuario u in context.usuarios)
                if (u.id == usuarioModificado.id)
                {
                    u.nombre = usuarioModificado.nombre;
                    u.apellido = usuarioModificado.apellido;
                    u.email = usuarioModificado.email;
                    u.dni = usuarioModificado.dni;
                    context.usuarios.Update(u);
                    salida = true;
                }
            if (salida)
                context.SaveChanges();
            return salida;
        }
        public bool eliminarUsuario(Usuario u)
        {
            bool result = false;
            foreach (Usuario lU in context.usuarios)
            {
                if (lU.id == u.id)
                {
                    context.usuarios.Remove(lU);
                    result = true;
                }
            }
            if (result)
                context.SaveChanges();
            return result;
        }
        public bool iniciarSesion(string usuario, string pass)
        {
            bool flag = false;
            int intentos = 0;
            
            foreach (Usuario user in misUsuarios)
            {
                if (user.email.Equals(usuario) && user.password.Equals(pass)) 
                {
                    user.intentosFallidos = 0;
                    usuarioActual = user;
                    flag = true;
                }
                else { intentos++; }
            }
             return flag;
        }
        public void cerrarSesion(Forms.Home home,Login frm)
        {
            usuarioActual = null;
            home.Close();
            frm.Show();
        }
        public void cerrarSesionAdm(Forms.Admin adim, Login frm)
        {
            usuarioActual = null;
            adim.Close();
            frm.Show();
        }
        public void agregarAmigo(Usuario amigo)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.id == usuarioActual.id)
                {
                    DB.agregarAmigo(amigo.id,u.id);
                    DB.agregarAmigo(u.id, amigo.id);
                    u.amigos.Add(amigo);
                    amigo.amigos.Add(u);
                }
            }
        }
        public void quitarAmigo(Usuario exAmigo)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.id == usuarioActual.id)
                {
                    DB.eliminarAmigo(exAmigo.id, u.id);
                    DB.eliminarAmigo(u.id, exAmigo.id);
                    u.amigos.Remove(exAmigo);
                    exAmigo.amigos.Remove(u);                    
                }
            }
        }
        public bool efPostear(Usuario u, string contenido, List<Tag> newTags) 
        {
            try
            {
                Usuario user = context.usuarios.Where(usr => usr.id == u.id).FirstOrDefault();

                if (user != null)
                {
                    Post nPost = new Post(u, contenido);
                    user.misPosts.Add(nPost);
                    efPosts.Add(nPost);                    
                    context.SaveChanges();
                    
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool modificarPost(Post p)
        {
            bool salida = false;
            foreach(Post efp in efPosts)
            {
                if(efp.id == p.id)
                {
                    efp.contenido = p.contenido;
                    context.post.Update(efp);
                    salida = true;
                }
            }
            if(salida)
                context.SaveChanges();
            return salida;
        }
        public bool eliminarPost(Post p)
        {
            bool salida = false;
            foreach(Post efp in efPosts)
            {
                if (efp.id == p.id)
                {
                    efp.contenido = p.contenido;
                    context.post.Remove(efp);
                    salida = true;
                }
            }
            if (salida)
                context.SaveChanges();
            return salida;
        }
        public bool comentar(Post p, Comentario c) 
        {

            try
            {
                Post post = context.post.Where(pos => pos.id == p.id).FirstOrDefault();

                if (post != null)
                {
                    post.comentarios.Add(c);
                    context.comentarios.Add(c);
                    context.post.Update(post);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void modificarComentario(Comentario c)
        {
            context.comentarios.Update(c);
            context.SaveChanges();
        }
        public void modificarPostAdmin(int postId, string nuevoContenido)
        {
            if (postId != 0)
            {
                DB.modificarPostAdm(postId, nuevoContenido);
                foreach (Post post in posts)
                {
                    if (post.id == postId)
                    {
                        post.contenido = nuevoContenido;
                    }
                }
            }
        }
        public void comentarAdmin(Post p, Usuario u, string contenido)
        {
            //p.comentarios.Add(c);
            //Comentario coment = new Comentario(DB.agregarComentario(p, u, contenido), p, u, contenido);
            //p.comentarios.Add(coment);
        }
        public void modificarCommentAdmin(Post p,int comentId, string nuevoContenido)
        {
            if (comentId != 0)
            {
                DB.modificarCommentAdm(comentId, nuevoContenido);
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == comentId)
                    {
                        c.contenido = nuevoContenido;
                    }
                }
            }
        }
        public void quitarComentario(Comentario c)
        {
            context.comentarios.Remove(c);
            context.SaveChanges();
        }
        public void reaccionar(Post p, Reaccion r)
        {
            
            bool newReaction = true;
            foreach (Reaccion reaccion in p.reacciones)
            {
                if (reaccion.usuario.id == usuarioActual.id)
                {
                    newReaction = false;
                    modificarReaccion(p, r);
                }
            }
            if (newReaction)
            {
                context.reacciones.Add(r);
                context.SaveChanges();                                 
            }
        }        
        public void modificarReaccion(Post p, Reaccion r)
        {
            foreach (Reaccion reaccion in p.reacciones)
            {
                
                if (reaccion.usuario.id == usuarioActual.id)
                {
                    reaccion.tipoReaccion = r.tipoReaccion;
                    context.reacciones.Update(reaccion);
                    context.SaveChanges();                    
                }
            }
        }
        public void quitarReaccion(Post p, Reaccion r)
        {
            context.reacciones.Remove(r);
            context.SaveChanges();            
        }
        public Usuario mostrarDatos(Usuario u)
        {
          return u;
        }
        public List<Post> mostrarPosts()
        {
          return usuarioActual.misPosts;
        }
        public List<Post> mostrarPostsAmigos()
        {
            List<Post> postsAmigos = new List<Post>();
            foreach (Usuario amigo in usuarioActual.amigos)
            {
                postsAmigos.AddRange(amigo.misPosts);
            }

            return postsAmigos;
        }
        public List<Post> buscarPosts(String contenido, DateTime fechaDesde,DateTime fechaHasta, List<Tag> bTags)
        {
            List<Post> p = new List<Post>();
            string fDesde = fechaDesde.Date.ToString("dd/MM/yyyy");
            string hDesde = fechaHasta.Date.ToString("dd/MM/yyyy");
            bool tagAgregado = false;

            foreach (Post pPost in posts)
            {
                if (contenido != "" )
                {
                    if (pPost.contenido.Contains(contenido))
                    {
                        if (bTags.Count > 0)
                        {
                            if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                            {
                                foreach (Tag t in bTags)
                                {
                                    //foreach (Tag tPost in pPost.tags)
                                    //{
                                    //    if (t.palabra.Equals(tPost.palabra))
                                    //    {
                                    //        p.Add(pPost);
                                    //        tagAgregado = true;
                                    //        break;
                                    //    }
                                    //}
                                    if (tagAgregado)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                            {
                                p.Add(pPost);
                            }
                        }
                    }                    
                }
                else
                  {
                    if (bTags.Count > 0)
                    {
                        if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                        {
                            foreach (Tag t in bTags)
                            {
                                //foreach (Tag tPost in pPost.tags)
                                //{
                                //    if (t.palabra.Equals(tPost.palabra))
                                //    {
                                //        p.Add(pPost);
                                //        tagAgregado = true;
                                //        break;
                                //    }
                                //}
                                if (tagAgregado)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (pPost.fecha.Date >= fechaDesde.Date && pPost.fecha.Date <= fechaHasta.Date)
                        {
                            p.Add(pPost);
                        }
                    }
                }
            }   

            return p;
        }
        public Comentario searchComent(int id)
        {
            foreach (Post p in posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        return c;
                    }
                }
            }
            return null;
        }
        public Post searchPost(int idPost)
        {
            Post pRetornar = context.post.Where(p => p.id == idPost).FirstOrDefault();
            return pRetornar;
        }
        public Usuario searchUser(int idUser)
        {
            foreach (Usuario u in context.usuarios)
            {
                if (idUser == u.id)
                {
                    return u;
                }
            }
            return null;
        }
        public Tag searchTag(int idTag)
        {
            foreach (Tag t in tags)
            {
                if (idTag == t.id)
                {
                    return t;
                }
            }
            return null;
        }
        public bool bloqUser(int IdUsuario, bool Bloqueado)
        {
            bool salida = false;
            foreach (Usuario u in context.usuarios)
                if (u.id == IdUsuario)
                {
                    u.bloqueado = Bloqueado;
                    context.usuarios.Update(u);
                    salida = true;
                }
            if (salida)
                context.SaveChanges();
            return salida;
        }
        public void eliminarTag (int tagId)
        {
            var result = DB.eliminarTagRel(tagId);
            var result2 = DB.eliminarTag(tagId);
            tags.Remove(searchTag(tagId));


        }
        public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in context.usuarios)
                salida.Add(new List<string> { u.id.ToString(), u.nombre + " " + u.apellido });
            return salida;
        }
        public List<Post> obtenerPosts()
        {
            List<Post> salida = new List<Post>();
            foreach (Post p in context.post)
                salida.Add(p);
            return salida;
        }

        public Comentario obtenerEfComments(int cId) 
        {
            return context.comentarios.Where(c => c.id == cId).FirstOrDefault();
        }

        public Reaccion obtenerEfReaccion(int uId)
        {
            return context.reacciones.Where(c => c.idUser == uId).FirstOrDefault();
        }
        public List<Comentario> obtenerComentario()
        {
            List<Comentario> salida = new List<Comentario>();
            foreach (Comentario c in context.comentarios)
                salida.Add(c);
            return salida;
        }
    }
}
