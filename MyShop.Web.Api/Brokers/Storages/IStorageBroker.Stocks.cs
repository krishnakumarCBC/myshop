using MyShop.Web.Api.Models.Stocks;

namespace MyShop.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<Stock> InsertProductStockAsync(Stock stok);
        IQueryable<Stock> SelectAllProductStocks();
        ValueTask<Stock> SelectProductStockByIdAsync(Guid stockId);
        ValueTask<Stock> UpdateProductStockAsync(Stock stock);
        ValueTask<Stock> DeleteProductStockAsync(Stock stock);
    }
}
