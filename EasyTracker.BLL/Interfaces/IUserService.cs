using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(string userName);
        Task AddAmountAsync(decimal amount, string userName);
        Task AddMainCategoriesAsync(string userName);
        Task UpdateMainCurrencyAsync(MainCurrencyRequestDTO model);
    }
}
