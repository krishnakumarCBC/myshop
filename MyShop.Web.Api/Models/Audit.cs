namespace MyShop.Web.Api.Models
{
    public class Audit
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
