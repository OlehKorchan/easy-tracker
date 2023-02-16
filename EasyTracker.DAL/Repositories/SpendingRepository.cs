using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories;

public class SpendingRepository : ISpendingRepository
{
    private readonly DbSet<Spending> _spendings;

    public SpendingRepository(EasyTrackerDbContext db)
    {
        _spendings = db.Set<Spending>();
    }

    public Task<List<Spending>> GetAsync(string userId)
    {
        return _spendings
            .Include(s => s.SpendingCategory)
            .Where(s => s.SpendingCategory.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Spending> GetAsync(Guid id)
    {
        return await _spendings.AsNoTracking().FirstOrDefaultAsync(sp => sp.Id == id);
    }

    public Task AddAsync(Spending spending)
    {
        return _spendings.AddAsync(spending).AsTask();
    }

    public void Delete(Spending spending)
    {
        _spendings.Remove(spending);
    }
}
