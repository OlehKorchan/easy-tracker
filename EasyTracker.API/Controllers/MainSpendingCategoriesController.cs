using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers
{
	[Route("main-spending-categories")]
	[ApiController]
	public class MainSpendingCategoriesController : ControllerBase
	{
		private readonly ISpendingCategoryService _service;

		public MainSpendingCategoriesController(ISpendingCategoryService service)
		{
			_service = service;
		}

		[HttpGet("{categoryId}")]
		public async Task<IActionResult> GetAsync(string categoryId)
		{
			var category = await _service.GetMainAsync(Guid.Parse(categoryId));

			return Ok(category);
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			var categories = await _service.GetAllMainAsync();

			return Ok(categories);
		}
	}
}