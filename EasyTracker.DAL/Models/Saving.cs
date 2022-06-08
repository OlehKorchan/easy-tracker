namespace EasyTracker.DAL.Models
{
	public class Saving : ModelBase
	{
		public string SavingName { get; set; }

		public decimal Amount { get; set; }

		public decimal TargetAmount { get; set; }

		public string Description { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }
	}
}
