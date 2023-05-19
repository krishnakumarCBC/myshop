using MyShop.Web.Api.Brokers.DateTimes;
using MyShop.Web.Api.Brokers.Loggings;
using MyShop.Web.Api.Brokers.Storages;
using MyShop.Web.Api.Services.Foundation.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



ServiceBrokers(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ServiceBrokers(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddDbContext<StorageBroker>();
    builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
    builder.Services.AddTransient<IProductService, ProductService>();
    builder.Services.AddTransient<IStockService, StockService>();
}