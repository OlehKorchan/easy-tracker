using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly ICurrencyService _currencyService;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ICurrencyService currencyService
    )
    {
        _currencyService = currencyService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO> GetUserAsync(string userName)
    {
        var currentUser =
            await _unitOfWork.UserRepository.GetByNameAsync(userName);

        return new UserDTO
            {UserName = currentUser.UserName, Amount = currentUser.Amount};
    }

    public async Task AddAmountAsync(decimal amount, string userName)
    {
        await _unitOfWork.UserRepository.AddAmountAsync(userName, amount);
        _unitOfWork.SaveAsync().GetAwaiter().GetResult();
    }

    public async Task UpdateMainCurrencyAsync(MainCurrencyRequestDTO model)
    {
        var user =
            await _unitOfWork.UserRepository.GetByNameAsync(model.UserName);

        await RecalculateUserAmountAsync(user, model.NewMainCurrencyCode);
        user.MainCurrency = model.NewMainCurrencyCode;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        _unitOfWork.SaveAsync().GetAwaiter().GetResult();
    }

    public Task<decimal> GetUserAmountAsync(string userName)
    {
        return _unitOfWork.UserRepository.GetUserAmountAsync(userName);
    }

    public async Task PutUserAmountAsync(string userName, decimal userAmount)
    {
        await _unitOfWork.UserRepository.UpdateAmountAsync(userName, userAmount);
        _unitOfWork.SaveAsync().GetAwaiter().GetResult();
    }

    public Task<CurrencyCode> GetUserMainCurrencyAsync(string userName)
    {
        return _unitOfWork.UserRepository.GetUserMainCurrencyAsync(userName);
    }

    public async Task<UserStatisticsDTO> GetUserStatisticsAsync(string userName)
    {
        var user =
            await _unitOfWork.UserRepository.GetWithStatisticsByNameAsync(
                userName);

        var userStatisticsDTO = _mapper.Map<UserStatisticsDTO>(user);

        var currencyRates = await _currencyService.GetAllRatesToCurrencyAsync(
            user.Id,
            user.MainCurrency);

        userStatisticsDTO.SpendingCategories
            .Where(sc => sc.Spendings?.Count > 0)
            .ToList()
            .ForEach(sc => sc.SpendAmount = CalculateTotalSpend(
                sc.Spendings,
                currencyRates));

        return userStatisticsDTO;
    }

    private async Task RecalculateUserAmountAsync(
        User user, CurrencyCode toCurrency)
    {
        var currencyRate = await _currencyService.GetCurrencyRateAsync(
            user.Id,
            user.MainCurrency,
            toCurrency);

        user.Amount *= (decimal)currencyRate.Rate;
    }

    private static decimal CalculateTotalSpend(
        IEnumerable<SpendingDTO> spendings,
        List<BaseCurrencyRate> currencyRates)
    {
        var total = 0m;

        foreach (var spending in spendings)
        {
            var matchedRate = currencyRates.Find(
                ucr => ucr.FromCurrency == spending.Currency);

            total += spending.Amount * (decimal)matchedRate.Rate;
        }

        return total;
    }
}
