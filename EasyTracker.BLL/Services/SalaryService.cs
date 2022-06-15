using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SalaryService : ISalaryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SalaryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task AddAsync(SalaryDTO salaryDto)
		{
			var salary = _mapper.Map<Salary>(salaryDto);
			salary.UserId = await _unitOfWork.UserRepository.GetUserIdByNameAsync(salaryDto.UserName);
			salary.DateAdded = DateTime.UtcNow;

			await _unitOfWork.SalaryRepository.AddAsync(salary);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task DeleteAsync(SalaryDTO salary)
		{
			var salaryToDelete = await _unitOfWork.SalaryRepository.GetAsync(salary.Id);

			var user = await _unitOfWork.UserRepository.GetByNameAsync(salary.UserName);

			if (!string.Equals(user.Id, salaryToDelete.UserId, StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			await UpdateUserCurrencyBalanceAsync(user,
				salaryToDelete.Currency,
				-salaryToDelete.Amount);

			await _unitOfWork.SalaryRepository.DeleteAsync(salaryToDelete.Id);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task<SalaryDTO> GetAsync(Guid salaryId)
		{
			var salary = await _unitOfWork.SalaryRepository.GetAsync(salaryId);

			return _mapper.Map<Salary, SalaryDTO>(salary);
		}

		public async Task<List<SalaryDTO>> GetAllUserSalariesAsync(string userName)
		{
			var userId = (await _unitOfWork.UserRepository.GetByNameAsync(userName)).Id;

			var salaries = await _unitOfWork.SalaryRepository.GetAllAsync(userId);

			return _mapper.Map<List<Salary>, List<SalaryDTO>>(salaries);
		}

		private async Task UpdateUserCurrencyBalanceAsync(
			User user,
			CurrencyCode currency,
			decimal amount
		)
		{
			var currencyBalance = await _unitOfWork.CurrencyBalanceRepository.GetAsync(
				user.Id,
				currency
			);

			if (currencyBalance == null)
			{
				var newCurrencyBalance = new CurrencyBalance
				{
					Amount = amount > 0 ? amount : 0,
					UserId = user.Id
				};

				_unitOfWork.CurrencyBalanceRepository
					.AddAsync(newCurrencyBalance)
					.GetAwaiter()
					.GetResult();
			}
			else
			{
				currencyBalance.Amount += amount;
				if (currencyBalance.Amount < 0)
				{
					currencyBalance.Amount = 0;
				}

				_unitOfWork.CurrencyBalanceRepository
					.UpdateAmountAsync(currencyBalance.Id, currencyBalance.Amount)
					.GetAwaiter()
					.GetResult();
			}
		}
	}
}
