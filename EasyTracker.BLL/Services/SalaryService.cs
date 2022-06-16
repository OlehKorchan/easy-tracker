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

			var userId = await _unitOfWork.UserRepository.GetUserIdByNameAsync(salary.UserName);

			if (!string.Equals(userId, salaryToDelete.UserId, comparisonType: StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException();
			}

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
	}
}
