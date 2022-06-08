using EasyTracker.DAL.Enums;

namespace EasyTracker.DAL.Models
{
    public class CurrencyRate : BaseCurrencyRate
    {
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
