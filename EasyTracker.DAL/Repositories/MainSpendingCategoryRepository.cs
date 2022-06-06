using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class MainSpendingCategoryRepository : IMainSpendingCategoryRepository
	{
		private readonly EasyTrackerDbContext _context;

		public MainSpendingCategoryRepository(EasyTrackerDbContext context)
		{
			_context = context;
		}

		public async Task<List<MainSpendingCategory>> GetAllAsync()
		{
			return await _context.MainSpendingCategories
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<MainSpendingCategory> GetAsync(Guid categoryId)
		{
			return await _context.MainSpendingCategories
				.AsNoTracking()
				.FirstOrDefaultAsync(msc => msc.Id == categoryId);
		}
	}
}