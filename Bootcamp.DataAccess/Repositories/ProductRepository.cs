using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Contracts.Repositories;
using Bootcamp.DataAccess.Entities;
using Bootcamp.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductDto? GetProductByCode(string productCode)
        {
            var query = from p in _context.Products
                        where p.ProductCode == productCode
                        select ProductMapper.MaptToProductDtoFromProduct(p);
            return query.FirstOrDefault();
        }

        public void DeleteProduct(ProductDto productDto)
        {
       
              _context.Products.Remove(ProductMapper.MaptToProductFromProductDto(productDto));
            
        }

        public ProductDto AddProduct(ProductDto product)
        {

            Product newProduct = ProductMapper.MaptToProductFromProductDto(product);

            var productInserted = _context.Products.Add(newProduct);

            ProductDto result = new ProductDto
            {
                ProductCode = productInserted.Entity.ProductCode,
                BuyPrice = productInserted.Entity.BuyPrice,
                Msrp = productInserted.Entity.Msrp,
                ProductDescription = productInserted.Entity.ProductDescription,
                ProductLine = productInserted.Entity.ProductLine,
                ProductName = productInserted.Entity.ProductName,
                ProductScale = productInserted.Entity.ProductScale,
                ProductVendor = productInserted.Entity.ProductVendor,
                QuantityInStock = productInserted.Entity.QuantityInStock
            };

            return result;
        }

        public ProductDto? UpdateProduct(ProductDto product)
        {


            Product productToUpdate = ProductMapper.MaptToProductFromProductDto(product);

            var productUpdated = _context.Products.Update(productToUpdate);

                ProductDto result = new ProductDto
                {
                    ProductCode = productUpdated.Entity.ProductCode,
                    BuyPrice = productUpdated.Entity.BuyPrice,
                    Msrp = productUpdated.Entity.Msrp,
                    ProductDescription = productUpdated.Entity.ProductDescription,
                    ProductLine = productUpdated.Entity.ProductLine,
                    ProductName = productUpdated.Entity.ProductName,
                    ProductScale = productUpdated.Entity.ProductScale,
                    ProductVendor = productUpdated.Entity.ProductVendor,
                    QuantityInStock = productUpdated.Entity.QuantityInStock
                };
            return result;
        }
      
    }
   
}

