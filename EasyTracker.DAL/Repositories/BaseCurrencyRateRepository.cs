using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
    public class BaseCurrencyRateRepository : IBaseCurrencyRateRepository
    {
        private readonly DbSet<BaseCurrencyRate> _baseCurrencyRates;

        public BaseCurrencyRateRepository(EasyTrackerDbContext context)
        {
            _baseCurrencyRates = context.Set<BaseCurrencyRate>();
        }

        public Task<BaseCurrencyRate> GetAsync(CurrencyCode fromCurrency, CurrencyCode toCurrency)
        {
            return _baseCurrencyRates
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    c =>
                        c.FromCurrency == fromCurrency && c.ToCurrency == toCurrency
                        || (c.FromCurrency == toCurrency && c.ToCurrency == fromCurrency)
                );
        }
    }
}