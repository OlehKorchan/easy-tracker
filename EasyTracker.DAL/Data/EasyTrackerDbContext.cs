using EasyTracker.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Data
{
    public class EasyTrackerDbContext : IdentityDbContext<User>
    {
        public EasyTrackerDbContext(DbContextOptions<EasyTrackerDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Salary>();
            builder.Entity<Saving>();
            builder.Entity<SpendingCategory>();
            builder.Entity<Spending>();
            builder.Entity<CurrencyRate>();
            builder.Entity<BaseCurrencyRate>().HasData(GetBaseCurrencyRates());

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

            builder.Entity<MainSpendingCategory>().HasData(GetMainSpendingCategories());

            base.OnModelCreating(builder);
        }

        private static IEnumerable<BaseCurrencyRate> GetBaseCurrencyRates() =>
            new List<BaseCurrencyRate>
            {
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.USD,
                    Rate = 0.034,
                    ReverseRate = 29.50
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.EUR,
                    Rate = 0.032,
                    ReverseRate = 31.59
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.027,
                    ReverseRate = 36.95
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.027,
                    ReverseRate = 36.95
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.USD,
                    ToCurrency = Enums.CurrencyCode.EUR,
                    Rate = 0.93,
                    ReverseRate = 1.07
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.USD,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.8,
                    ReverseRate = 1.25
                },
                new()
                {
                    Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                    FromCurrency = Enums.CurrencyCode.EUR,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.85,
                    ReverseRate = 1.17
                }
            };

        private static IEnumerable<MainSpendingCategory> GetMainSpendingCategories() =>
            new List<MainSpendingCategory>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Food",
                    Description = string.Empty,
                    ImageSrc =
                        "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Transport",
                    Description = string.Empty,
                    ImageSrc =
                        "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w"
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
