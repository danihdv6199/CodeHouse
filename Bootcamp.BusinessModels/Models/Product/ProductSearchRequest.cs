using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.BusinessModels.Models.Product
{
    public class ProductSearchRequest: PaginatedBaseRequest
    {
        public string Description { get; set; }
    }
}
