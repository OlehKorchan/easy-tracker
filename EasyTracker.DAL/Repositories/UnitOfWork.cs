using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;

namespace EasyTracker.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private ISalaryRepository _salaryRepository;
		private ISpendingCategoryRepository _spendingCategoryRepository;
		private ISpendingRepository _spendingRepository;
		private IMainSpendingCategoryRepository _mainSpendingCategoryRepository;
		private readonly EasyTrackerDbContext _dbContext;

		public UnitOfWork(EasyTrackerDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ISalaryRepository SalaryRepository
		{
			get
			{
				return _salaryRepository ??= new SalaryRepository(_dbContext);
			}
		}

		public ISpendingCategoryRepository SpendingCategoryRepository
		{
			get
			{
				return _spendingCategoryRepository ??= new SpendingCategoryRepository(_dbContext);
			}
		}

		public IMainSpendingCategoryRepository MainSpendingCategoryRepository
		{
			get
			{
				return _mainSpendingCategoryRepository ??= new MainSpendingCategoryRepository(_dbContext);
			}
		}

		public ISpendingRepository SpendingRepository
		{
			get
			{
				return _spendingRepository ??= new SpendingRepository(_dbContext);
			}
		}

		public Task SaveAsync()
		{
			return _dbContext.SaveChangesAsync();
		}
	}
}