using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Enums;
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
            IUnitOfWork unitOfWork
        )
        {
            _spendingCategoryService = spendingCategoryService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> GetUserAsync(string userName)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);

            return new UserDTO { UserName = currentUser.UserName, Amount = currentUser.Amount };
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
            var mainCategories = await _spendingCategoryService.GetAllMainAsync();

            var currentUser = await _unitOfWork.UserRepository.GetByNameAsync(userName);

            var userBaseCategories = mainCategories.Select(
                c =>
                {
                    var newCategory = _mapper.Map<SpendingCategory>(c);
                    newCategory.UserId = currentUser.Id;
                    return newCategory;
                }
            );

            await _spendingCategoryService.CreateManyAsync(userBaseCategories);

            _unitOfWork.UserRepository.Update(currentUser);
            _unitOfWork.SaveAsync().GetAwaiter().GetResult();
        }

        public async Task UpdateMainCurrencyAsync(MainCurrencyRequestDTO model)
        {
            var userToUpdate = await _unitOfWork.UserRepository.GetByNameAsync(model.UserName);

            if (model.Recalculate) { }

            userToUpdate.MainCurrency = model.NewMainCurrencyCode;

            userToUpdate.Amount = await RecalculateAmountAsync(
                userToUpdate.Id,
                userToUpdate.Amount,
                userToUpdate.MainCurrency,
                model.NewMainCurrencyCode
            );

            _unitOfWork.SaveAsync().GetAwaiter().GetResult();
        }

        private async Task<decimal> RecalculateAmountAsync(
            string userId,
            decimal amount,
            CurrencyCode oldCurrency,
            CurrencyCode newCurrency
        )
        {
            BaseCurrencyRate currencyRate = await _unitOfWork.CurrencyRateRepository.GetAsync(
                userId,
                oldCurrency,
                newCurrency
            );

            if (currencyRate == null)
            {
                currencyRate = await _unitOfWork.BaseCurrencyRateRepository.GetAsync(
                    oldCurrency,
                    newCurrency
                );
            }

            if (oldCurrency == currencyRate.FromCurrency)
            {
                amount *= (decimal)currencyRate.Rate;
            }
            else
            {
                amount *= (decimal)currencyRate.ReverseRate;
            }

            return amount;
        }
    }
}
