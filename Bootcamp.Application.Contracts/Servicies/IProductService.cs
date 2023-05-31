using Bootcamp.BusinessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Application.Contracts.Servicies
{
    public interface IProductService
    {
        ProductResponse? GetProductByCode(string code);
        bool DeleteProduct(string productCode);

        ProductResponse? AddProduct(CreateProductRequest request);
        ProductResponse? UpdateProduct(string code, UpdateProductRequest request);
    }
}
