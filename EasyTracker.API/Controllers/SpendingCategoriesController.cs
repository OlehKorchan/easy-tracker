using System.Security.Claims;
using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers;

[Route("spending-categories")]
[ApiController]
public class SpendingCategoriesController : ControllerBase
{
    private readonly ISpendingCategoryService _spendingCategoryService;
    private readonly IMapper _mapper;

    public SpendingCategoriesController(
        ISpendingCategoryService spendingCategoryService,
        IMapper mapper
    )
    {
        _spendingCategoryService = spendingCategoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var spendingCategoryDtos = await _spendingCategoryService.GetAllAsync(userName);

        return Ok(_mapper.Map<List<SpendingCategoryResponseModel>>(spendingCategoryDtos));
    }

    [HttpGet("{spendingCategoryId}")]
    public async Task<IActionResult> GetAsync(string spendingCategoryId)
    {
        var spendingCategory = await _spendingCategoryService.GetAsync(
            Guid.Parse(spendingCategoryId)
        );

        return Ok(_mapper.Map<SpendingCategoryResponseModel>(spendingCategory));
    }

    [HttpPost]
    public async Task<IActionResult> Post(SpendingCategoryRequestModel spendingCategoryRequest)
    {
        spendingCategoryRequest.UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _spendingCategoryService.CreateAsync(
            _mapper.Map<SpendingCategoryPostDTO>(spendingCategoryRequest)
        );

        return Ok();
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> Delete(string categoryId)
    {
        var currentUserName = User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _spendingCategoryService.DeleteAsync(
            new SpendingCategoryPostDTO
            {
                Id = Guid.Parse(categoryId),
                UserName = currentUserName
            }
        );

        return Ok();
    }
}
