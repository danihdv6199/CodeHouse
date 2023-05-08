using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Entidades
{
    public class Book
    {
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public int PublicationDate { get; set; } // Yearint Sales { get; set; } //Millions 
        public int Sales { get; set; }

        public Book(string title, int? authorId, int publicationDate, int sales)
        {
            Title = title;
            AuthorId = authorId;
            PublicationDate = publicationDate;
            Sales = sales;
        }
    }
}
