
using LinqAlumnosProfesores.Clases;
using LinqAlumnosProfesores.Entidades;
using LinqAlumnosProfesores.Interfaces;

IDataService dataService = new DataService();


List<EstudianteExtendido>  estudiantesFiltradosNota9 = dataService.estudiantesFiltradosNota9();
foreach(EstudianteExtendido e in estudiantesFiltradosNota9)
{
	Console.WriteLine($"Estudiante {e.Nombre}");
}

List<EstudianteExtendido> estudianteExtendido2 = dataService.estudianteExtendidos2();
foreach (EstudianteExtendido e in estudianteExtendido2)
{
    Console.WriteLine($"Estudiante {e.Nombre} y pais {e.Pais}");
}

