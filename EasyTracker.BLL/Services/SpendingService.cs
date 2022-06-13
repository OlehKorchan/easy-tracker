using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Exceptions;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SpendingService : ISpendingService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SpendingService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task AddAsync(SpendingDTO spendingDto)
		{
			var category = await _unitOfWork.SpendingCategoryRepository.GetAsync(
				spendingDto.SpendingCategoryId
			);

			var currencyBalance = await _unitOfWork.CurrencyBalanceRepository.GetAsync(
				category.UserId,
				spendingDto.Currency
			);

			if (currencyBalance == null)
			{
				throw new NoSuchCurrencyBalanceException(spendingDto.Currency.ToString());
			}

			currencyBalance.Amount -= spendingDto.Amount;

			BaseCurrencyRate currencyRate = await _unitOfWork.CurrencyRateRepository.GetAsync(
				category.UserId,
				spendingDto.Currency,
				category.User.MainCurrency
			);

			if (currencyRate == null)
			{
				currencyRate = await _unitOfWork.BaseCurrencyRateRepository.GetAsync(
					category.User.MainCurrency,
					spendingDto.Currency
				);
			}

			var rate = 1m;

			if (currencyRate != null)
			{
				rate = (decimal)(
					currencyRate.FromCurrency == category.User.MainCurrency
						? currencyRate.ReverseRate
						: currencyRate.Rate
				);
			}

			category.User.Amount -= spendingDto.Amount * rate;

			await _unitOfWork.CurrencyBalanceRepository.UpdateAmountAsync(
				currencyBalance.Id,
				currencyBalance.Amount
			);

			await _unitOfWork.UserRepository.UpdateAmountAsync(
				category.User.UserName,
				category.User.Amount
			);

			await _unitOfWork.SpendingRepository.AddAsync(_mapper.Map<Spending>(spendingDto));

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public Task DeleteAsync(SpendingDTO spendingDto)
		{
			_unitOfWork.SpendingRepository.Delete(_mapper.Map<Spending>(spendingDto));

			return _unitOfWork.SaveAsync();
		}

		public async Task<SpendingDTO> GetAsync(Guid id) =>
			_mapper.Map<SpendingDTO>(await _unitOfWork.SpendingRepository.GetAsync(id));
	}
}
