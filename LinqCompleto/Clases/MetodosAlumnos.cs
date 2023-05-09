using LinqCompleto.Entidades;
using LinqCompleto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Clases
{
	public class MetodosAlumnos: IMetodoAlumnos
	{
		private List<Alumno> ListaAlumnos { get; set; }
		private List<Clase> ListaClases { get; set; }
		private List<Poblacion> ListaPoblaciones { get; set; }
		public MetodosAlumnos()
		{
			ILoadDataService dataService = new LoadDataService();
			ListaAlumnos = dataService.GetAlumnos();
			ListaClases = dataService.GetClases();
			ListaPoblaciones = dataService.GetPoblaciones();
		}
		public AlumnoExtendidoPaginado GetAlumnosJoin(DateTime? fechaDesde = null, DateTime? fechaHasta = null, double? notaMedia = 0.0, string? filtroNombre = null, int pagina = 1, int elementosPorPagina = 1)
		{
			AlumnoExtendidoPaginado resultado = new AlumnoExtendidoPaginado();

			var query = from a in ListaAlumnos
						// resultados temporales en una variable
						let notaMediaLinq = a.Notas.Average()
						join c in ListaClases on a.Clase equals c.Numero
						join p in ListaPoblaciones on a.PoblacionId equals p.Id
						//Primero valida si filtronombre es nulo, si se cumple no valida lo segundo, si no se cumple lo primero valida lo segundo y asi sucesivamente 
						where(string.IsNullOrEmpty(filtroNombre) || a.Nombre.StartsWith(filtroNombre))
							&& (notaMedia == null || notaMediaLinq >= notaMedia)
							&& (fechaDesde == null || a.FechaDeNacimiento >= fechaDesde)
							&& (fechaHasta == null || a.FechaDeNacimiento <=fechaHasta)
						select new AlumnoExtendido
						{
							NombreAlumnno = a.Nombre,
							FechaDeNacimientoAlumno = a.FechaDeNacimiento,
							NombreClase = c.Nombre,
							NombrePoblacion = p.Nombre,
							NotaMediaAlumno = notaMediaLinq
						};

			resultado.Total = query.Count();
			resultado.Pagina = pagina;
			int skip = (pagina - 1) * elementosPorPagina;
			resultado.ElementosPorPagina = elementosPorPagina;
			resultado.Resultados = query.Skip(skip).Take(elementosPorPagina).ToList();

			return resultado;
		}
	}
}
