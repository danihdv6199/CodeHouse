using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_EjercicioLinqVentas.Entidades
{
    public class Venta
    {

        public int Id { get; set; }


        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaVenta { get; set; }

    }
}
