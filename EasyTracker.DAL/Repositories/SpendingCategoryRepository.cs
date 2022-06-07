using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class SpendingCategoryRepository : ISpendingCategoryRepository
	{
		private readonly EasyTrackerDbContext _context;

		public SpendingCategoryRepository(EasyTrackerDbContext context)
		{
			_context = context;
		}

		public Task<SpendingCategory> GetAsync(Guid categoryId)
		{
			return _context.SpendingCategories
				.AsNoTracking()
				.FirstOrDefaultAsync(sc => sc.Id == categoryId);
		}

		public Task<List<SpendingCategory>> GetAllAsync()
		{
			return _context.SpendingCategories
				.AsNoTracking()
				.ToListAsync();
		}

		public Task AddAsync(SpendingCategory spendingCategory)
		{
			return _context.SpendingCategories.AddAsync(spendingCategory).AsTask();
		}

		public Task AddManyAsync(IEnumerable<SpendingCategory> spendingCategories)
		{
			return _context.SpendingCategories.AddRangeAsync(spendingCategories);
		}

		public void Delete(SpendingCategory spendingCategory)
		{
			_context.SpendingCategories.Remove(spendingCategory);
		}
	}
}