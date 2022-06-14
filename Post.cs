using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    public class Post
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public Usuario user { get; set; }
        public string contenido { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Reaccion> reacciones { get; set; }
        public List<Tag> tags { get; set; }
        public DateTime fecha { get; set; }

        public Post() { }
        public Post(int id,Usuario user, string contenido)
        {
            this.id =id ;
            this.user = user;
            this.contenido = contenido;
            reacciones = new List<Reaccion>();
            comentarios = new List<Comentario>();
            tags = new List<Tag>();
            this.fecha = DateTime.Now;

        }

        public Post(Usuario user, string contenido)
        {
            this.id = id;
            this.user = user;
            this.contenido = contenido;
            reacciones = new List<Reaccion>();
            comentarios = new List<Comentario>();
            tags = new List<Tag>();
            this.fecha = DateTime.Now;
        }

    }
}
