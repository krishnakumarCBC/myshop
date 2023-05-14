namespace MyShop.Web.Api.Models
{
    public class Product : Audit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double UnitPrice { get; set; }
        public int OrderAfter { get; set; }
    }
}
