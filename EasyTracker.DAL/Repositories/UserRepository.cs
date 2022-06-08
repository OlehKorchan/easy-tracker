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

        public Task<User> GetByNameAsync(string userName) =>
            _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Salaries)
                .Include(u => u.SpendingCategories)
                .Include(u => u.Savings)
                .FirstOrDefaultAsync(u => u.UserName == userName);

        public Task<decimal> GetUserAmountAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserName == userName)
                .Select(u => u.Amount)
                .FirstAsync();
        }

        public Task<CurrencyCode> GetUserMainCurrencyAsync(string userName)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserName == userName)
                .Select(u => u.MainCurrency)
                .FirstAsync();
        }

        public void Update(User user) => _dbContext.Users.Update(user);
    }
}
