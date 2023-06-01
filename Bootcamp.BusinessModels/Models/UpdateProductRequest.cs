using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.BusinessModels.Models
{
    public class UpdateProductRequest
    {
        [Required]

        public string Name { get; set; } = null!;
        [Required]

        public string Line { get; set; } = null!;
        [Required]

        public string Scale { get; set; } = null!;

        [Required]
        public string Vendor { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        [Required]

        public short Stock { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal Price { get; set; }
    }
}
