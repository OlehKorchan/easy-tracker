using EasyTracker.DAL.Enums;

namespace EasyTracker.DAL.Models
{
	public class BaseCurrencyRate : ModelBase
	{
		public CurrencyCode FromCurrency { get; set; }

		public CurrencyCode ToCurrency { get; set; }

		public double Rate { get; set; }

		public double ReverseRate { get; set; }
	}
}
