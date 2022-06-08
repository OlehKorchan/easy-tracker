using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
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
			IUnitOfWork unitOfWork)
		{
			_spendingCategoryService = spendingCategoryService;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UserDTO> GetUserAsync(string userName)
		{
			var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);

			return new UserDTO
			{
				UserName = currentUser.UserName,
				Amount = currentUser.Amount
			};
		}

		public async Task AddAmountAsync(decimal amount, string userName)
		{
			var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);
			currentUser.Amount += amount;

			_unitOfWork.UserRepository.Update(currentUser);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task AddMainCategoriesAsync(string userName)
		{
			var mainCategories = await _spendingCategoryService
				.GetAllMainAsync();

			var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);

			var userBaseCategories = mainCategories
				.Select(c =>
				{
					var newCategory = _mapper.Map<SpendingCategory>(c);
					newCategory.UserId = currentUser.Id;
					return newCategory;
				});

			await _spendingCategoryService.CreateManyAsync(userBaseCategories);

			_unitOfWork.UserRepository.Update(currentUser);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}
	}
}
