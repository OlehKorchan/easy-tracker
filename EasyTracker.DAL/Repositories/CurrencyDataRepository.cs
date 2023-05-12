using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models.ML;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Repositories;

public class CurrencyDataRepository : ICurrencyDataRepository
{
    private readonly DbSet<ModelInput> _table;

    public CurrencyDataRepository(EasyTrackerDbContext context)
    {
        _table = context.Set<ModelInput>();
    }

    public Task CreateManyAsync(IEnumerable<ModelInput> items)
    {
        _table.AddRange(items);

        return Task.CompletedTask;
    }

    public async Task ClearTable()
    {
        var items = await _table.Where(t => t.Id > 0).ToListAsync();
        _table.RemoveRange(items);
    }
}
