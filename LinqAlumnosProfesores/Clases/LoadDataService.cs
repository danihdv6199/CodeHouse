using LinqAlumnosProfesores.Entidades;
using LinqAlumnosProfesores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAlumnosProfesores.Clases
{
	public class LoadDataService : ILoadDataService
	{
		public List<Alumno> LoadAlumnos()
		{
			return new List<Alumno>
			{
				new Alumno
				{
					Nombre = "Ismael",
					Apellidos = "De la poza",
					Edad = 32,
					Clase =".Net"
				},
				new Alumno
				{
					Nombre = "Juan",
					Apellidos = "Martinez",
					Edad = 33,
					Clase =".Net"
				},
				new Alumno
				{
					Nombre = "Raul",
					Apellidos = "Val Peral",
					Edad = 18,
					Clase ="Javascript"
				},
			};
		}

		public List<Profesor> LoadProfesor()
		{
			return new List<Profesor>
			{
				new Profesor
				{
					Nombre = "Pedro",
					Apellidos = "Sanchez",
					Edad = 39,
					Asignatura = ".Net"
					
				},
				new Profesor
				{
					Nombre = "Ivan",
					Apellidos = "Luengo",
					Edad = 36,
					Asignatura = "Javascript"

				},
			};
		}
	}
}
