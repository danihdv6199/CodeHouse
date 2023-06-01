using Bootcamp.Application.Contracts.Servicies;
using Bootcamp.Application.Mappers;
using Bootcamp.BusinessModels.Models;
using Bootcamp.DataAccess.Contracts;
using Bootcamp.DataAccess.Contracts.Models;
using Bootcamp.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Application.Servicies
{
    //TODA LOGICA DE NEGOCIO EN EL SERVICIO
    public class ProductService: IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        public ProductService( IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductResponse? GetProductByCode(string code)
        {
            ProductDto? product = _productRepository.GetProductByCode(code);

            if (product != null)
            {
                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(product);
                return result;
            }
            else return null;
        }

        public bool DeleteProduct(string productCode)
        {
            ProductDto? product = _productRepository.GetProductByCode(productCode);

            if(product != null)
            {
                _productRepository.DeleteProduct(product);
                _unitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }   

        public ProductResponse? AddProduct(CreateProductRequest request)
        {
            //if (string.IsNullOrEmpty(request.Code) || request.Code.Length > 15 )
            //    return new ProductResponse { Error = "El campo Code no esta informado o excede su longitud"};

            ProductDto? product = _productRepository.GetProductByCode(request.Code);
            if (product == null)
            {
                ProductDto productToInsert = ProductMapper.MapToProductDtoFromCreateProductRequest(request);
                
                ProductDto productInserted = _productRepository.AddProduct(productToInsert);
                _unitOfWork.Commit();

                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productInserted);

                return result;
            }
            else return null;

        }


        public ProductResponse? UpdateProduct(string code, UpdateProductRequest request)
        {

            ProductDto? existingProduct = _productRepository.GetProductByCode(code);
            if (existingProduct != null)
            {
                existingProduct.ProductVendor = request.Vendor;
                existingProduct.ProductLine = request.Line;
                existingProduct.BuyPrice = request.BuyPrice;
                existingProduct.ProductDescription = request.Description;
                existingProduct.ProductScale = request.Scale;
                existingProduct.ProductName = request.Name;
                existingProduct.QuantityInStock = request.Stock;

                ProductDto productUpdated = _productRepository.UpdateProduct(existingProduct);
                _unitOfWork.Commit();

                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productUpdated);
                return result;
            }
            else return null;

        }

    }
}
