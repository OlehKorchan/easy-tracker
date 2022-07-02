using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces;

public interface IMainSpendingCategoryRepository
{
    Task<MainSpendingCategory> GetAsync(Guid categoryId);
    Task<List<MainSpendingCategory>> GetAllAsync();
}
