using Bootcamp.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Contracts.Repositories
{
    public interface IProductRepository
    {
        ProductDto? GetProductByCode(string productCode);
    }
}
