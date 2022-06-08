using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
    public interface IBaseCurrencyRateRepository
    {
        Task<BaseCurrencyRate> GetAsync(CurrencyCode fromCurrency, CurrencyCode toCurrency);
    }
}
