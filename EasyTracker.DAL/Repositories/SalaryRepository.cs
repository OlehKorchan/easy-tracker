using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class SalaryRepository : ISalaryRepository
	{
		private readonly DbSet<Salary> _salaries;

		public SalaryRepository(EasyTrackerDbContext db)
		{
			_salaries = db.Set<Salary>();
		}

		public Task AddAsync(Salary salary)
		{
			return _salaries.AddAsync(salary).AsTask();
		}

		public async Task DeleteAsync(Guid id)
		{
			var salaryToDelete = await _salaries.FirstAsync(
				s => s.Id == id);

			_salaries.Remove(salaryToDelete);
		}

		public Task<Salary> GetAsync(Guid salaryId)
		{
			return _salaries
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.Id == salaryId);
		}

		public Task<List<Salary>> GetAllAsync(string userId)
		{
			return _salaries
				.AsNoTracking()
				.Where(s => s.UserId == userId)
				.OrderByDescending(s => s.DateAdded)
				.ToListAsync();
		}
	}
}
