using LinqLibros.Entidades;
using LinqLibros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Clases
{
    public class LoadService : ILoadService
    {
        public List<Autor> LoadAuthors()
        {
            return new List<Autor>
            {
                new Autor(1, "Miguel de Cervantes"),
                new Autor(2, "Charles Dickens"),
                new Autor(3, "J. R. R. Tolkien"),
                new Autor(4, "Antoine de Saint-Exupéry"),
                new Autor(5, "Cao Xueqin"),
                new Autor(6, "Lewis Car"),
                new Autor(7, "Agatha Christie"),
                new Autor(8, "C. S. Lewis"),
                new Autor(9, "Dan Brown"),
                new Autor(10, "J. D. Salinger"),
            };
        }

        public List<Book> LoadBooks()
        {
            return new List<Book>
            {
                new Book("Don Quijote de la Mancha", 1, 1605, 500),
                new Book("Historia de dos ciudades", 2, 1859, 200),
                new Book("El Señor de los Anillos", 3, 1978, 150),
                new Book("El principito", 4, 1951, 140),
                new Book("El hobbit", 3, 1982, 100),
                new Book("Sueño en el pabellón rojo", 5, 1792, 100),
                new Book("Las aventuras de Alicia en el país de las maravillas", 6, 1865, 100),
                new Book("Diez negritos", 7, 1939, 100),
                new Book("El león, la bruja y el armario", 8, 1950, 85),
                new Book("El código Da Vinci", 9, 2003, 80),
                new Book("El guardián entre el centeno", 10, 1951, 65),
                new Book("El alquimista", 11, 1988, 65),
                new Book("El Lazarillo de Tormes", null, 1558, 335),
			};
        }
    }
}
