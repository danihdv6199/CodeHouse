using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCompleto.Entidades
{
	public class Profesor
	{
		public string Nombre { get; set; }
		public int Clase { get; set; }
		public int PoblacionId { get; set; }
		public DateTime FechaDeNacimiento { get; set; }

	}
}
