using AutoMapper;
using EasyTracker.API.Models;
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
		private readonly ILogger<UserController> _logger;
		private readonly IMapper _mapper;

		public UserController(
			IUserService userService, ILogger<UserController> logger, IMapper mapper)
		{
			_userService = userService;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet("amount")]
		public async Task<IActionResult> GetUserAmountAsync()
		{
			var currentUser = await _userService.GetUserAsync(
				User.FindFirstValue(ClaimTypes.NameIdentifier));

			var userResponseModel = new UserAmountResponseModel
			{
				Amount = currentUser.Amount
			};

			return Ok(userResponseModel);
		}
	}
}