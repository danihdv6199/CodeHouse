using Bootcamp.Application.Contracts.Servicies;
using Bootcamp.BusinessModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
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


        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType( StatusCodes.Status500InternalServerError)]
        //IActionResult, es el tipo de objeto que devuelve un endopoint de un controlador
        public IActionResult GetProductByCode(string code)
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
    }
}
