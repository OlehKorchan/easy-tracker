using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SpendingController : ControllerBase
	{
		private readonly ISpendingService _spendingService;

		public SpendingController(ISpendingService spendingService)
		{
			_spendingService = spendingService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(string id)
		{
			var spending = await _spendingService.GetAsync(Guid.Parse(id));

			return Ok(spending);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] SpendingDTO spending)
		{
			await _spendingService.AddAsync(spending);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync([FromBody] SpendingDTO spending)
		{
			await _spendingService.DeleteAsync(spending);

			return Ok();
		}
	}
}