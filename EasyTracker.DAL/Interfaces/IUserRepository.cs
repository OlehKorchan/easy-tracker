using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetWithStatisticsByNameAsync(string userName);
		Task<User> GetByNameAsync(string userName);
		Task<string> GetUserIdByNameAsync(string userName);
		Task<decimal> GetUserAmountAsync(string userName);
		Task<CurrencyCode> GetUserMainCurrencyAsync(string userName);
		Task AddAmountAsync(string userName, decimal amount);
		Task UpdateAsync(User user);
		Task UpdateAmountAsync(string userName, decimal amount);
		Task UpdateMainCurrencyAsync(string userName, CurrencyCode newCurrency);
	}
}
