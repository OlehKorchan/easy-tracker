using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface ICurrencyRateRepository
	{
		Task<List<CurrencyRate>> GetAsync(string userId, CurrencyCode currency);
		Task<List<CurrencyRate>> GetAsync(string userId);
		Task<CurrencyRate> GetAsync(
			string userId,
			CurrencyCode fromCurrency,
			CurrencyCode toCurrency
		);
	}
}
