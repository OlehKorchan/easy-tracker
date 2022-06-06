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

		public async Task<SpendingCategory> GetAsync(Guid categoryId)
		{
			return await _context.SpendingCategories
				.AsNoTracking()
				.FirstOrDefaultAsync(sc => sc.Id == categoryId);
		}

		public async Task<List<SpendingCategory>> GetAllAsync()
		{
			return await _context.SpendingCategories
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task AddAsync(SpendingCategory spendingCategory)
		{
			await _context.SpendingCategories.AddAsync(spendingCategory);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(SpendingCategory spendingCategory)
		{
			_context.SpendingCategories.Remove(spendingCategory);
			await _context.SaveChangesAsync();
		}
	}
}