using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly ISpendingCategoryService _spendingCategoryService;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UserService(
			ISpendingCategoryService spendingCategoryService,
			IMapper mapper,
			IUnitOfWork unitOfWork
		)
		{
			_spendingCategoryService = spendingCategoryService;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UserDTO> GetUserAsync(string userName)
		{
			var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);

			return new UserDTO { UserName = currentUser.UserName, Amount = currentUser.Amount };
		}

		public async Task AddAmountAsync(decimal amount, string userName)
		{
			await _unitOfWork.UserRepository.AddAmountAsync(userName, amount);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task InitializeBaseUserPropertiesAsync(string userName)
		{
			var mainCategories = await _spendingCategoryService.GetAllMainAsync();

			var userId = await _unitOfWork.UserRepository.GetUserIdByNameAsync(userName);

			var userBaseCategories = mainCategories.Select(
				c =>
				{
					var newCategory = _mapper.Map<SpendingCategory>(c);
					newCategory.Id = Guid.Empty;
					newCategory.UserId = userId;
					return newCategory;
				}
			);

			var userMainCurrencyBalance = new CurrencyBalance
			{
				Currency = CurrencyCode.USD,
				UserId = userId
			};

			await _unitOfWork.CurrencyBalanceRepository.AddAsync(userMainCurrencyBalance);
			await _spendingCategoryService.CreateManyAsync(userBaseCategories);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task UpdateMainCurrencyAsync(MainCurrencyRequestDTO model)
		{
			if (model.Recalculate)
			{
				var user = await _unitOfWork.UserRepository.GetByNameAsync(model.UserName);
				var newAmount = await RecalculateAmountAsync(
					user.Id,
					user.Amount,
					user.MainCurrency,
					model.NewMainCurrencyCode
				);

				await _unitOfWork.UserRepository.UpdateAmountAsync(model.UserName, newAmount);
			}

			await _unitOfWork.UserRepository.UpdateMainCurrencyAsync(
				model.UserName,
				model.NewMainCurrencyCode
			);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		private async Task<decimal> RecalculateAmountAsync(
			string userId,
			decimal amount,
			CurrencyCode oldCurrency,
			CurrencyCode newCurrency
		)
		{
			BaseCurrencyRate currencyRate = await _unitOfWork.CurrencyRateRepository.GetAsync(
				userId,
				oldCurrency,
				newCurrency
			);

			if (currencyRate == null)
			{
				currencyRate = await _unitOfWork.BaseCurrencyRateRepository.GetAsync(
					oldCurrency,
					newCurrency
				);
			}

			if (currencyRate == null)
			{
				return amount;
			}

			if (oldCurrency == currencyRate.FromCurrency)
			{
				amount *= (decimal)currencyRate.Rate;
			}
			else
			{
				amount *= (decimal)currencyRate.ReverseRate;
			}

			return amount;
		}

		public Task<decimal> GetUserAmountAsync(string userName)
		{
			return _unitOfWork.UserRepository.GetUserAmountAsync(userName);
		}

		public Task<CurrencyCode> GetUserMainCurrencyAsync(string userName)
		{
			return _unitOfWork.UserRepository.GetUserMainCurrencyAsync(userName);
		}

		public async Task<UserStatisticsDTO> GetUserStatisticsAsync(string userName)
		{
			var user = await _unitOfWork.UserRepository.GetWithStatisticsByNameAsync(userName);

			var userStatisticsDTO = _mapper.Map<UserStatisticsDTO>(user);
			userStatisticsDTO.Salaries = _mapper.Map<List<SalaryDTO>>(user.Salaries);
			userStatisticsDTO.SpendingCategories = _mapper.Map<List<SpendingCategoryGetDTO>>(
				user.SpendingCategories
			);

			var userCurrencyRates = await _unitOfWork.CurrencyRateRepository.GetAsync(
				user.Id,
				user.MainCurrency
			);
			var baseCurrencyRates = await _unitOfWork.BaseCurrencyRateRepository.GetAsync(
				user.MainCurrency
			);

			userStatisticsDTO.SpendingCategories
				.Where(sc => sc.Spendings?.Count > 0)
				.ToList()
				.ForEach(
					sc =>
					{
						var amount = 0m;

						foreach (var spending in sc.Spendings)
						{
							BaseCurrencyRate matchedRate = userCurrencyRates.Find(
								ucr =>
									ucr.FromCurrency == spending.Currency
									|| ucr.ToCurrency == spending.Currency
							);

							if (matchedRate == null)
							{
								matchedRate = baseCurrencyRates.Find(
									bcr =>
										bcr.FromCurrency == spending.Currency
										|| bcr.ToCurrency == spending.Currency
								);
							}

							var rate =
								matchedRate == null
									? 1m
									: (decimal)(
										  matchedRate.FromCurrency == user.MainCurrency
											  ? matchedRate.ReverseRate
											  : matchedRate.Rate
									  );

							amount += spending.Amount * rate;
						}

						sc.SpendAmount = amount;
					}
				);

			userStatisticsDTO.CurrencyBalances = _mapper.Map<List<CurrencyBalanceDTO>>(
				user.CurrencyBalances
			);

			return userStatisticsDTO;
		}
	}
}
