using EasyTracker.DAL.Models;

namespace EasyTracker.DAL.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetByNameAsync(string userName);
		void Update(User user);
	}
}
