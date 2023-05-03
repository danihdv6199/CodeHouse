using LinqLibros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Interfaz
{
    public interface IDataService
	{
		List<Book> GetTop3BookMaxSales();
		List<Book> GetTop3BookMinSales();
		List<Book> GetBooks50Years();
		Book GetOldestBook();

	}
}
