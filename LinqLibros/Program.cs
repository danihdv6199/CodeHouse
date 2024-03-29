﻿// See https://aka.ms/new-console-template for more information

using LinqLibros.Clases;
using LinqLibros.Entidades;
using LinqLibros.Interfaz;

IDataService dataService = new DataService();

Console.WriteLine("\n------------------------Top 3 ventas----------------------\n");

List<Book> listBookTop3MaxSales = dataService.GetTop3BookMaxSales();

ImprimirVentas(listBookTop3MaxSales);

Console.WriteLine("\n------------------------Min 3 ventas----------------------\n");

List<Book> listBookTop3MinSales = dataService.GetTop3BookMinSales();

ImprimirVentas(listBookTop3MinSales);

Console.WriteLine("\n------------------------LIbros en los ult 50 años----------------------\n");

List<Book> listBookWith50Years = dataService.GetBooks50Years();

foreach (Book b in listBookWith50Years)
{
	Console.WriteLine($"El libro {b.Title} es de {b.PublicationDate} \n");
}

Console.WriteLine("\n------------------------LIbro mas antiguo----------------------\n");

Book oldestBook = dataService.GetOldestBook();
Console.WriteLine($"El libro mas antiguo es {oldestBook.Title}");

Console.WriteLine("\n------------------------Autores que tienen libros publicados que comienzan por EL----------------------\n");

List<Autor> autors = dataService.GetAuthors("El");

foreach(Autor a in autors)
{
	Console.WriteLine($"El autor {a.Name} tiene libros que comienzan por El");
}


Console.WriteLine("\n----------------------El autor con mas libros publicados--------------------\n");
AutorResponse autorBestPublisher = dataService.GetAuthorBestPublisher();
Console.WriteLine($"El autor {autorBestPublisher.AuthorName} tiene {autorBestPublisher.BookPublished} libros");


Console.WriteLine("\n----------------------Libros publicados por autor--------------------\n");
List<AutorResponse> booksPublished = dataService.GetAuthorsAndBooksPublished();

foreach(AutorResponse a in booksPublished)
{
	Console.WriteLine($"El autor{a.AuthorName} tiene publicados {a.BookPublished} libros");
}


Console.WriteLine("\n----------------------LIbros y autores join--------------------\n");
List<BookResponse> booksJoinAuthor = dataService.GetBooksJoinAuthor();
foreach(BookResponse b in booksJoinAuthor)
{
	Console.WriteLine($"El libro {b.BookTitle} fue escrito por {b.AuthorName}");
}

Console.WriteLine("\n----------------------LIbros y autores LeftJoin--------------------\n");
List<BookResponse> booksleftJoinAuthor = dataService.GetBooksLeftJoinAuthor();
foreach (BookResponse b in booksleftJoinAuthor)
{
	Console.WriteLine($"El libro {b.BookTitle} fue escrito por {b.AuthorName}");
}


Console.WriteLine("\n----------------------LIbros y autores LeftJoin paginados--------------------\n");
BookResponsePaginated leftJoinPaginated = dataService.GetBooksLeftJoinAuthorPaginated(1, 5);
foreach (BookResponse b in leftJoinPaginated.Books)
{
	Console.WriteLine($"El libro {b.BookTitle} fue escrito por {b.AuthorName}");
}

void ImprimirVentas(List<Book> listBook)
{
	foreach(Book b in listBook)
	{
		Console.WriteLine($"El libro {b.Title} tiene {b.Sales} ventas\n");
	}
}