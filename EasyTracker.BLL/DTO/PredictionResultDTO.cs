namespace EasyTracker.BLL.DTO;

public class PredictionResultDTO
{
    public DateTime Date { get; set; }

    public float UpperBound { get; set; }

    public float Prediction { get; set; }

    public float LowerBound { get; set; }
}
