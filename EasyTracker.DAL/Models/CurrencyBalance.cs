using EasyTracker.DAL.Enums;

namespace EasyTracker.DAL.Models;

public class CurrencyBalance : ModelBase
{
    public decimal Amount { get; set; }

    public CurrencyCode Currency { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}
