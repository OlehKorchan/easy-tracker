using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly EasyTrackerDbContext _dbContext;

		public UserRepository(EasyTrackerDbContext dbContext) => _dbContext = dbContext;

		public Task<User> GetByNameAsync(string userName) => _dbContext
				.Users.Include(u => u.Salaries)
				.Include(u => u.SpendingCategories)
				.Include(u => u.Savings)
				.FirstOrDefaultAsync(u => u.UserName == userName);

		public void Update(User user) => _dbContext.Users.Update(user);
	}
}
