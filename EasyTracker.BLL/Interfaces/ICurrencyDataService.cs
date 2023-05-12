using EasyTracker.BLL.DTO;

namespace EasyTracker.BLL.Interfaces;

public interface ICurrencyDataService
{
    Task UpdateDataAsync();

    Task<IEnumerable<PredictionResultDTO>> Process();
}
