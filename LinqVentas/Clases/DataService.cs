using _27_EjercicioLinqVentas.Clases;
using _27_EjercicioLinqVentas.Entidades;
using _27_EjercicioLinqVentas.Interfaces;
using LinqVentas.Interfaces;
using LinqVentas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqVentas.Clases
{
	public class DataService: IDataService
	{
		private List<Producto> productos { get; set; }
		private List<Venta> ventas = new List<Venta>();
		private List<TipoProducto> tipoProductos = new List<TipoProducto>();

		public DataService()
		{
			ILoadDataService loadDataService = new LoadDataService();
			this.productos = loadDataService.ObtenerProductos();
			this.tipoProductos = loadDataService.ObtenerTiposProductos();
			this.ventas = loadDataService.ObtenerVentas();
		}

		public ProductoExtendidoPaginado GetVentas(string? nombreProducto = null, string? tipoProducto = null, int minVentas = 0, int maxVentas = 0, DateTime? fechaDesde = null, DateTime? fechaHasta = null, double? importeDesde = null, double? importeHasta = null, int pagina = 1, int elementosPorPagina = 1)
		{
			ProductoExtendidoPaginado result = new ProductoExtendidoPaginado();

			var query = from v in ventas
						join p in productos on v.ProductoId equals p.Id
						join t in tipoProductos on p.TipoProductoId equals t.Id
						let importeTotal = v.Cantidad * p.PrecioUnitario
						where (string.IsNullOrEmpty(nombreProducto) || p.Descripcion == nombreProducto)
							&& (string.IsNullOrEmpty(tipoProducto) || t.Descripcion ==tipoProducto)
							&& (fechaDesde == null || v.FechaVenta >= fechaDesde)
							&& (fechaHasta == null || v.FechaVenta <= fechaHasta)
							&& (importeDesde == null || importeTotal >= importeDesde)
							&& (importeHasta == null || importeTotal <= importeHasta)
						select new ProductoExtendido
						{
							NombreProducto = p.Descripcion,
							NombreTipoProducto = t.Descripcion,
							Cantidad = v.Cantidad,
							Importe = importeTotal
						};

			var query2 = from q in query.ToList()

						 group q by new { q.NombreProducto, q.NombreTipoProducto } into a

						 select new ProductoExtendido
						 {
							 NombreProducto = a.Key.NombreProducto,
							 NombreTipoProducto = a.Key.NombreTipoProducto,
							 Cantidad = a.Sum(v => v.Cantidad),
							 Importe = a.Sum(v => v.Importe)
						 };

			result.ElementosPorPagina = elementosPorPagina;
			result.Pagina = pagina;
			result.Total = query2.Count();
			int skip = (pagina - 1) * elementosPorPagina;
		
			return result;
		}

		public ProductoExtendidoPaginado GetVentas2(string? filtroProducto = null, string? filtroTipo = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, double? importeDesde = null, double? importeHasta = null, int pagina = 1, int elementosPorPagina = 50)
		{
			ProductoExtendidoPaginado resultado = new ProductoExtendidoPaginado();

			//DE ESTA FORMA LO HACEMOS TODO EN UNA QUERY

			var query = from v in ventas
						//Se aplica el filtro de fecha antes de agrupar, 
						//Ya que si primero agrupas por productoId, se pierde el campo fechaVenta, ya que ha dos productoId iguales con distinta fecha

						where (fechaDesde == null || v.FechaVenta >= fechaDesde)

						&& (fechaHasta == null || v.FechaVenta <= fechaHasta)

						group v by v.ProductoId into a

						//Uno ventas con productos por su productoId y el id del producto

						join p in productos on a.Key equals p.Id

						join t in tipoProductos on p.TipoProductoId equals t.Id

						//Sumo las cantidades agrupadas por productoId de ventas * precioUnitario de productos

						let importeTotal = a.Sum(v => v.Cantidad) * p.PrecioUnitario

						where (string.IsNullOrEmpty(filtroProducto) || p.Descripcion == filtroProducto)

						&& (string.IsNullOrEmpty(filtroTipo) || t.Descripcion == filtroTipo)

						&& (importeDesde == null || importeTotal >= importeDesde)

						&& (importeHasta == null || importeTotal <= importeHasta)

						select new ProductoExtendido
						{
							NombreProducto = p.Descripcion,
							NombreTipoProducto = t.Descripcion,
							Cantidad = a.Sum(v => v.Cantidad),
							Importe = importeTotal
						};

			int skip = (pagina - 1) * elementosPorPagina;
			resultado.Pagina = pagina;
			resultado.ElementosPorPagina = elementosPorPagina;
			resultado.Total = query.Count();
			resultado.Productos = query.Skip(skip).Take(elementosPorPagina).ToList();

			return resultado;
		}
	}
}
