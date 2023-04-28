using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Clases
{
    public class Autor
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public Autor(int authorId, string name) 
        {
            this.AuthorId = authorId; 
            this.Name = name; 
        }
    }
}
