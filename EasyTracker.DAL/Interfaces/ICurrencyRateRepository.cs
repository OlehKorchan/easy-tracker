using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces;

public interface ICurrencyRateRepository
{
    Task<List<CurrencyRate>> GetRatesFromCurrencyAsync(string userId, CurrencyCode currency);
    Task<List<CurrencyRate>> GetRatesToCurrencyAsync(string userId, CurrencyCode currency);
    Task<List<CurrencyRate>> GetAllUserRatesAsync(string userId);
    Task<CurrencyRate> GetUserRateAsync(
        string userId,
        CurrencyCode fromCurrency,
        CurrencyCode toCurrency
    );
}
