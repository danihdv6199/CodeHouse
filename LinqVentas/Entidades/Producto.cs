using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_EjercicioLinqVentas.Entidades
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TipoProductoId { get; set; }
        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }
        [Required]

        public double PrecioUnitario { get; set; }

    }
}
