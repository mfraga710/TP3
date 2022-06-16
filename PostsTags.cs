using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3
{
    public class PostsTags
    {
        public int idPost { get; set; }
        public Post Post { get; set; }
        public int idTag { get; set; }
        public Tag Tag { get; set; }
        public PostsTags() { }
    }
}
