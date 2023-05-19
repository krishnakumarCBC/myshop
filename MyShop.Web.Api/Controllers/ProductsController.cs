using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Web.Api.Models.Products;
using MyShop.Web.Api.Models.Stocks;
using MyShop.Web.Api.Services.Foundation.Products;

namespace MyShop.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IStockService _stockService;

        public ProductsController(IProductService productService, IStockService stockService)
        {
            _productService = productService;
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            _productService.RetrieveAllProducts().ToList();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            _stockService.RetrieveAllProductsStock().ToList();
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

        [HttpGet("{id}", Name = "GetSingleProductStock")]
        public async ValueTask<IActionResult> GetProductStock(Guid id)
        {
            var productStock = await _stockService.RetrieveProductStockByIdAsync(id);
            var product = ("GetSingleProduct", productStock.ProductId);
            return Ok(product.ToString() + productStock.ToString());
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostProduct([FromBody]Product product)
        {
            var newproduct = await _productService.AddProductAsync(product);
            return Created("GetSingleProduct",newproduct);
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostProductStock([FromBody] Stock stock)
        {
            var newproduct = await _stockService.AddProductStockAsync(stock);
            return Created("GetSingleProductStock", newproduct);
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

        [HttpPut]
        public async ValueTask<IActionResult> PutProductsStock([FromBody] Stock stock)
        {
            var currenProduct = await _stockService.RetrieveProductStockByIdAsync(stock.Id);
            if (currenProduct is null)
            {
                return NotFound();
            }
            var updatedProduct = await _stockService.ModifyProductStockAsync(stock);
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

        [HttpDelete(Name = "DeleteProductStock")]
        public async ValueTask<IActionResult> DeleteProductsStock(Guid id)
        {
            var currenProduct = await _stockService.RetrieveProductStockByIdAsync(id);
            if (currenProduct is null)
            {
                return NotFound();
            }
            var deleteProduct = await _stockService.RemoveProductStockAsync(currenProduct);
            return Ok(deleteProduct);
        }
    }
}
