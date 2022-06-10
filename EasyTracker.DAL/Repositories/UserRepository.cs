using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EasyTrackerDbContext _dbContext;

        public UserRepository(EasyTrackerDbContext dbContext) => _dbContext = dbContext;

        public async Task AddAmountAsync(string userName, decimal amount)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.Amount += amount;

            _dbContext.Entry(user).Property(u => u.Amount).IsModified = true;
        }

        public Task<User> GetByNameAsync(string userName) =>
            _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);

        public Task<decimal> GetUserAmountAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserName == userName)
                .Select(u => u.Amount)
                .SingleOrDefaultAsync();
        }

        public Task<string> GetUserIdByNameAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserName == userName)
                .Select(u => u.Id)
                .SingleOrDefaultAsync();
        }

        public Task<CurrencyCode> GetUserMainCurrencyAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserName == userName)
                .Select(u => u.MainCurrency)
                .SingleOrDefaultAsync();
        }

        public Task<User> GetWithStatisticsByNameAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Salaries)
                .Include(u => u.SpendingCategories)
                .ThenInclude(uc => uc.Spendings)
                .Include(u => u.Savings)
                .Include(u => u.CurrencyBalances)
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            _dbContext.Users.Update(user);
        }

        public async Task UpdateAmountAsync(string userName, decimal amount)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.Amount = amount;

            _dbContext.Entry(user).Property(u => u.Amount).IsModified = true;
        }

        public async Task UpdateMainCurrencyAsync(string userName, CurrencyCode newCurrency)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.MainCurrency = newCurrency;

            _dbContext.Entry(user).Property(u => u.MainCurrency).IsModified = true;
        }
    }
}
