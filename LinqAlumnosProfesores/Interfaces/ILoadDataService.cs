using LinqAlumnosProfesores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAlumnosProfesores.Interfaces
{
	public interface ILoadDataService
	{
		List<Alumno> LoadAlumnos();
		List<Profesor> LoadProfesor();
		List<Pais> LoadPaises();
    }
}
