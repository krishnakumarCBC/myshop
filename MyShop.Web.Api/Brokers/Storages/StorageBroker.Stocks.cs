using Microsoft.EntityFrameworkCore;
using MyShop.Web.Api.Models.Stocks;

namespace MyShop.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Stock> Stocks { get; set; }
        public async Task<Stock> InsertProductStockAsync(Stock stock)
        {
            this.Entry(stock).State = EntityState.Added;
            await this.SaveChangesAsync();
            return stock;
        }
        public IQueryable<Stock> SelectAllProductStocks()
        {
            return this.Stocks.AsQueryable();
        }
        public async ValueTask<Stock> SelectProductStockByIdAsync(Guid stockId)
        {
            return await this.Stocks.FindAsync(stockId);
        }

        public async ValueTask<Stock> UpdateProductStockAsync(Stock stock)
        {
            this.Entry(stock).State = EntityState.Modified;
            await this.SaveChangesAsync();
            return stock;
        }
        public async ValueTask<Stock> DeleteProductStockAsync(Stock stock)
        {
            this.Entry(stock).State = EntityState.Deleted;
            await this.SaveChangesAsync();
            return stock;
        }
    }
}
