using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IUser _user;

    public UserController(IUserService userService, IMapper mapper, IUser user)
    {
        _userService = userService;
        _mapper = mapper;
        _user = user;
    }

    [HttpGet("amount")]
    public async Task<IActionResult> GetUserAmountAsync()
    {
        var userAmount = await _userService.GetUserAmountAsync(_user.UserName);

        var userResponseModel = new UserAmountResponseModel { Amount = userAmount };

        return Ok(userResponseModel);
    }

    [HttpPut("amount")]
    public async Task<IActionResult> PutUserAmountAsync(UserAmountRequestModel request)
    {
        await _userService.PutUserAmountAsync(_user.UserName, request.Amount);

        return Ok();
    }

    [HttpGet("statistics")]
    public async Task<IActionResult> GetUserStatisticsAsync()
    {
        var userStatistics = await _userService.GetUserStatisticsAsync(_user.UserName);
        var userResponse = _mapper.Map<UserStatisticsResponseModel>(userStatistics);

        return Ok(userResponse);
    }

    [HttpPut("main-currency")]
    public async Task<IActionResult> PutMainCurrencyAsync(
        [FromBody] MainCurrencyRequestModel model)
    {
        var modelDto = _mapper.Map<MainCurrencyRequestDTO>(model);
        modelDto.UserName = _user.UserName;

        await _userService.UpdateMainCurrencyAsync(modelDto);

        return Ok();
    }

    [HttpGet("main-currency")]
    public async Task<IActionResult> GetUserMainCurrency()
    {
        var userMainCurrencyResponse = await _userService.GetUserMainCurrencyAsync(_user.UserName);

        return Ok(new UserMainCurrencyResponseModel {MainCurrency = userMainCurrencyResponse});
    }
}
