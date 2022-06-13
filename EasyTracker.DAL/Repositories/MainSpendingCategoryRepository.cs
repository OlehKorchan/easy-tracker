using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class MainSpendingCategoryRepository : IMainSpendingCategoryRepository
	{
		private readonly DbSet<MainSpendingCategory> _mainSpendingCategories;

		public MainSpendingCategoryRepository(EasyTrackerDbContext context)
		{
			_mainSpendingCategories = context.Set<MainSpendingCategory>();
		}

		public async Task<List<MainSpendingCategory>> GetAllAsync() =>
			await _mainSpendingCategories.AsNoTracking().ToListAsync();

		public async Task<MainSpendingCategory> GetAsync(Guid categoryId) =>
			await _mainSpendingCategories
				.AsNoTracking()
				.FirstOrDefaultAsync(msc => msc.Id == categoryId);
	}
}
