using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface ISalaryRepository
	{
		Task AddAsync(Salary salary);
		void Delete(Salary salary);
		Task<Salary> GetAsync(Guid salaryId);
		Task<List<Salary>> GetAllAsync(string userId);
	}
}