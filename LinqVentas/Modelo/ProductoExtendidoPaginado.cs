using _27_EjercicioLinqVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqVentas.Modelo
{
	public class ProductoExtendidoPaginado
	{
		public List<ProductoExtendido> Productos = new List<ProductoExtendido>();
		public int Pagina;
		public int ElementosPorPagina;
		public int Total;
	}
}
