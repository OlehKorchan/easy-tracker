using EasyTracker.DAL.Data;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace EasyTracker.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EasyTrackerDbContext _dbContext;

    public UserRepository(EasyTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAmountAsync(string userName, decimal amount)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        user.Amount += amount;

        _dbContext.Entry(user).Property(u => u.Amount).IsModified = true;
    }

    public Task<User> GetByNameAsync(string userName)
    {
        return _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);
    }

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

    public Task<User> GetWithStatisticsByNameAndDateAsync(
        string userName,
        DateTime? startDate,
        DateTime? endDate)
    {
        if (startDate.HasValue && endDate.HasValue)
        {
            return _dbContext.Users
                .AsNoTracking()
                .Include(
                    u => u.Salaries.Where(s => s.DateAdded <= endDate && s.DateAdded >= startDate))
                .Include(u => u.SpendingCategories)
                .ThenInclude(
                    uc => uc.Spendings.Where(
                        s => s.DateOfSpending <= endDate && s.DateOfSpending >= startDate))
                .Include(u => u.Savings)
                .Include(u => u.CurrencyBalances)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        return _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Salaries)
            .Include(u => u.SpendingCategories)
            .ThenInclude(uc => uc.Spendings)
            .Include(u => u.Savings)
            .Include(u => u.CurrencyBalances)
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task UpdateAsync(User user)
    {
        var userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        userToUpdate.Amount = user.Amount;
        userToUpdate.MainCurrency = user.MainCurrency;

        _dbContext.Users.Update(userToUpdate);
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
