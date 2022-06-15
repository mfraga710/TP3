using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3
{
    public class  UsuarioAmigo
    {
        public int idUser { get; set; }
        //[ForeignKey(nameof(num_usr))]
        public Usuario user { get; set; }
        public int idAmigo { get; set; }
        //[ForeignKey(nameof(num_usr2))]
        public Usuario amigo { get; set; }

        public UsuarioAmigo() { }

        public UsuarioAmigo(Usuario ppal, Usuario segundo)
        {
            user = ppal;
            amigo = segundo;
        }
    }
}
