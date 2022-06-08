using System.Security.Claims;
using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var currentUser = await _userService.GetUserAsync(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var userResponseModel = new UserAmountResponseModel { Amount = currentUser.Amount };

            return Ok(userResponseModel);
        }

        [HttpPut("main-currency")]
        public async Task<IActionResult> PutMainCurrencyAsync(MainCurrencyRequestModel model)
        {
            var currentUser = await _userService.GetUserAsync(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var modelDto = _mapper.Map<MainCurrencyRequestDTO>(model);
            modelDto.UserName = currentUser.UserName;

            await _userService.UpdateMainCurrencyAsync(modelDto);

            return Ok();
        }
    }
}
