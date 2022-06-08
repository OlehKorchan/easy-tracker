using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
    public class SpendingCategoryRepository : ISpendingCategoryRepository
    {
        private readonly DbSet<SpendingCategory> _spendingCategories;

        public SpendingCategoryRepository(EasyTrackerDbContext context)
        {
            _spendingCategories = context.Set<SpendingCategory>();
        }

        public Task<SpendingCategory> GetAsync(Guid categoryId) =>
            _spendingCategories
                .Include(c => c.Spendings)
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.Id == categoryId);

        public Task<List<SpendingCategory>> GetAllAsync() =>
            _spendingCategories.Include(c => c.Spendings).AsNoTracking().ToListAsync();

        public Task AddAsync(SpendingCategory spendingCategory) =>
            _spendingCategories.AddAsync(spendingCategory).AsTask();

        public Task AddManyAsync(IEnumerable<SpendingCategory> spendingCategories) =>
            _spendingCategories.AddRangeAsync(spendingCategories);

        public async Task DeleteAsync(Guid id)
        {
            var categoryToDelete = await _spendingCategories.FirstAsync(c => c.Id == id);

            _spendingCategories.Remove(categoryToDelete);
        }
    }
}
