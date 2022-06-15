using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface IBaseCurrencyRateRepository
	{
		Task<List<BaseCurrencyRate>> GetRateFromCurrencyAsync(CurrencyCode currency);
		Task<List<BaseCurrencyRate>> GetRateToCurrencyAsync(CurrencyCode currency);
		Task<BaseCurrencyRate> GetRateAsync(CurrencyCode fromCurrency, CurrencyCode toCurrency);
		Task<List<BaseCurrencyRate>> GetAllRatesAsync();
	}
}
