using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models;

public class SpendingResponseModel : ResponseModelBase
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Comment { get; set; }

    public CurrencyCode Currency { get; set; }

    public DateTime DateOfSpending { get; set; }

    public string CategoryName { get; set; }
}
