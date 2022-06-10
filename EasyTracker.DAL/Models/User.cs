using EasyTracker.DAL.Enums;
using Microsoft.AspNetCore.Identity;

namespace EasyTracker.DAL.Models
{
    public class User : IdentityUser
    {
        public decimal Amount { get; set; }

        public List<Salary> Salaries { get; set; }

        public List<Saving> Savings { get; set; }

        public List<CurrencyBalance> CurrencyBalances { get; set; }

        public List<CurrencyRate> CurrencyRates { get; set; }

        public CurrencyCode MainCurrency { get; set; } = CurrencyCode.USD;

        public List<SpendingCategory> SpendingCategories { get; set; }
    }
}
