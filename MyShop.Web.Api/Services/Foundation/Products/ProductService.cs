using MyShop.Web.Api.Brokers.DateTimes;
using MyShop.Web.Api.Brokers.Loggings;
using MyShop.Web.Api.Brokers.Storages;
using MyShop.Web.Api.Models.Products;

namespace MyShop.Web.Api.Services.Foundation.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker _storageBroker;
        private readonly ILoggingBroker _loggingBroker;
        private readonly IDateTimeBroker _dateTimeBroker;
        public ProductService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            _storageBroker = storageBroker;
            _loggingBroker = loggingBroker;
            _dateTimeBroker = dateTimeBroker;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            this._loggingBroker.LogInformation($"{product.Title} added");
            product.Id = Guid.NewGuid();
            product.Created = _dateTimeBroker.GetCurrentDateTime();
            product.CreatedBy = Guid.NewGuid();
            return await _storageBroker.InsertProductAsync(product);
        }

        public async ValueTask<Product> ModifyProductAsync(Product product)
        {
            this._loggingBroker.LogInformation($"{product.Title} modified");
            product.Updated = _dateTimeBroker.GetCurrentDateTime();
            product.UpdatedBy = Guid.NewGuid();
            return await _storageBroker.UpdateProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Product product)
        {
            this._loggingBroker.LogInformation($"{product.Title} removed");
            return await _storageBroker.DeleteProductAsync(product);
        }

        public  IQueryable<Product> RetrieveAllProducts()
        {
            this._loggingBroker.LogInformation("all products retrieved");
            return _storageBroker.SelectAllProducts();
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid productId)
        {
            this._loggingBroker.LogInformation($"Product : {productId} retrieved");
            return await _storageBroker.SelectProductByIdAsync(productId);
        }
    }
}
