using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Interfaces;

public interface ICurrencyService
{
    Task<BaseCurrencyRate> GetCurrencyRateAsync(
        CurrencyCode fromCurrency,
        CurrencyCode toCurrency);

    Task<List<BaseCurrencyRate>> GetAllRatesToCurrencyAsync(string userId, CurrencyCode currency);
}
