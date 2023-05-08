using LinqLibros.Entidades;
using LinqLibros.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Clases
{
	public class DataService : IDataService
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

		public List<Autor> GetAuthors(string? bookTitle = null) //para poner parametros opcionales, ponemos valores por defecto
		{
			return (from a in authorList
					join b in bookList on a.AuthorId equals b.AuthorId
					where string.IsNullOrEmpty(bookTitle) //filtro opcional, si llega nulo -> nada
						|| b.Title.StartsWith(bookTitle)
					select a).Distinct().ToList();
		}

		public List<AutorResponse> GetAuthorsAndBooksPublished()
		{
			//La key de una agrupacion es el campo por el que estemos agrupando, en este caso AuthorId
			return (from b in bookList
					group b by b.AuthorId into bookGroup
					join a in authorList on bookGroup.Key equals a.AuthorId
					select new AutorResponse
					{
						AuthorName = a.Name,
						BookPublished = bookGroup.Count(),
					}).ToList();
		}
		public List<AutorResponse> GetAuthorsAndBooksPublished2()
		{
			return (from a in authorList
					select new AutorResponse
					{
						AuthorName = a.Name,
						BookPublished = bookList.Where(b => b.AuthorId == a.AuthorId).Count()
						//from b in bookList
						//where b.AuthorId == a.AuthorId
						//select b).Count()
					}).ToList();
		}
        public List<AutorResponse> GetAuthorsAndBooksPublished3()
        {
			List<AutorResponse> result = new List<AutorResponse>();
			foreach(Autor author in authorList)
			{
				result.Add(
					new AutorResponse
					{
						AuthorName = author.Name,
						//En vez de hacer lambda se puede hacer otro foreach
						BookPublished = bookList.Where(b => b.AuthorId == author.AuthorId).Count()
					}
					);
			}
			return result;
        }

        public AutorResponse GetAuthorBestPublisher()
		{
			return (from b in bookList
					group b by b.AuthorId into bookGroup
					orderby bookGroup.Count() descending
					join a in authorList on bookGroup.Key equals a.AuthorId
					select new AutorResponse
					{
						AuthorName = a.Name,
						BookPublished = bookGroup.Count()
					}).First();
		}

		public List<BookResponse> GetBooksJoinAuthor()
		{
			return (from b in bookList
					join a in authorList on b.AuthorId equals a.AuthorId
					select new BookResponse
					{
						AuthorName = a.Name,
						BookTitle = b.Title
					}
						).ToList();
		}

		public List<BookResponse> GetBooksLeftJoinAuthor()
		{
			return (from b in bookList
					join a in authorList on b.AuthorId equals a.AuthorId into authorBooks
					from authBook in authorBooks.DefaultIfEmpty()
					select new BookResponse
					{
						AuthorName = authBook == null ? "Anonimo" : authBook.Name,
						BookTitle = b.Title
					}
					 ).ToList();
		}

		public BookResponsePaginated GetBooksLeftJoinAuthorPaginated( int page, int itemsPerPage)
		{
			BookResponsePaginated result = new BookResponsePaginated();

			var query = from b in bookList
						join a in authorList on b.AuthorId equals a.AuthorId into authorBooks
						from authBook in authorBooks.DefaultIfEmpty()
						select new BookResponse
						{
							
							AuthorName = authBook == null ? "Anonimo" : authBook.Name,
							BookTitle = b.Title
						};

			result.Total = query.Count();
			result.Page = page;
			result.ItemsPerPage = itemsPerPage;
			int skip = (page-1) * itemsPerPage;

			result.Books = query.Skip(skip).Take(itemsPerPage).ToList();

			return result;
		}

	}

}
