using MyShop.Web.Api.Brokers.DateTimes;
using MyShop.Web.Api.Brokers.Loggings;
using MyShop.Web.Api.Brokers.Storages;
using MyShop.Web.Api.Models.Products;
using MyShop.Web.Api.Models.Stocks;

namespace MyShop.Web.Api.Services.Foundation.Products
{
    public class StockService : IStockService
    {
        private readonly IStorageBroker _storageBroker;
        private readonly ILoggingBroker _loggingBroker;
        private readonly IDateTimeBroker _dateTimeBroker;
        public StockService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            _storageBroker = storageBroker;
            _loggingBroker = loggingBroker;
            _dateTimeBroker = dateTimeBroker;
        }
        public async Task<Stock> AddProductStockAsync(Stock stock)
        {
            this._loggingBroker.LogInformation($"{stock.Id} added");
            stock.Id = Guid.NewGuid();
            stock.Created = _dateTimeBroker.GetCurrentDateTime();
            stock.CreatedBy = Guid.NewGuid();
            return await _storageBroker.InsertProductStockAsync(stock);
        }

        public async ValueTask<Stock> ModifyProductStockAsync(Stock stock)
        {
            this._loggingBroker.LogInformation($"{stock.Id} modified");
            stock.Updated = _dateTimeBroker.GetCurrentDateTime();
            stock.UpdatedBy = Guid.NewGuid();
            return await _storageBroker.UpdateProductStockAsync(stock);
        }

        public async ValueTask<Stock> RemoveProductStockAsync(Stock stock)
        {
            this._loggingBroker.LogInformation($"{stock.Id} removed");
            return await _storageBroker.DeleteProductStockAsync(stock);
        }

        public IQueryable<Stock> RetrieveAllProductsStock()
        {
            this._loggingBroker.LogInformation("all stocks retrieved");
            return _storageBroker.SelectAllProductStocks();
        }
        public async ValueTask<Stock> RetrieveProductStockByIdAsync(Guid stockId)
        {
            this._loggingBroker.LogInformation($"Stock : {stockId} retrieved");
            return await _storageBroker.SelectProductStockByIdAsync(stockId);
        }
    }
}
