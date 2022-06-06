using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyTracker.BLL.Services
{
	public class SalaryService : ISalaryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		private readonly IUserService _userService;

		public SalaryService(
			IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IUserService userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_userManager = userManager;
			_userService = userService;
		}

		public async Task AddAsync(SalaryDTO salaryDto)
		{
			var userId = (await _userManager.FindByNameAsync(salaryDto.UserName)).Id;

			var salary = new Salary
			{
				Amount = salaryDto.Amount,
				Comment = salaryDto.Comment,
				UserId = userId,
				DateAdded = DateTime.UtcNow
			};

			await _unitOfWork.SalaryRepository.AddAsync(salary);

			await _userService
				.AddAmountAsync(salary.Amount, salaryDto.UserName);

			_unitOfWork.SaveAsync().GetAwaiter();
		}

		public async Task DeleteAsync(SalaryDTO salary)
		{
			var salaryToDelete = await _unitOfWork
				.SalaryRepository.GetAsync(salary.Id);

			var user = await _userManager.FindByNameAsync(salary.UserName);

			if (!string.Equals(user.Id, salaryToDelete.UserId, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			_unitOfWork.SalaryRepository.Delete(salaryToDelete);
			user.Amount -= salaryToDelete.Amount;
			await _userManager.UpdateAsync(user);

			_unitOfWork.SaveAsync().GetAwaiter();
		}

		public async Task<SalaryDTO> GetAsync(Guid salaryId)
		{
			var salary = await _unitOfWork
				.SalaryRepository.GetAsync(salaryId);

			return _mapper.Map<Salary, SalaryDTO>(salary);
		}

		public async Task<List<SalaryDTO>> GetAllUserSalariesAsync(string userName)
		{
			var userId = (await _userManager.FindByNameAsync(userName)).Id;

			var salaries = await _unitOfWork
				.SalaryRepository.GetAllAsync(userId);

			return _mapper.Map<List<Salary>, List<SalaryDTO>>(salaries);
		}
	}
}