using LinqAlumnosProfesores.Entidades;
using LinqAlumnosProfesores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAlumnosProfesores.Clases
{
	public class DataService: IDataService
	{
		private List<Alumno> listaAlumnos = new List<Alumno>();
		private List<Profesor> listaProfesores = new List<Profesor>();
		private List<Pais> listaPais = new List<Pais>();

        public DataService()
		{
			ILoadDataService loadDataService = new LoadDataService();
			this.listaProfesores = loadDataService.LoadProfesor();
			this.listaAlumnos = loadDataService.LoadAlumnos();
		}

		public List<EstudianteExtendido> estudiantesFiltradosNota9()
		{

			var query = from a in listaAlumnos
						where a.Edad > 30 && a.Clase ==".Net"
						select new EstudianteExtendido
						{
							Nombre = a.Nombre,
							Apellidos = a.Apellidos,
							Clase = a.Clase,
							Edad = a.Edad,
							Nota = 9
						};

			return query.ToList();
		}
		//misma anterior añadiendo nombre pais
		public List<EstudianteExtendido> estudianteExtendidos2()
		{
			List<EstudianteExtendido> estudiantes = estudiantesFiltradosNota9();
			var query = from a in estudiantes
									//Desde donde quieres unir | Donde apunta
						join p in listaPais	    	on a.Pais equals p.Id
						select new EstudianteExtendido
						{
							Pais = p.Nombre,
							Nombre = a.Nombre,
							Apellidos = a.Apellidos,
							Clase = a.Clase,
							Edad = a.Edad,
							Nota = 9
						};
			return query.ToList();
		}
	}
}
