using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces;

public interface ISpendingService
{
    Task AddAsync(SpendingDTO spendingDto);
    Task DeleteAsync(SpendingDTO spendingDto);
    Task<List<SpendingDTO>> GetAsync();
    Task<List<SpendingDTO>> GetAsync(DateTime startDate, DateTime endDate);
    Task<SpendingDTO> GetAsync(Guid id);
}
