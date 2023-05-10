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
					Clase =".Net",
					PaisId = 1
				},
				new Alumno
				{
					Nombre = "Juan",
					Apellidos = "Martinez",
					Edad = 33,
					Clase =".Net",
					PaisId = 2
				},
				new Alumno
				{
					Nombre = "Raul",
					Apellidos = "Val Peral",
					Edad = 18,
					Clase ="Javascript",
					PaisId = 3
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
		public List<Pais> LoadPaises()
		{
			return new List<Pais>
			{
				new Pais
				{
					Id =1,
					Nombre = "España"
				},
                new Pais
                {
                    Id =2,
                    Nombre = "Francia"
                },
                new Pais
                {
                    Id =1,
                    Nombre = "Portugal"
                },
            };

		}
	}
}
