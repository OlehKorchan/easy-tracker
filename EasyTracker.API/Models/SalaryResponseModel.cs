namespace EasyTracker.API.Models
{
	public class SalaryResponseModel : ResponseModelBase
	{
		public Guid Id { get; set; }

		public decimal Amount { get; set; }

		public string Comment { get; set; }

		public DateTime DateAdded { get; set; }
	}
}
