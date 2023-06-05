using System.Text.Json;
using EasyTracker.API.Config;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace EasyTracker.BLL.Services;

public class CurrencyService : ICurrencyService
{
    private readonly RestClient _httpClient;
    private readonly CurrencyAPISettings _currencyApiSettings;

    public CurrencyService(IOptions<CurrencyAPISettings> currencyApiSettings)
    {
        _currencyApiSettings = currencyApiSettings.Value;
        _httpClient = new RestClient(_currencyApiSettings.BaseAddress);
    }

    public async Task<List<BaseCurrencyRate>> GetAllRatesToCurrencyAsync(
        string userId,
        CurrencyCode currency)
    {
        var request = new RestRequest(
            _currencyApiSettings.CurrencyRateUrl +
            $"?base={currency}&symbols={CurrencyCode.EUR},{CurrencyCode.GBP},{CurrencyCode.UAH},{CurrencyCode.USD}");
        request.AddHeader("apiKey", _currencyApiSettings.ApiKey);

        var response = await _httpClient.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var rates = JsonSerializer.Deserialize<CurrencyAPIResponse>(
                response.Content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
            var result = new List<BaseCurrencyRate>
            {
                new()
                {
                    FromCurrency = CurrencyCode.UAH,
                    ToCurrency = currency,
                    Rate = 1 / rates.Rates[CurrencyCode.UAH.ToString()],
                },
                new()
                {
                    FromCurrency = CurrencyCode.GBP,
                    ToCurrency = currency,
                    Rate = 1 / rates.Rates[CurrencyCode.GBP.ToString()],
                },
                new()
                {
                    FromCurrency = CurrencyCode.USD,
                    ToCurrency = currency,
                    Rate = 1 / rates.Rates[CurrencyCode.USD.ToString()],
                },
                new()
                {
                    FromCurrency = CurrencyCode.EUR,
                    ToCurrency = currency,
                    Rate = 1 / rates.Rates[CurrencyCode.EUR.ToString()],
                },
            };

            return result;
        }

        return new List<BaseCurrencyRate>();
    }

    public async Task<BaseCurrencyRate> GetCurrencyRateAsync(
        CurrencyCode fromCurrency,
        CurrencyCode toCurrency)
    {
        var request = new RestRequest(
            _currencyApiSettings.CurrencyRateUrl +
            $"?base={fromCurrency}&symbols={toCurrency}");
        request.AddHeader("apiKey", _currencyApiSettings.ApiKey);

        var response = await _httpClient.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var rates = JsonSerializer.Deserialize<CurrencyAPIResponse>(
                response.Content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

            return new BaseCurrencyRate
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Rate = rates.Rates[toCurrency.ToString()],
            };
        }

        return null;
    }
}
