using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyTracker.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<User> _userManager;

		public UserService(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<UserDTO> GetUserAsync(string userName)
		{
			var currentUser = await _userManager.FindByNameAsync(userName);

			return new UserDTO
			{
				UserName = currentUser.UserName,
				Amount = currentUser.Amount
			};
		}

		public async Task AddAmountAsync(decimal amount, string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			user.Amount += amount;

			await _userManager.UpdateAsync(user);
		}
	}
}