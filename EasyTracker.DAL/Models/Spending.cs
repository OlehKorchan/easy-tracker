namespace EasyTracker.DAL.Models
{
	public class Spending : ModelBase
	{
		public decimal PlannedAmount { get; set; }

		public decimal SpendAmount { get; set; }

		public Guid SpendingCategoryId { get; set; }

		public SpendingCategory SpendingCategory { get; set; }
	}
}