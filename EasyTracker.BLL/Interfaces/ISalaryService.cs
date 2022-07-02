using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces;

public interface ISalaryService
{
    Task AddAsync(SalaryDTO salary);
    Task DeleteAsync(SalaryDTO salary);
    Task<SalaryDTO> GetAsync(Guid salaryId);
    Task<List<SalaryDTO>> GetAllUserSalariesAsync(string userName);
}
