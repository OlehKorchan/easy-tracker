using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByNameAsync(string userName);
        Task<decimal> GetUserAmountAsync(string userName);
        Task<CurrencyCode> GetUserMainCurrencyAsync(string userName);
        void Update(User user);
    }
}
