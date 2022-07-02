using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories;

public class BaseCurrencyRateRepository : IBaseCurrencyRateRepository
{
    private readonly DbSet<BaseCurrencyRate> _baseCurrencyRates;

    public BaseCurrencyRateRepository(EasyTrackerDbContext context)
    {
        _baseCurrencyRates = context.Set<BaseCurrencyRate>();
    }

    public Task<BaseCurrencyRate> GetRateAsync(CurrencyCode fromCurrency, CurrencyCode toCurrency)
    {
        return _baseCurrencyRates
            .AsNoTracking()
            .FirstOrDefaultAsync(
                c =>
                    c.FromCurrency == fromCurrency && c.ToCurrency == toCurrency);
    }

    public Task<List<BaseCurrencyRate>> GetAllRatesAsync()
    {
        return _baseCurrencyRates.AsNoTracking().ToListAsync();
    }

    public Task<List<BaseCurrencyRate>> GetRateFromCurrencyAsync(CurrencyCode currency)
    {
        return _baseCurrencyRates
            .AsNoTracking()
            .Where(r => r.FromCurrency == currency)
            .ToListAsync();
    }

    public Task<List<BaseCurrencyRate>> GetRateToCurrencyAsync(CurrencyCode currency)
    {
        return _baseCurrencyRates
            .AsNoTracking()
            .Where(r => r.ToCurrency == currency)
            .ToListAsync();
    }
}
