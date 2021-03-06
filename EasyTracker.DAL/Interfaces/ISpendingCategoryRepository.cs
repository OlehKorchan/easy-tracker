using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces;

public interface ISpendingCategoryRepository
{
    Task<SpendingCategory> GetAsync(Guid categoryId);
    Task<List<SpendingCategory>> GetAllAsync(string userId);
    Task AddAsync(SpendingCategory spendingCategory);
    Task AddManyAsync(IEnumerable<SpendingCategory> spendingCategories);
    Task DeleteAsync(Guid id);
}
