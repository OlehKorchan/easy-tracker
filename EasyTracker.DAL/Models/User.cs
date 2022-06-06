using Microsoft.AspNetCore.Identity;

namespace EasyTracker.DAL.Models
{
	public class User : IdentityUser
	{
		public decimal Amount { get; set; }

		public List<Salary> Salaries { get; set; }

		public List<Saving> Savings { get; set; }

		public List<SpendingCategory> SpendingCategories { get; set; }
	}
}