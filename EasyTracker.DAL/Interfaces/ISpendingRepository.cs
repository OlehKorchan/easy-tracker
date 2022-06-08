using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface ISpendingRepository
	{
		Task<Spending> GetAsync(Guid id);
		Task AddAsync(Spending spending);
		void Delete(Spending spending);
	}
}
