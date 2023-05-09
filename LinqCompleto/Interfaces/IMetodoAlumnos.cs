using LinqCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Interfaces
{
	public interface IMetodoAlumnos
	{
		AlumnoExtendidoPaginado GetAlumnosJoin(DateTime? fechaDesde = null, DateTime? fechaHasta = null, double? notaMedia = 0.0, string? filtroNombre = null, int pagina = 1, int elementosPorPagina = 1);
	}
}
