using EasyTracker.DAL.Enums;

namespace EasyTracker.BLL.DTO;

public class SpendingDTO
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Comment { get; set; }

    public CurrencyCode Currency { get; set; }

    public Guid SpendingCategoryId { get; set; }

    public DateTime DateOfSpending { get; set; }


    public SpendingCategoryGetDTO SpendingCategory { get; set; }
}
