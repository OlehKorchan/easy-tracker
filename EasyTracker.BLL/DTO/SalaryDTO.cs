namespace EasyTracker.BLL.DTO
{
	public class SalaryDTO
	{
		public Guid Id { get; set; }

		public decimal Amount { get; set; }

		public string Comment { get; set; }

		public DateTime DateAdded { get; set; }

		public string UserName { get; set; }
	}
}
