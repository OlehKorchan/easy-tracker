using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models
{
    public class UserMainCurrencyResponse : ResponseModelBase
    {
        public CurrencyCode MainCurrency { get; set; }
    }
}
