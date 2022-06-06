using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface ISpendingCategoryRepository
	{
		Task<SpendingCategory> GetAsync(Guid categoryId);
		Task<List<SpendingCategory>> GetAllAsync();
		Task AddAsync(SpendingCategory spendingCategory);
		Task DeleteAsync(SpendingCategory spendingCategory);
	}
}
