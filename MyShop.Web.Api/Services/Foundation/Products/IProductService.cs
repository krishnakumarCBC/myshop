using MyShop.Web.Api.Models.Products;

namespace MyShop.Web.Api.Services.Foundation.Products
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid productId);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductAsync(Product product);
    }
}
