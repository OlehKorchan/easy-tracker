using System.Security.Claims;
using AutoMapper;
using EasyTracker.API.Helpers;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class SalariesController : ControllerBase
	{
		private readonly ILogger<SalariesController> _logger;
		private readonly ISalaryService _salaryService;
		private readonly IMapper _mapper;

		public SalariesController(
				ILogger<SalariesController> logger,
				ISalaryService salaryService,
				IMapper mapper
		)
		{
			_logger = logger;
			_salaryService = salaryService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetUserSalariesAsync()
		{
			var salaries = await _salaryService.GetAllUserSalariesAsync(
					User.FindFirstValue(ClaimTypes.NameIdentifier));

			var userSalariesResponse = new UserSalariesResponseModel
			{
				UserSalaries = _mapper.Map<List<SalaryDTO>, List<SalaryResponseModel>>(salaries)
			};

			return Ok(userSalariesResponse);
		}

		[HttpGet("{salaryId}")]
		public async Task<IActionResult> GetAsync(string salaryId)
		{
			return Ok(await _salaryService.GetAsync(Guid.Parse(salaryId)));
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(SalaryCreateRequestModel salaryCreate)
		{
			var salaryResponseModel = new SalaryResponseModel
			{
				Amount = salaryCreate.Amount,
				Comment = salaryCreate.Comment
			};

			if (!ModelState.IsValid)
			{
				ModelErrorsHelper.PutModelStateErrorsToResponseModel(
						ModelState,
						salaryResponseModel
				);
				_logger.LogError(
					"Salary validation failed with errors: {errors}",
					salaryResponseModel.Errors);

				return Ok(salaryResponseModel);
			}

			var salaryDto = new SalaryDTO
			{
				Amount = salaryCreate.Amount,
				Comment = salaryCreate.Comment,
				UserName = User.FindFirstValue(ClaimTypes.NameIdentifier)
			};

			await _salaryService.AddAsync(salaryDto);

			_logger.LogInformation("Salary was successfully added");

			return Ok(salaryResponseModel);
		}

		[HttpDelete("{salaryId}")]
		public async Task<IActionResult> DeleteAsync(string salaryId)
		{
			var salaryDto = new SalaryDTO
			{
				Id = Guid.Parse(salaryId),
				UserName = User.FindFirstValue(ClaimTypes.NameIdentifier)
			};

			await _salaryService.DeleteAsync(salaryDto);

			return Ok();
		}
	}
}
