using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Entidades
{
	public class Alumno
	{
		public string Nombre { get; set; }
		public int PoblacionId { get; set; }
		public DateTime FechaDeNacimiento { get; set; }
		public List<int> Notas { get; set; } 
		public int Clase { get; set; }
	}
}
