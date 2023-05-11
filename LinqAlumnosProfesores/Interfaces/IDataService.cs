using LinqAlumnosProfesores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAlumnosProfesores.Interfaces
{
	public interface IDataService
	{
		List<EstudianteExtendido> estudiantesFiltradosNota9();
		List<EstudianteExtendido> estudianteExtendidos2(string? pais = null);

    }
}
