// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class Linq
{
	public void Linq1()
	{
		//1. Obtener el origen de datos
		int[] numeros = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

		//2. Crear la consulta
		var numQuery =
			from num in numeros
			where num > 2
			select num;

		//3. Ejecutar la consulta
		List<int> resultado = numQuery.ToList();
	}
}