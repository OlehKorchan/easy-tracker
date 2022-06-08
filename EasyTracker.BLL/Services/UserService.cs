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

            if (model.Recalculate)
            {
                userToUpdate.Amount = await RecalculateAmountAsync(
                    userToUpdate.Id,
                    userToUpdate.Amount,
                    userToUpdate.MainCurrency,
                    model.NewMainCurrencyCode
                );
            }

            userToUpdate.MainCurrency = model.NewMainCurrencyCode;

            _unitOfWork.UserRepository.Update(userToUpdate);
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

            if (currencyRate == null)
            {
                return amount;
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

        public Task<decimal> GetUserAmountAsync(string userName)
        {
            return _unitOfWork.UserRepository.GetUserAmountAsync(userName);
        }

        public Task<CurrencyCode> GetUserMainCurrencyAsync(string userName)
        {
            return _unitOfWork.UserRepository.GetUserMainCurrencyAsync(userName);
        }

        public async Task<UserStatisticsDTO> GetUserStatisticsAsync(string userName)
        {
            var user = await _unitOfWork.UserRepository.GetByNameAsync(userName);

            var userStatisticsDTO = _mapper.Map<UserStatisticsDTO>(user);
            userStatisticsDTO.Salaries = _mapper.Map<List<SalaryDTO>>(user.Salaries);
            userStatisticsDTO.SpendingCategories = _mapper.Map<List<SpendingCategoryGetDTO>>(
                user.SpendingCategories
            );

            return userStatisticsDTO;
        }
    }
}
