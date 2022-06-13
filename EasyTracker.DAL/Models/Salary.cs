using EasyTracker.DAL.Enums;

namespace EasyTracker.DAL.Models
{
	public class Salary : ModelBase
	{
		public decimal Amount { get; set; }

		public DateTime DateAdded { get; set; }

		public string Comment { get; set; }

		public CurrencyCode Currency { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }
	}
}
