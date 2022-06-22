using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    public class Tag
    {
        public int id { get; set; }
        public string palabra { get; set; }
        public ICollection<Post> Post { get; } = new List<Post>();
        public List<PostsTags> PostsTags { get; set; }

        public Tag() { }
        public Tag(string palabra)
        {
            this.id = id;
            this.palabra = palabra;
            //posts = new List<Post>();
        }
        public Tag(int id,string palabra, List<Post> posts)
        {
            this.id = id;
            this.palabra = palabra;
            //this.posts = posts;
        }
    }
}
