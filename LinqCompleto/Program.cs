
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
