using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.DTO
{
	public class SpendingCategoryGetDTO : ModelBase
	{
		public string ImageSrc { get; set; }

		public byte[] Image { get; set; }

		public string CategoryName { get; set; }

		public decimal PlannedAmount { get; set; }

		public decimal SpendAmount { get; set; }

		public string Description { get; set; }

		public List<SpendingDTO> Spendings { get; set; }
	}
}