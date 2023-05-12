using EasyTracker.DAL.Models.ML;

namespace EasyTracker.DAL.Interfaces;

public interface ICurrencyDataRepository
{
    Task CreateManyAsync(IEnumerable<ModelInput> items);
    Task ClearTable();
}
