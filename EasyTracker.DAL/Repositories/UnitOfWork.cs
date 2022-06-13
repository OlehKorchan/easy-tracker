using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;

namespace EasyTracker.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EasyTrackerDbContext _dbContext;
		private ISalaryRepository _salaryRepository;
		private ISpendingRepository _spendingRepository;
		private IMainSpendingCategoryRepository _mainSpendingCategoryRepository;
		private ISpendingCategoryRepository _spendingCategoryRepository;
		private IUserRepository _userRepository;
		private ICurrencyRateRepository _currencyRateRepository;
		private IBaseCurrencyRateRepository _baseCurrencyRateRepository;
		private ICurrencyBalanceRepository _currencyBalanceRepository;

		public UnitOfWork(EasyTrackerDbContext dbContext) => _dbContext = dbContext;

		public ISalaryRepository SalaryRepository =>
			_salaryRepository ??= new SalaryRepository(_dbContext);

		public ISpendingCategoryRepository SpendingCategoryRepository =>
			_spendingCategoryRepository ??= new SpendingCategoryRepository(_dbContext);

		public IMainSpendingCategoryRepository MainSpendingCategoryRepository =>
			_mainSpendingCategoryRepository ??= new MainSpendingCategoryRepository(_dbContext);

		public ISpendingRepository SpendingRepository =>
			_spendingRepository ??= new SpendingRepository(_dbContext);

		public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

		public ICurrencyRateRepository CurrencyRateRepository =>
			_currencyRateRepository ??= new CurrencyRateRepository(_dbContext);

		public IBaseCurrencyRateRepository BaseCurrencyRateRepository =>
			_baseCurrencyRateRepository ??= new BaseCurrencyRateRepository(_dbContext);

		public ICurrencyBalanceRepository CurrencyBalanceRepository =>
			_currencyBalanceRepository ??= new CurrencyBalanceRepository(_dbContext);

		public Task SaveAsync() => _dbContext.SaveChangesAsync();
	}
}
