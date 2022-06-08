using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SalaryService : ISalaryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public SalaryService(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IUserService userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_userService = userService;
		}

		public async Task AddAsync(SalaryDTO salaryDto)
		{
			var userId = (await _unitOfWork
				.UserRepository.GetByNameAsync(salaryDto.UserName)).Id;

			var salary = new Salary
			{
				Amount = salaryDto.Amount,
				Comment = salaryDto.Comment,
				UserId = userId,
				DateAdded = DateTime.UtcNow
			};

			await _unitOfWork.SalaryRepository.AddAsync(salary);

			await _userService
				.AddAmountAsync(
					salary.Amount, salaryDto.UserName);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task DeleteAsync(SalaryDTO salary)
		{
			var salaryToDelete = await _unitOfWork
				.SalaryRepository.GetAsync(salary.Id);

			var user = await _unitOfWork
				.UserRepository.GetByNameAsync(salary.UserName);

			if (!string.Equals(
				user.Id, salaryToDelete.UserId,
				StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			await _unitOfWork.SalaryRepository
				.DeleteAsync(salaryToDelete.Id);

			user.Amount -= salaryToDelete.Amount;
			if (user.Amount < 0)
			{
				user.Amount = 0;
			}
			_unitOfWork.UserRepository.Update(user);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task<SalaryDTO> GetAsync(Guid salaryId)
		{
			var salary = await _unitOfWork
				.SalaryRepository.GetAsync(salaryId);

			return _mapper.Map<Salary, SalaryDTO>(salary);
		}

		public async Task<List<SalaryDTO>> GetAllUserSalariesAsync(
			string userName)
		{
			var userId = (await _unitOfWork.UserRepository
				.GetByNameAsync(userName)).Id;

			var salaries = await _unitOfWork
				.SalaryRepository.GetAllAsync(userId);

			return _mapper.Map<List<Salary>, List<SalaryDTO>>(salaries);
		}
	}
}
