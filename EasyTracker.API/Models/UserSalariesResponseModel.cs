namespace EasyTracker.API.Models
{
    public class UserSalariesResponseModel : ResponseModelBase
    {
        public List<SalaryResponseModel> UserSalaries { get; set; }
    }
}
