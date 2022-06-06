using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyTracker.BLL.Services
{
	public class SpendingCategoryService : ISpendingCategoryService
	{
		private readonly ISpendingCategoryRepository _repository;
		private readonly IMainSpendingCategoryRepository _mainCategoriesRepo;
		private readonly UserManager<User> _userManager;

		public SpendingCategoryService(
			ISpendingCategoryRepository repository,
			UserManager<User> userManager,
			IMainSpendingCategoryRepository mainCategoriesRepo)
		{
			_repository = repository;
			_userManager = userManager;
			_mainCategoriesRepo = mainCategoriesRepo;
		}

		public Task<List<MainSpendingCategory>> GetAllMainAsync()
		{
			return _mainCategoriesRepo.GetAllAsync();
		}

		public Task<MainSpendingCategory> GetMainAsync(Guid categoryId)
		{
			return _mainCategoriesRepo.GetAsync(categoryId);
		}

		public async Task<SpendingCategoryGetDTO> GetAsync(Guid categoryId)
		{
			var spendingCategory = await _repository.GetAsync(categoryId);

			var image = LoadImageFromFileSystem(spendingCategory.ImageSrc);

			return new SpendingCategoryGetDTO
			{
				Id = spendingCategory.Id,
				CategoryName = spendingCategory.CategoryName,
				Description = spendingCategory.Description,
				Image = image
			};
		}

		public async Task<List<SpendingCategoryGetDTO>> GetAllAsync()
		{
			var spendingCategories = await _repository.GetAllAsync();

			return spendingCategories
				.Select(spendingCategory => new SpendingCategoryGetDTO
				{
					CategoryName = spendingCategory.CategoryName,
					Description = spendingCategory.Description,
					Id = spendingCategory.Id,
					ImageSrc = spendingCategory.ImageSrc
				})
				.ToList();
		}

		public async Task CreateAsync(SpendingCategoryPostDTO spendingCategory)
		{
			var currentUserId = (await _userManager.FindByNameAsync(spendingCategory.UserName)).Id;

			var categoryToCreate = new SpendingCategory
			{
				CategoryName = spendingCategory.CategoryName,
				Description = spendingCategory.Description,
				ImageSrc = spendingCategory.ImageSrc,
				UserId = currentUserId
			};

			await _repository.AddAsync(categoryToCreate);
		}

		public async Task DeleteAsync(SpendingCategoryPostDTO spendingCategory)
		{
			var currentUser = await _userManager.FindByNameAsync(spendingCategory.UserName);

			var spendingCategoryToDelete = await _repository.GetAsync(spendingCategory.Id);

			if (!string.Equals(currentUser.Id, spendingCategoryToDelete.UserId, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			await _repository.DeleteAsync(spendingCategoryToDelete);
		}

		private static byte[] LoadImageFromFileSystem(string imagePath)
		{
			//TODO implement image loading logic
			return new byte[]{0};
		}
	}
}