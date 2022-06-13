using EasyTracker.DAL.Enums;

namespace EasyTracker.DAL.Models
{
	public class Spending : ModelBase
	{
		public decimal Amount { get; set; }

		public string Comment { get; set; }

		public CurrencyCode Currency { get; set; }

		public Guid SpendingCategoryId { get; set; }

		public SpendingCategory SpendingCategory { get; set; }
	}
}
