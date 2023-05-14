namespace MyShop.Web.Api.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
       public DateTimeOffset GetCurrentDateTime() => DateTime.UtcNow;
    }
}
