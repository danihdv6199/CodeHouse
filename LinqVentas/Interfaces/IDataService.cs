using LinqVentas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqVentas.Interfaces
{
	public interface IDataService
	{
		ProductoExtendidoPaginado GetVentas(string? nombreProducto = null, string? tipoProducto = null, int minVentas = 0, int maxVentas = 0, DateTime? fechaDesde = null, DateTime? fechaHasta = null, double? importeDesde = null, double? importeHasta = null, int pagina = 1, int elementosPorPagina = 1);
	}
}
