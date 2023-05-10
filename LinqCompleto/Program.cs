
using LinqCompleto.Clases;
using LinqCompleto.Entidades;
using LinqCompleto.Interfaces;

IMetodoAlumnos metodosAlumnos = new MetodosAlumnos();

Console.WriteLine("------------Alumnos filtrados por nota media--------------");
AlumnoExtendidoPaginado resultadoNotaMedia = metodosAlumnos.GetAlumnosJoin(notaMedia:5.0, pagina:1, elementosPorPagina:20);
foreach(AlumnoExtendido a in resultadoNotaMedia.Resultados)
{
	Console.WriteLine($"El alumno {a.NombreAlumnno} tiene una nota media de {a.NotaMediaAlumno}");
}

Console.WriteLine("------------Alumnos que empiecen por R y paginados--------------");
AlumnoExtendidoPaginado resultadoPorNombre = metodosAlumnos.GetAlumnosJoin(filtroNombre: "R", pagina: 1, elementosPorPagina: 200);
foreach (AlumnoExtendido a in resultadoPorNombre.Resultados)
{
    Console.WriteLine($"El alumno {a.NombreAlumnno} empieza por R esta en la pagina {resultadoPorNombre.Pagina}");
}

Console.WriteLine("------------Profesores filtrados por poblaicon y paginados--------------");
IMetodosProfesor metodosProfesor = new MetodosProfesor();
ProfesorExtendidoPaginado resultadoProfesores = metodosProfesor.GetProfesores(filtroPoblacion: "Madrid", pagina:1, elementosPorPagina:2);
foreach(ProfesorExtendido p in resultadoProfesores.Resultados)
{
    Console.WriteLine($"El profesr {p.NombreProfesor} vive en  {p.NombreProblacion}");

}