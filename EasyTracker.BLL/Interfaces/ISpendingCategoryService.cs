using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Interfaces
{
    public interface ISpendingCategoryService
    {
        Task<List<MainSpendingCategory>> GetAllMainAsync();
        Task<MainSpendingCategory> GetMainAsync(Guid categoryId);
        Task<SpendingCategoryGetDTO> GetAsync(Guid categoryId);
        Task<List<SpendingCategoryGetDTO>> GetAllAsync(string userName);
        Task CreateAsync(SpendingCategoryPostDTO spendingCategory);
        Task CreateManyAsync(IEnumerable<SpendingCategory> spendingCategories);
        Task DeleteAsync(SpendingCategoryPostDTO spendingCategory);
    }
}
