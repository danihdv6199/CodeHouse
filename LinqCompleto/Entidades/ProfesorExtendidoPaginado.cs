using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Entidades
{
    public class ProfesorExtendidoPaginado
    {
        public List<ProfesorExtendido> Resultados { get; set; }
        public int Pagina { get; set; }
        public int ElementosPorPagina { get; set; }
        public int Total { get; set; }
    }
}
