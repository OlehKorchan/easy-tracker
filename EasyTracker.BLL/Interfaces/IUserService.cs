using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> GetUserAsync(string userName);
		Task AddAmountAsync(decimal amount, string userName);
		Task AddMainCategoriesAsync(string userName);
	}
}
