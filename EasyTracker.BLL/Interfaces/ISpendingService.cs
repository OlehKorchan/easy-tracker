using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces
{
	public interface ISpendingService
	{
		Task AddAsync(SpendingDTO spendingDto);
		Task DeleteAsync(SpendingDTO spendingDto);
		Task<SpendingDTO> GetAsync(Guid id);
	}
}
