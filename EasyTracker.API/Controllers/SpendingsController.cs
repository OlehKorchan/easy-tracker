using AutoMapper;
using EasyTracker.API.Helpers;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Exceptions;
using EasyTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly ISpendingService _spendingService;
        private readonly IMapper _mapper;

        public SpendingsController(ISpendingService spendingService, IMapper mapper)
        {
            _spendingService = spendingService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var spending = await _spendingService.GetAsync(Guid.Parse(id));

            return Ok(spending);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SpendingRequestModel spending)
        {
            var response = new SpendingResponseModel();

            if (ModelState.IsValid)
            {
                try
                {
                    await _spendingService.AddAsync(_mapper.Map<SpendingDTO>(spending));
                }
                catch (NoSuchCurrencyBalanceException ex)
                {
                    response.Errors.Add(ex.Message);
                }
            }
            else
            {
                ModelErrorsHelper.PutModelStateErrorsToResponseModel(ModelState, response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody] SpendingDTO spending)
        {
            await _spendingService.DeleteAsync(spending);

            return Ok();
        }
    }
}
