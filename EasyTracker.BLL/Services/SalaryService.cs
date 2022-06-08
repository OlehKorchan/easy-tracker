using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SalaryService : ISalaryService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		private readonly IUserService userService;

		public SalaryService(
			IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			this.userService = userService;
		}

		public async Task AddAsync(SalaryDTO salary)
		{
			var userId = (await unitOfWork
				.UserRepository.GetByNameAsync(salary.UserName)).Id;

			var salary = new Salary
			{
				Amount = salary.Amount,
				Comment = salary.Comment,
				UserId = userId,
				DateAdded = DateTime.UtcNow
			};

			await unitOfWork.SalaryRepository.AddAsync(salary);

			await userService.AddAmountAsync(salary.Amount, salary.UserName);

			unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task DeleteAsync(SalaryDTO salary)
		{
			var salaryToDelete = await unitOfWork
				.SalaryRepository.GetAsync(salary.Id);

			var user = await unitOfWork.UserRepository.GetByNameAsync(salary.UserName);

			if (!string.Equals(user.Id, salaryToDelete.UserId, StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			await unitOfWork.SalaryRepository.DeleteAsync(salaryToDelete.Id);
			user.Amount -= salaryToDelete.Amount;
			if (user.Amount < 0)
			{
				user.Amount = 0;
			}
			unitOfWork.UserRepository.Update(user);

			unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task<SalaryDTO> GetAsync(Guid salaryId)
		{
			var salary = await unitOfWork
				.SalaryRepository.GetAsync(salaryId);

			return mapper.Map<Salary, SalaryDTO>(salary);
		}

		public async Task<List<SalaryDTO>> GetAllUserSalariesAsync(string userName)
		{
			var userId = (await unitOfWork.UserRepository.GetByNameAsync(userName)).Id;

			var salaries = await unitOfWork
				.SalaryRepository.GetAllAsync(userId);

			return mapper.Map<List<Salary>, List<SalaryDTO>>(salaries);
		}
	}
}
