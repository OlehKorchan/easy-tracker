using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class SalaryRepository : ISalaryRepository
	{
		private readonly EasyTrackerDbContext _db;

		public SalaryRepository(EasyTrackerDbContext db) => _db = db;

		public Task AddAsync(Salary salary) => _db.Salaries.AddAsync(salary).AsTask();

		public async Task DeleteAsync(Guid id)
		{
			var salaryToDelete = await _db.Salaries.FirstAsync(s => s.Id == id);
			_db.Salaries.Remove(salaryToDelete);
		}

		public Task<Salary> GetAsync(Guid salaryId) => _db.Salaries
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.Id == salaryId);

		public Task<List<Salary>> GetAllAsync(string userId) => _db.Salaries
				.AsNoTracking()
				.Where(s => s.UserId == userId)
				.OrderByDescending(s => s.DateAdded)
				.ToListAsync();
	}
}
