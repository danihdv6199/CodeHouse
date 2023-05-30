using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Contracts.Repositories;
using Bootcamp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository 
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductDto? GetProductByCode (string productCode)
        {
            var query = from p in _context.Products
                        where p.ProductCode == productCode
                        select new ProductDto
                        {
                            ProductCode = p.ProductCode,
                            BuyPrice = p.BuyPrice,
                            Msrp = p.Msrp,
                            ProductDescription = p.ProductDescription,
                            ProductLine = p.ProductLine,
                            ProductName = p.ProductName,
                            ProductScale = p.ProductScale,
                            ProductVendor = p.ProductVendor,
                            QuantityInStock = p.QuantityInStock
                        };
            return query.FirstOrDefault();
        }

        public void DeleteProduct(string productCode)
        {
            Product? product = _context.Products.Where(p => p.ProductCode == productCode).FirstOrDefault();

            if(product != null)
            {
                _context.Products.Remove(product);
            }
        } 

        public ProductDto AddProduct(ProductDto product)
        {
            Product newProduct = new Product
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
            Product? productToUpdate = _context.Products.Where(p => p.ProductCode == product.ProductCode).FirstOrDefault();
            if (productToUpdate != null)
            {
                productToUpdate.BuyPrice = product.BuyPrice;
                productToUpdate.Msrp = product.Msrp;
                productToUpdate.ProductDescription = product.ProductDescription;
                productToUpdate.ProductLine = product.ProductLine;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.ProductScale = product.ProductScale;
                productToUpdate.ProductVendor = product.ProductVendor;
                productToUpdate.QuantityInStock = product.QuantityInStock;

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
            return null;        
        }
    }
}
