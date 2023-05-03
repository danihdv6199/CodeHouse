using LinqLibros.Entidades;
using LinqLibros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Clases
{
    public class DataService: IDataService
	{
		private List<Book> bookList { get; set; }
		private List<Autor> authorList { get; set; }

		public DataService()
		{
			ILoadService loadService = new LoadService();
			bookList = loadService.LoadBooks();
			authorList = loadService.LoadAuthors();
		}

		public List<Book> GetTop3BookMaxSales()
		{
			return (from b in bookList
						orderby b.Sales descending
						select b)
						.Take(3).ToList();

		}

		public List<Book> GetTop3BookMinSales()
		{
			return (from b in bookList
					orderby b.Sales ascending
					select b)
					.Take(3).ToList();
		}
		public List<Book> GetBooks50Years()
		{
			return (from b in bookList
					where b.PublicationDate >= (DateTime.Now.Year - 50)
					select b).OrderBy(b => b.PublicationDate).ToList();
		}

		public Book GetOldestBook()
		{
			return (from b in bookList
					orderby b.PublicationDate ascending
					select b).First();
		}

		public List<Autor> GetAuthors(string bookTitle = null)
		{
			return (from a in authorList
					join b in bookList on a.AuthorId equals b.AuthorId
					where string.IsNullOrEmpty(bookTitle)
						|| b.Title.StartsWith(bookTitle)
					select a).ToList();
		}
	}
}
