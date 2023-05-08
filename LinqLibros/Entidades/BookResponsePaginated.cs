using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibros.Entidades
{
	public class BookResponsePaginated
	{
		public List<BookResponse> Books { get; set; }
		public int Page { get; set; }
		public int ItemsPerPage { get; set;  }
		public int Total { get; set; }

	}
}
