using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces;

public interface ISpendingService
{
    Task AddAsync(SpendingDTO spendingDto);
    Task DeleteAsync(SpendingDTO spendingDto);
    Task<List<SpendingDTO>> GetAsync();
    Task<SpendingDTO> GetAsync(Guid id);
}
