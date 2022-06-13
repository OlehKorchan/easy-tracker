using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.DTO
{
	public class MainCurrencyRequestDTO
	{
		public CurrencyCode NewMainCurrencyCode { get; set; }

		public bool Recalculate { get; set; }

		public string UserName { get; set; }
	}
}
