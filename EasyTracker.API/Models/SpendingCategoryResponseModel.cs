namespace EasyTracker.API.Models
{
	public class SpendingCategoryResponseModel
	{
		public Guid Id { get; set; }

		public string ImageSrc { get; set; }

		public byte[] Image { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }
	}
}