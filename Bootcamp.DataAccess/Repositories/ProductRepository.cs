using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Contracts.Repositories;
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
    }
}
