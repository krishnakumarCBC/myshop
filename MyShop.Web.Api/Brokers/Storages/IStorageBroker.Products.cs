using MyShop.Web.Api.Models.Products;

namespace MyShop.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<Product> InsertProductAsync(Product product);
        IQueryable<Product> SelectAllProducts();
        ValueTask<Product> SelectProductByIdAsync(Guid productId);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Product product);
    }
}
