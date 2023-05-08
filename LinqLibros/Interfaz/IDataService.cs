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
		List<Autor> GetAuthors(string? bookTitle = null);
		AutorResponse GetAuthorBestPublisher();
		List<AutorResponse> GetAuthorsAndBooksPublished();
		List<BookResponse> GetBooksJoinAuthor();
		List<BookResponse> GetBooksLeftJoinAuthor();
		BookResponsePaginated GetBooksLeftJoinAuthorPaginated(int page, int itemsPerPage);

	}
}
