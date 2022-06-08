namespace EasyTracker.API.Models
{
    public class UserStatisticsResponseModel : ResponseModelBase
    {
        public string Amount { get; set; }

        public DAL.Enums.CurrencyCode MainCurrency { get; set; }

        public List<SpendingCategoryResponseModel> SpendingCategories { get; set; }

        public List<SalaryResponseModel> Salaries { get; set; }
    }
}
