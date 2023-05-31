using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Mappers
{
    public static class ProductMapper
    {
        public static Product MaptToProductFromProductDto(ProductDto product)
        {
            return new Product
            {
                ProductCode = product.ProductCode,
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock
            };
        }
        public static ProductDto MaptToProductDtoFromProduct(Product product)
        {
            return new ProductDto
            {
                ProductCode = product.ProductCode,
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock
            };
        }
    }
}
