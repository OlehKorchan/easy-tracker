using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces;

public interface ISpendingRepository
{
    Task<List<Spending>> GetAsync(string userId);
    Task<Spending> GetAsync(Guid id);
    Task AddAsync(Spending spending);
    void Delete(Spending spending);
}
