namespace EasyTracker.DAL.Interfaces;

public interface IUnitOfWork
{
    public ISalaryRepository SalaryRepository { get; }
    public ISpendingCategoryRepository SpendingCategoryRepository { get; }
    public IMainSpendingCategoryRepository MainSpendingCategoryRepository { get; }
    public ISpendingRepository SpendingRepository { get; }
    public IUserRepository UserRepository { get; }
    public ICurrencyRateRepository CurrencyRateRepository { get; }
    public ICurrencyBalanceRepository CurrencyBalanceRepository { get; }
    public IBaseCurrencyRateRepository BaseCurrencyRateRepository { get; }

    Task SaveAsync();
}
