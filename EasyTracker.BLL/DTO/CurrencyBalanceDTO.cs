using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.DTO;

public class CurrencyBalanceDTO
{
    public Guid Id { get; set; }

    public CurrencyCode Currency { get; set; }

    public decimal Amount { get; set; }
}
