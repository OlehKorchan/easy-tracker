using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class SpendingRepository : ISpendingRepository
	{
		private readonly DbSet<Spending> _spendings;

		public SpendingRepository(EasyTrackerDbContext db)
		{
			_spendings = db.Set<Spending>();
		}

		public async Task<Spending> GetAsync(Guid id) =>
			await _spendings.AsNoTracking().FirstOrDefaultAsync(sp => sp.Id == id);

		public Task AddAsync(Spending spending) => _spendings.AddAsync(spending).AsTask();

		public void Delete(Spending spending) => _spendings.Remove(spending);
	}
}
