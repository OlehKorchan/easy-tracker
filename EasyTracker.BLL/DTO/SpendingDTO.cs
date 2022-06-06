namespace EasyTracker.BLL.DTO
{
	public class SpendingDTO
	{
		public Guid Id { get; set; }

		public decimal PlannedAmount { get; set; }

		public decimal SpendAmount { get; set; }

		public Guid SpendingCategoryId { get; set; }
	}
}