using Microsoft.EntityFrameworkCore;
using MyShop.Web.Api.Models.Stocks;

namespace MyShop.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : DbContext,IStorageBroker
    {
        private readonly IConfiguration _configuration;
        public StorageBroker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
}
