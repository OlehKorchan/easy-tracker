using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface ICurrencyBalanceRepository
	{
		Task AddAsync(CurrencyBalance currencyBalance);
		Task<List<CurrencyBalance>> GetAsync(string userId);
		Task<CurrencyBalance> GetAsync(string userId, CurrencyCode currency);
		Task UpdateAmountAsync(Guid currencyBalanceId, decimal newAmount);
	}
}
