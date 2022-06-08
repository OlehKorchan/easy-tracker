namespace EasyTracker.BLL.DTO
{
    public class UserStatisticsDTO
    {
        public string Amount { get; set; }

        public DAL.Enums.CurrencyCode MainCurrency { get; set; }

        public List<SpendingCategoryGetDTO> SpendingCategories { get; set; }

        public List<SalaryDTO> Salaries { get; set; }
    }
}
