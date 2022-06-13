using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.DTO
{
	public class UserStatisticsDTO
	{
		public string Amount { get; set; }

		public CurrencyCode MainCurrency { get; set; }

		public List<SpendingCategoryGetDTO> SpendingCategories { get; set; }

		public List<SalaryDTO> Salaries { get; set; }

		public List<CurrencyBalanceDTO> CurrencyBalances { get; set; }
	}
}
