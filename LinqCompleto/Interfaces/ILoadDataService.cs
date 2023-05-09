using LinqCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Interfaces
{
	public interface ILoadDataService
	{
		List<Alumno> GetAlumnos();
		List<Clase> GetClases();
		List<Poblacion> GetPoblaciones();
		List<Profesor> GetProfesores();

	}
}
