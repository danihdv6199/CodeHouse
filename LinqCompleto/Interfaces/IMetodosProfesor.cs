using LinqCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Interfaces
{
    public interface IMetodosProfesor
    {
        ProfesorExtendidoPaginado GetProfesores(string? filtroPoblacion = null, int pagina = 1, int elementosPorPagina = 1);
    }
}
