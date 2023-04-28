using LinqLibros.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Interfaz
{
    public interface ILoadService
    {
        List<Autor> LoadAuthors();
        List<Book> LoadBooks();
    }
}
