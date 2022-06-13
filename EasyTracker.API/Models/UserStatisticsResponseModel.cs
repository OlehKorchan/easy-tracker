using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models
{
	public class UserStatisticsResponseModel : ResponseModelBase
	{
		public decimal Amount { get; set; }

		public CurrencyCode MainCurrency { get; set; }

		public List<SpendingCategoryResponseModel> SpendingCategories { get; set; }

		public List<SalaryResponseModel> Salaries { get; set; }

		public List<CurrencyBalanceDTO> CurrencyBalances { get; set; }
	}
}
