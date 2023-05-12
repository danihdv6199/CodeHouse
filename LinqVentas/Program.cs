using LinqVentas.Clases;
using LinqVentas.Interfaces;
using LinqVentas.Modelo;

IDataService dataService = new DataService();

ProductoExtendidoPaginado resultado = dataService.GetVentas(fechaDesde: new DateTime(2022, 4, 1), fechaHasta: new DateTime(2022, 9, 1));

foreach (ProductoExtendido pr in resultado.Productos)
{
    Console.WriteLine($"El producto {pr.NombreProducto} de tipo {pr.NombreTipoProducto} tiene una venta de {pr.Cantidad} unidades por un importe total de {pr.Importe}");
}