using Bootcamp.Application.Contracts.Servicies;
using Bootcamp.BusinessModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Bootcamp.API.Controllers
{
    //QueryString
    //api/products (No tiene en cuenta mayus o minus)
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //api/productos/{code}
        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType( StatusCodes.Status500InternalServerError)]
        //IActionResult, es el tipo de objeto que devuelve un endopoint de un controlador
        public IActionResult GetProductByCode([Required] string code)
        {
            ProductResponse? product = _productService.GetProductByCode(code);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        //api/productos/{code}
        [HttpDelete]
        [Route("{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct([Required] string code)
        {
            bool result = _productService.DeleteProduct(code);
            if (result)
                return NoContent();
            else
                return NotFound("El producto no existe");
        }

        //api/productos
        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //Transforma el json en un CreateProductRequest automaticamente
        public IActionResult AddProduct(CreateProductRequest request)
        {
            ProductResponse? product = _productService.AddProduct(request);
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Error))
                    return Ok(product);
                else
                    return BadRequest(product.Error);
            }
            else
            {
                return Conflict("El producto ya existe");
            }
        }

        //api/productos/{code}       
        [HttpPut]
        [Route("{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //Transforma el json en un CreateProductRequest automaticamente
        public IActionResult AddProduct([Required (ErrorMessage ="Codigo obligatorio")][MaxLength(15)]string code, UpdateProductRequest request)
        {
            ProductResponse? product = _productService.UpdateProduct(code, request);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound("El producto no existe");
            }
        }
    }
}
