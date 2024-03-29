﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.BusinessModels.Models.Product
{
    public class CreateProductRequest //Accion nombre peticion
    {
        [Required]
        [MaxLength(15, ErrorMessage = "El campo code no puede tener una long mayor 15")]
        public string Code { get; set; } = null!;
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
