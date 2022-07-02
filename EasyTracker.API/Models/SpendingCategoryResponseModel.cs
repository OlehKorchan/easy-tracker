namespace EasyTracker.API.Models;

public class SpendingCategoryResponseModel : ResponseModelBase
{
    public Guid Id { get; set; }

    public string ImageSrc { get; set; }

    public byte[] Image { get; set; }

    public string CategoryName { get; set; }

    public decimal PlannedAmount { get; set; }

    public decimal SpendAmount { get; set; }

    public string Description { get; set; }

    public List<SpendingResponseModel> Spendings { get; set; }
}
