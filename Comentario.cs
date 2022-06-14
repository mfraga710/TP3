using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    public class Comentario
    {
        public int id { get; set; }
        public int idPost { get; set; }
        public Post post { get; set; }
        public int idUser { get; set; }
        public Usuario usuario { get; set; }
        public string contenido { get; set; }
        public DateTime fecha { get; set; }

        static int idCont = 0;

        public Comentario() { }

        public Comentario(Post post, Usuario usuario, string contenido)
        {
            this.id = idCont++;
            this.post = post;
            this.usuario = usuario;
            this.contenido = contenido;
            DateTime fecha = DateTime.Now;
        }

        public Comentario(int id, Post post, Usuario usuario, string contenido)
        {
            this.id = id;
            this.post = post;
            this.usuario = usuario;
            this.contenido = contenido;
            DateTime fecha = DateTime.Now;
        }

    }
}
