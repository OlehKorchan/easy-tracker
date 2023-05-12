using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers;

[Route("currency-prediction")]
[ApiController]
[Authorize]
public class CurrencyPredictionController : ControllerBase
{
    private readonly ICurrencyDataService _dataService;

    public CurrencyPredictionController(ICurrencyDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet("update-database")]
    public async Task<IActionResult> UpdateDatabaseAsync()
    {
        await _dataService.UpdateDataAsync();

        return Ok();
    }

    [HttpGet("get-next-week-prediction")]
    public async Task<IActionResult> GetNextWeekPredictionAsync()
    {
        return Ok(await _dataService.Process());
    }
}
