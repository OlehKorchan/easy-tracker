using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class CurrencyRateRepository : ICurrencyRateRepository
	{
		private readonly DbSet<CurrencyRate> _currencyRates;

		public CurrencyRateRepository(EasyTrackerDbContext context)
		{
			_currencyRates = context.Set<CurrencyRate>();
		}

		public Task<CurrencyRate> GetUserRateAsync(
			string userId,
			CurrencyCode fromCurrency,
			CurrencyCode toCurrency)
		{
			return _currencyRates
				.AsNoTracking()
				.FirstOrDefaultAsync(
					c =>
						c.UserId == userId
						&& (c.FromCurrency == fromCurrency && c.ToCurrency == toCurrency));
		}

		public Task<List<CurrencyRate>> GetAllUserRatesAsync(string userId)
		{
			return _currencyRates
				.AsNoTracking()
				.Where(r => r.UserId == userId)
				.ToListAsync();
		}

		public Task<List<CurrencyRate>> GetRatesFromCurrencyAsync(string userId, CurrencyCode currency)
		{
			return _currencyRates
				.AsNoTracking()
				.Where(
					r =>
						r.UserId == userId
						&& r.FromCurrency == currency)
				.ToListAsync();
		}

		public Task<List<CurrencyRate>> GetRatesToCurrencyAsync(string userId, CurrencyCode currency)
		{
			return _currencyRates
				.AsNoTracking()
				.Where(r => r.UserId == userId && r.ToCurrency == currency)
				.ToListAsync();
		}
	}
}
