using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_EjercicioLinqVentas.Entidades
{
    public class Producto
    {

        public int Id { get; set; }
        public int TipoProductoId { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }

    }
}
