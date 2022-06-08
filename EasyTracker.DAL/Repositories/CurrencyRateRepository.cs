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

        public Task<CurrencyRate> GetAsync(
            string userId,
            CurrencyCode fromCurrency,
            CurrencyCode toCurrency
        )
        {
            return _currencyRates
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    c =>
                        c.UserId == userId
                        && (
                            c.FromCurrency == fromCurrency && c.ToCurrency == toCurrency
                            || (c.FromCurrency == toCurrency && c.ToCurrency == fromCurrency)
                        )
                );
        }
    }
}
