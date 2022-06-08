using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models
{
    public class UserMainCurrencyResponseModel : ResponseModelBase
    {
        public CurrencyCode MainCurrency { get; set; }
    }
}
