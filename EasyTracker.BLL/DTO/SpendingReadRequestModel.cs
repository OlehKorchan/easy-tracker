using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Models;

public class SpendingReadRequestModel
{
    [FromQuery] public DateTime? StartDate { get; set; }

    [FromQuery] public DateTime? EndDate { get; set; }
}
