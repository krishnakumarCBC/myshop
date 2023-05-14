using Microsoft.EntityFrameworkCore;
using MyShop.Web.Api.Models.Products;

namespace MyShop.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> products { get; set; }
        public Task<Product> InsertProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Product> SelectAllProducts()
        {
            throw new NotImplementedException();
        }
        public ValueTask<Product> SelectProductByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
        public ValueTask<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
        public ValueTask<Product> DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
