// See https://aka.ms/new-console-template for more information
using Linq.Clases;
using Linq.Interfaces;


void Linq1()
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

IServicioCargaDatos servicio = new ServicioCargaDatos();

List<ClaseAnimal> listaClaseAnimales = servicio.CargarClasesAnimales();
List<Gato> listaGatos = servicio.CargarGatos();

//------------Listado de todos los gatos

var queryGatos = from g in listaGatos
                 select new ResultadoGato
                 {
                     Color = g.Color,
                     Edad = g.Edad
                 };

List<ResultadoGato> resultadoGatos = queryGatos.ToList();
Console.WriteLine("\nTodos los gatos\n");
imprimirGatos(resultadoGatos);

//------------Listado de gatos que tienen 2 años

var queryGatos2 = from g in listaGatos
                  where g.Edad == 2
                  select new ResultadoGato
                  {
                      Color = g.Color,
                      Edad = g.Edad
                  };
List<ResultadoGato> resutadoGatosEdad2 = queryGatos2.ToList();
Console.WriteLine("\nGatos con edad 2\n");
imprimirGatos(resutadoGatosEdad2);

//------------Gato mas viejo

var queryGatoViejo = from g in listaGatos
                     orderby g.Edad descending
                     select new ResultadoGato
                     {
                         Color = g.Color,
                         Edad = g.Edad
                     };

ResultadoGato resultadoGatoViejo = queryGatoViejo.First();
imprimirGatos(new List<ResultadoGato> { resultadoGatoViejo });

//------------Agrupacion gattos con 2 años

var queryGatosAgrupada = from g in listaGatos
                         group g by g.Edad into g
                         where g.Key ==2
                         select g;

List<ResultadoGato> resultadoGatosAgrupados = new List<ResultadoGato>();

foreach(var group in queryGatosAgrupada)
{
    foreach(var item in group)
    {
        resultadoGatosAgrupados.Add(new ResultadoGato
        {
            Color = item.Color,
            Edad = item.Edad
        });
    }
}

imprimirGatos(resultadoGatosAgrupados);

//------------Query con Join

var queryJoin = from g in listaGatos
                join c in listaClaseAnimales on g.TipoAnimal equals c.Id
                select new ResultadoGato
                {
                    Color = g.Color,
                    Edad = g.Edad,
                    TipoAnimal = c.Descripcion
                };

List<ResultadoGato> resultadoGatosJoin = queryJoin.ToList();
imprimirGatos(resultadoGatosJoin);


void imprimirGatos(List<ResultadoGato> listaGatos)
{
    foreach(ResultadoGato g in listaGatos)
    {
        Console.WriteLine($"El gato de color {g.Color} tiene {g.Edad} años, tipoAnimal: {g.TipoAnimal}");
    }
    Console.WriteLine("\n-----------------------------------\n");
}

	
