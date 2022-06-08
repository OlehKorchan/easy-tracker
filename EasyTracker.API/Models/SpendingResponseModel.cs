namespace EasyTracker.API.Models
{
	public class SpendingResponseModel : ResponseModelBase
	{
		public Guid Id { get; set; }

		public decimal Amount { get; set; }

		public string Comment { get; set; }

		public Guid SpendingCategoryId { get; set; }

		public SpendingCategoryResponseModel SpendingCategory { get; set; }
	}
}
