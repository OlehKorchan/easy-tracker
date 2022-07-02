namespace EasyTracker.DAL.Models;

public class SpendingCategory : ModelBase
{
    public string ImageSrc { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public decimal PlannedAmount { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public List<Spending> Spendings { get; set; }
}
