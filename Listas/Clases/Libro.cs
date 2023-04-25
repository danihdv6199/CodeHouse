using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codehouse_1.Clases
{
    public class Libro
    {
        public string Titulo { get; set; }
        public int AnioPublicacion { get; set; }
        public Persona Autor { get; set; }
    }
}
