using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    public class AmigosRel
    {
        public int idAmigo { get; set; }
        public Usuario amigo { get; set; }
        public int idUser { get; set; }
        public Usuario usuario { get; set; }
        public AmigosRel() { }
        public AmigosRel(int idA, int idU)
        {
            idAmigo = idA;
            idUser = idU;
        }
    }
}
