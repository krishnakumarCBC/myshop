using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Api.Models.Products;
using MyShop.Web.Api.Services.Foundation.Products;

namespace MyShop.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            _productService.RetrieveAllProducts().ToList();
            return Ok();
        }

        [HttpGet("{id}", Name = "GetSingleProduct")]
        public async ValueTask<IActionResult> GetProductAsync(Guid id)
        {
            var product = await _productService.RetrieveProductByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostProduct([FromBody]Product product)
        {
            var newproduct = await _productService.AddProductAsync(product);
            return Created("GetSingleProduct",newproduct);
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutProducts([FromBody]Product product)
        {
            var currenProduct = await _productService.RetrieveProductByIdAsync(product.Id);
            if(currenProduct is null)
            {
                return NotFound();
            }
            var updatedProduct = await _productService.ModifyProductAsync(product);
            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProducts(Guid id)
        {
            var currenProduct = await _productService.RetrieveProductByIdAsync(id);
            if (currenProduct is null)
            {
                return NotFound();
            }
            var deleteProduct = await _productService.RemoveProductAsync(currenProduct);
            return Ok(deleteProduct);
        }
    }
}
