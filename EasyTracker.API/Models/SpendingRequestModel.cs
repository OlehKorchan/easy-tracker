using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models
{
    public class SpendingRequestModel
    {
        public decimal Amount { get; set; }

        public string Comment { get; set; }

        public CurrencyCode Currency { get; set; }

        public Guid SpendingCategoryId { get; set; }
    }
}
