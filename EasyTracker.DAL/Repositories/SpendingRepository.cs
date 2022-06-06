using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class SpendingRepository : ISpendingRepository
	{
		private readonly EasyTrackerDbContext _db;

		public SpendingRepository(EasyTrackerDbContext db)
		{
			_db = db;
		}

		public async Task<Spending> GetAsync(Guid id)
		{
			return await _db.Spendings
				.AsNoTracking()
				.FirstOrDefaultAsync(sp => sp.Id == id);
		}

		public async Task AddAsync(Spending spending)
		{
			await _db.Spendings.AddAsync(spending);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(Spending spending)
		{
			_db.Spendings.Remove(spending);
			await _db.SaveChangesAsync();
		}
	}
}