using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Interfaces;

public interface ICurrencyService
{
    Task<BaseCurrencyRate> GetCurrencyRateAsync(
        string userId,
        CurrencyCode fromCurrency,
        CurrencyCode toCurrency);
    Task<List<BaseCurrencyRate>> GetAllCurrencyRatesAsync(string userId);
    Task<List<BaseCurrencyRate>> GetAllRatesFromCurrencyAsync(string userId, CurrencyCode currency);
    Task<List<BaseCurrencyRate>> GetAllRatesToCurrencyAsync(string userId, CurrencyCode currency);
}
