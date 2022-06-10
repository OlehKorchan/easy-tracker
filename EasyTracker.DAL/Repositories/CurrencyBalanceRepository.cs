using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
    public class CurrencyBalanceRepository : ICurrencyBalanceRepository
    {
        private readonly DbSet<CurrencyBalance> _currencyBalances;

        public CurrencyBalanceRepository(EasyTrackerDbContext context)
        {
            _currencyBalances = context.Set<CurrencyBalance>();
        }

        public Task AddAsync(CurrencyBalance currencyBalance)
        {
            return _currencyBalances.AddAsync(currencyBalance).AsTask();
        }

        public Task<List<CurrencyBalance>> GetAsync(string userId)
        {
            return _currencyBalances.AsNoTracking().Where(cb => cb.UserId == userId).ToListAsync();
        }

        public Task<CurrencyBalance> GetAsync(string userId, CurrencyCode currency)
        {
            return _currencyBalances
                .AsNoTracking()
                .FirstOrDefaultAsync(cb => cb.UserId == userId && cb.Currency == currency);
        }

        public async Task UpdateAmountAsync(Guid currencyBalanceId, decimal newAmount)
        {
            var currencyBalance = await _currencyBalances.FirstOrDefaultAsync(
                c => c.Id == currencyBalanceId
            );
            currencyBalance.Amount = newAmount;

            _currencyBalances.Update(currencyBalance);
        }
    }
}
