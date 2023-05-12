namespace EasyTracker.BLL.DTO;

public class ModelOutputDTO
{
    public float[] PredictedRates { get; set; }
    public float[] LowerBoundRates { get; set; }
    public float[] UpperBoundRates { get; set; }
}
