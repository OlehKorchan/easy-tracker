using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
    public interface ICurrencyRateRepository
    {
        Task<CurrencyRate> GetAsync(
            string userId,
            CurrencyCode fromCurrency,
            CurrencyCode toCurrency
        );
    }
}
