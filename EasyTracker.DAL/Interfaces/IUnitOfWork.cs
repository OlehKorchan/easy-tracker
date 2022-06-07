namespace EasyTracker.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		public ISalaryRepository SalaryRepository { get; }
		public ISpendingCategoryRepository SpendingCategoryRepository { get; }
		public IMainSpendingCategoryRepository MainSpendingCategoryRepository { get; }
		public ISpendingRepository SpendingRepository { get; }
		public IUserRepository UserRepository { get; }

		Task SaveAsync();
	}
}