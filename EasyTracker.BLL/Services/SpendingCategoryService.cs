using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyTracker.BLL.Services
{
	public class SpendingCategoryService : ISpendingCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SpendingCategoryService(
			IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Task<List<MainSpendingCategory>> GetAllMainAsync()
		{
			return _unitOfWork.MainSpendingCategoryRepository.GetAllAsync();
		}

		public Task<MainSpendingCategory> GetMainAsync(Guid categoryId)
		{
			return _unitOfWork.MainSpendingCategoryRepository.GetAsync(categoryId);
		}

		public async Task<SpendingCategoryGetDTO> GetAsync(Guid categoryId)
		{
			var spendingCategory = await _unitOfWork
				.SpendingCategoryRepository.GetAsync(categoryId);

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
			var spendingCategories = await _unitOfWork
				.SpendingCategoryRepository.GetAllAsync();

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

			_unitOfWork.SaveAsync().GetAwaiter();
		}

		public async Task CreateManyAsync(IEnumerable<SpendingCategory> spendingCategory)
		{
			await _unitOfWork.SpendingCategoryRepository.AddManyAsync(spendingCategory);
			_unitOfWork.SaveAsync().GetAwaiter();
		}

		public async Task DeleteAsync(SpendingCategoryPostDTO spendingCategory)
		{
			var currentUser = await _unitOfWork
				.UserRepository.GetByNameAsync(spendingCategory.UserName);

			var spendingCategoryToDelete = await _unitOfWork
				.SpendingCategoryRepository.GetAsync(spendingCategory.Id);

			if (!string.Equals(
				    currentUser.Id, spendingCategoryToDelete.UserId,
				    StringComparison.InvariantCultureIgnoreCase))
			{
				throw new InvalidOperationException();
			}

			_unitOfWork.SpendingCategoryRepository.Delete(spendingCategoryToDelete);
			_unitOfWork.SaveAsync().GetAwaiter();
		}

		private static byte[] LoadImageFromFileSystem(string imagePath)
		{
			//TODO implement image loading logic
			return new byte[]{0};
		}
	}
}