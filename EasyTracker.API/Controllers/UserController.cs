using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyTracker.API.Controllers
{
	[Authorize]
	[Route("[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet("amount")]
		public async Task<IActionResult> GetUserAmountAsync()
		{
			var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var userAmount = await _userService.GetUserAmountAsync(userName);

			var userResponseModel = new UserAmountResponseModel { Amount = userAmount };

			return Ok(userResponseModel);
		}

		[HttpGet("statistics")]
		public async Task<IActionResult> GetUserStatisticsAsync()
		{
			var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var userStatistics = await _userService.GetUserStatisticsAsync(userName);
			var userResponse = _mapper.Map<UserStatisticsResponseModel>(userStatistics);
			userResponse.Salaries = _mapper.Map<List<SalaryResponseModel>>(userStatistics.Salaries);
			userResponse.SpendingCategories = _mapper.Map<List<SpendingCategoryResponseModel>>(
				userStatistics.SpendingCategories
			);

			return Ok(userResponse);
		}

		[HttpPut("main-currency")]
		public async Task<IActionResult> PutMainCurrencyAsync(
			[FromBody] MainCurrencyRequestModel model
		)
		{
			var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var modelDto = _mapper.Map<MainCurrencyRequestDTO>(model);
			modelDto.UserName = userName;

			await _userService.UpdateMainCurrencyAsync(modelDto);

			return Ok();
		}

		[HttpGet("main-currency")]
		public async Task<IActionResult> GetUserMainCurrency()
		{
			var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var userMainCurrencyResponse = await _userService.GetUserMainCurrencyAsync(userName);

			return Ok(
				new UserMainCurrencyResponseModel { MainCurrency = userMainCurrencyResponse }
			);
		}
	}
}
