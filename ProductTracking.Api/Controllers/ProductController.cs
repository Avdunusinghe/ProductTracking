using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Business;
using ProductTracking.DTO;

namespace ProductTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductDTO model)
        {
            var response = await _productService.SaveProduct(model);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProducts();

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var response = await _productService.DeleteProduct(id);

            return Ok(response);
        }

        [HttpGet("getProductById/{id:int}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            var response = await _productService.GetProductById(id);

            return Ok(response);
        }


    }
}
