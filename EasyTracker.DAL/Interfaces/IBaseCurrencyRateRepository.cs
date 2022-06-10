using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
    public interface IBaseCurrencyRateRepository
    {
        Task<List<BaseCurrencyRate>> GetAsync(CurrencyCode currency);
        Task<BaseCurrencyRate> GetAsync(CurrencyCode fromCurrency, CurrencyCode toCurrency);
        Task<List<BaseCurrencyRate>> GetAsync();
    }
}
