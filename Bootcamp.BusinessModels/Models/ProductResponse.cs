using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.BusinessModels.Models
{
    public class ProductResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public short Stock { get; set; }
        public decimal Price { get; set; }
    }
}
