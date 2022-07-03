using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetUserAsync(string userName);
    Task<UserStatisticsDTO> GetUserStatisticsAsync(string userName);
    Task<decimal> GetUserAmountAsync(string userName);
    Task PutUserAmountAsync(string userName, decimal userAmount);
    Task<CurrencyCode> GetUserMainCurrencyAsync(string userName);
    Task AddAmountAsync(decimal amount, string userName);
    Task UpdateMainCurrencyAsync(MainCurrencyRequestDTO model);
}
