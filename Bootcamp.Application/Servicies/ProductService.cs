using Bootcamp.Application.Contracts.Servicies;
using Bootcamp.BusinessModels.Models;
using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Application.Servicies
{
    public class ProductService: IProductService
    {
        private IProductRepository _productRepository;
        public ProductService( IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductResponse? GetProductByCode(string code)
        {
            ProductDto? product = _productRepository.GetProductByCode(code);

            if (product != null)
            {
                return new ProductResponse
                {
                    Code = product.ProductCode,
                    Description = product.ProductDescription,
                    Price = product.BuyPrice,
                    Stock = product.QuantityInStock
                };
            }
            else return null;
        }

    }
}
