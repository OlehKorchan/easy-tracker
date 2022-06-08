using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SpendingCategoryService : ISpendingCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SpendingCategoryService(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Task<List<MainSpendingCategory>> GetAllMainAsync() => _unitOfWork.MainSpendingCategoryRepository.GetAllAsync();

		public Task<MainSpendingCategory> GetMainAsync(Guid categoryId) => _unitOfWork.MainSpendingCategoryRepository.GetAsync(categoryId);

		public async Task<SpendingCategoryGetDTO> GetAsync(Guid categoryId)
		{
			var spendingCategory = await _unitOfWork
				.SpendingCategoryRepository.GetAsync(categoryId);

			var categoryDto = _mapper
				.Map<SpendingCategoryGetDTO>(spendingCategory);

			categoryDto.Spendings = _mapper
				.Map<List<SpendingDTO>>(spendingCategory.Spendings);

			AddCategorySpendAmount(categoryDto);

			return categoryDto;
		}

		public async Task<List<SpendingCategoryGetDTO>> GetAllAsync()
		{
			var spendingCategories = await _unitOfWork
				.SpendingCategoryRepository.GetAllAsync();

			return spendingCategories
				.Select(spendingCategory =>
					{
						var categoryDto = _mapper
							.Map<SpendingCategoryGetDTO>(spendingCategory);

						categoryDto.Spendings = _mapper
							.Map<List<SpendingDTO>>(spendingCategory.Spendings);

						AddCategorySpendAmount(categoryDto);

						return categoryDto;
					})
				.ToList();
		}

		public async Task CreateAsync(SpendingCategoryPostDTO spendingCategory)
		{
			var currentUserId = (await _unitOfWork
				.UserRepository.GetByNameAsync(spendingCategory.UserName)).Id;

			var categoryToCreate = new SpendingCategory
			{
				CategoryName = spendingCategory.CategoryName,
				Description = spendingCategory.Description,
				ImageSrc = spendingCategory.ImageSrc,
				UserId = currentUserId
			};

			await _unitOfWork.SpendingCategoryRepository.AddAsync(categoryToCreate);

			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task CreateManyAsync(IEnumerable<SpendingCategory> spendingCategories)
		{
			await _unitOfWork.SpendingCategoryRepository.AddManyAsync(spendingCategories);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		public async Task DeleteAsync(SpendingCategoryPostDTO spendingCategory)
		{
			var currentUser = await _unitOfWork
				.UserRepository.GetByNameAsync(spendingCategory.UserName);

			var spendingCategoryToDelete = await _unitOfWork
				.SpendingCategoryRepository.GetAsync(spendingCategory.Id);

			if (!string.Equals(
					currentUser.Id, spendingCategoryToDelete.UserId,
					StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			await _unitOfWork.SpendingCategoryRepository.DeleteAsync(spendingCategoryToDelete.Id);
			_unitOfWork.SaveAsync().GetAwaiter().GetResult();
		}

		private static void AddCategorySpendAmount(SpendingCategoryGetDTO category) => category.SpendAmount = category.Spendings.Sum(sp => sp.Amount);
	}
}
