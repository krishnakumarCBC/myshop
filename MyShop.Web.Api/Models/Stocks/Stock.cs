namespace MyShop.Web.Api.Models.Stocks
{
    public class Stock : Audit
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int CurrentStock { get; set; }
    }
}
