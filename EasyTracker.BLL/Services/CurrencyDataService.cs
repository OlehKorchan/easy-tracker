using System.Globalization;
using EasyTracker.BLL.Config;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models.ML;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.TimeSeries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyTracker.BLL.Services;

public class CurrencyDataService : ICurrencyDataService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Settings _settings;

    public CurrencyDataService(IUnitOfWork unitOfWork, IOptions<Settings> settings)
    {
        _unitOfWork = unitOfWork;
        _settings = settings.Value;
    }

    public async Task UpdateDataAsync()
    {
        await ClearTable();
        var rawData = LoadJson();
        var inputData = new List<ModelInput>();

        foreach (var item in rawData)
        {
            if (ValidateObjectNotEmpty(item))
            {
                inputData.Add(ModelFromData(item));
            }
        }

        await _unitOfWork.CurrencyDataRepository.CreateManyAsync(inputData);
        await _unitOfWork.SaveAsync();
    }

    public Task<IEnumerable<PredictionResultDTO>> Process()
    {
        var mlContext = new MLContext();

        var loader = mlContext.Data.CreateDatabaseLoader<ModelInputDto>();

        var query = @"SELECT Date, CAST(RateUsdToUah AS REAL) AS RateUsdToUah FROM ModelInput";

        var dbSource = new DatabaseSource(
            SqlClientFactory.Instance,
            _settings.DefaultConnection,
            query);

        var dataView = loader.Load(dbSource);

        var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
            "PredictedRates",
            "RateUsdToUah",
            7,
            30,
            365 * 13,
            7,
            confidenceLevel: 0.95f,
            confidenceLowerBoundColumn: "LowerBoundRates",
            confidenceUpperBoundColumn: "UpperBoundRates");

        var forecaster = forecastingPipeline.Fit(dataView);

        var modelPath = MlSettings.GetModelPath();

        var forecastEngine =
            forecaster.CreateTimeSeriesEngine<ModelInputDto, ModelOutputDTO>(mlContext);
        forecastEngine.CheckPoint(mlContext, modelPath);

        var forecast = forecastEngine.Predict();

        var lastDay = mlContext.Data.CreateEnumerable<ModelInputDto>(dataView, false).Last();

        var daysDifference = DateTime.UtcNow.Subtract(lastDay.Date).Days;
        lastDay.Date = lastDay.Date.AddDays(daysDifference);

        var nextWeek = new List<DateTime>
        {
            lastDay.Date.AddDays(1),
            lastDay.Date.AddDays(2),
            lastDay.Date.AddDays(3),
            lastDay.Date.AddDays(4),
            lastDay.Date.AddDays(5),
            lastDay.Date.AddDays(6),
            lastDay.Date.AddDays(7),
        };

        var forecastOutput = nextWeek
            .Select(
                (rental, index) =>
                {
                    var predictionDate = rental.Date.ToShortDateString();
                    var lowerEstimate = Math.Max(0, forecast.LowerBoundRates[index]);
                    var estimate = forecast.PredictedRates[index];
                    var upperEstimate = forecast.UpperBoundRates[index];
                    return new PredictionResultDTO
                    {
                        Date = DateTime.Parse(predictionDate),
                        LowerBound = lowerEstimate,
                        Prediction = estimate,
                        UpperBound = upperEstimate,
                    };
                });

        return Task.FromResult(forecastOutput);
    }

    private async Task ClearTable()
    {
        await _unitOfWork.CurrencyDataRepository.ClearTable();
        await _unitOfWork.SaveAsync();
    }

    private static bool ValidateObjectNotEmpty(JObject item)
    {
        return item[MlSettings.DateKey] != null &&
               item[MlSettings.PriceKey] != null &&
               item[MlSettings.AmountKey] != null;
    }

    private static ModelInput ModelFromData(JObject item)
    {
        return new ModelInput
        {
            Date = DateTime.Parse(ValueFromJObject(item, MlSettings.DateKey)),
            RateUsdToUah = float.Parse(
                               ValueFromJObject(item, MlSettings.PriceKey),
                               CultureInfo.InvariantCulture) /
                           float.Parse(
                               ValueFromJObject(item, MlSettings.AmountKey),
                               CultureInfo.InvariantCulture),
        };
    }

    private static string ValueFromJObject(JObject item, string key)
    {
        return item[key].Value<string>();
    }


    private IEnumerable<JObject> LoadJson()
    {
        using var r = new StreamReader(MlSettings.GetLocalDataPath());
        var json = r.ReadToEnd();
        return JsonConvert.DeserializeObject<List<JObject>>(json);
    }
}
