using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Data
{
	public class EasyTrackerDbContext : IdentityDbContext<User>
	{
		public EasyTrackerDbContext(DbContextOptions<EasyTrackerDbContext> dbContextOptions)
			: base(dbContextOptions) { }

		public DbSet<Salary> Salaries { get; set; }

		public DbSet<Saving> Savings { get; set; }

		public DbSet<SpendingCategory> SpendingCategories { get; set; }

		public DbSet<MainSpendingCategory> MainSpendingCategories { get; set; }

		public DbSet<Spending> Spendings { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<User>()
				.HasMany(u => u.SpendingCategories)
				.WithOne(sc => sc.User)
				.HasForeignKey(sc => sc.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.Entity<User>()
				.HasMany(u => u.Salaries)
				.WithOne(sc => sc.User)
				.HasForeignKey(sc => sc.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.Entity<User>()
				.HasMany(u => u.Savings)
				.WithOne(sc => sc.User)
				.HasForeignKey(sc => sc.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.Entity<MainSpendingCategory>()
				.HasData(GetMainSpendingCategories());

			base.OnModelCreating(builder);
		}

		private static IEnumerable<MainSpendingCategory> GetMainSpendingCategories()
		{
			return new List<MainSpendingCategory>
			{
				new()
				{
					Id = Guid.NewGuid(),
					CategoryName = "Food",
					Description = string.Empty,
					ImageSrc = "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg"
				},
				new()
				{
					Id = Guid.NewGuid(),
					CategoryName = "Transport",
					Description = string.Empty,
					ImageSrc = "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w"
				},
				new()
				{
					Id = Guid.NewGuid(),
					CategoryName = "Health",
					Description = string.Empty,
					ImageSrc = "https://pic.onlinewebfonts.com/svg/img_445017.png"
				}
			};
		}
	}
}