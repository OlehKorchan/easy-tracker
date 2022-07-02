using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services;

public class CurrencyService : ICurrencyService
{
    private readonly IUnitOfWork _unitOfWork;

    public CurrencyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BaseCurrencyRate>> GetAllCurrencyRatesAsync(string userId)
    {
        var rates = await _unitOfWork.CurrencyRateRepository.GetAllUserRatesAsync(userId);

        var baseRates = await _unitOfWork.BaseCurrencyRateRepository.GetAllRatesAsync();

        return MergeCurrencyRates(baseRates, rates);
    }

    public async Task<List<BaseCurrencyRate>> GetAllRatesFromCurrencyAsync(string userId, CurrencyCode currency)
    {
        var rates = await _unitOfWork
            .CurrencyRateRepository
            .GetRatesFromCurrencyAsync(userId, currency);

        var baseRates = await _unitOfWork
            .BaseCurrencyRateRepository
            .GetRateFromCurrencyAsync(currency);

        return MergeCurrencyRates(baseRates, rates);
    }

    public async Task<List<BaseCurrencyRate>> GetAllRatesToCurrencyAsync(string userId, CurrencyCode currency)
    {
        var rates = await _unitOfWork
            .CurrencyRateRepository
            .GetRatesToCurrencyAsync(userId, currency);

        var baseRates = await _unitOfWork
            .BaseCurrencyRateRepository
            .GetRateToCurrencyAsync(currency);

        return MergeCurrencyRates(baseRates, rates);
    }

    public async Task<BaseCurrencyRate> GetCurrencyRateAsync(
        string userId,
        CurrencyCode fromCurrency,
        CurrencyCode toCurrency)
    {
        var userRate = await _unitOfWork
            .CurrencyRateRepository
            .GetUserRateAsync(userId, fromCurrency, toCurrency);

        return userRate ?? _unitOfWork
            .BaseCurrencyRateRepository
            .GetRateAsync(fromCurrency, toCurrency)
            .GetAwaiter()
            .GetResult();
    }

    private static List<BaseCurrencyRate> MergeCurrencyRates(
        List<BaseCurrencyRate> baseRates,
        List<CurrencyRate> userRates)
    {
        return baseRates.ConvertAll(br =>
        {
            var fromUserRates = userRates?.Find(
                r =>
                    r.FromCurrency == br.FromCurrency
                    && r.ToCurrency == br.ToCurrency);

            return fromUserRates ?? br;
        });
    }
}
