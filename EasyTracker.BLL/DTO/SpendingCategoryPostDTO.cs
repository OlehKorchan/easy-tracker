using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.DTO
{
	public class SpendingCategoryPostDTO : ModelBase
	{
		public string ImageSrc { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }

		public string UserName { get; set; }
	}
}
