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
        PaginatedDto<ProductDto> GetProductPaginated(string description = null, int page = 1, int itemsPerPage = 5);
        void DeleteProduct(ProductDto productDto);
        ProductDto AddProduct(ProductDto product);
        ProductDto? UpdateProduct(ProductDto product);
    }
}
