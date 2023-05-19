using MyShop.Web.Api.Models.Stocks;

namespace MyShop.Web.Api.Services.Foundation.Products
{
    public interface IStockService
    {
        Task<Stock> AddProductStockAsync(Stock stock);
        IQueryable<Stock> RetrieveAllProductsStock();
        ValueTask<Stock> RetrieveProductStockByIdAsync(Guid stockId);
        ValueTask<Stock> ModifyProductStockAsync(Stock stock);
        ValueTask<Stock> RemoveProductStockAsync(Stock stock);
    }
}
