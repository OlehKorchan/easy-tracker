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
            builder.Entity<SpendingCategory>();
            builder.Entity<MainSpendingCategory>().HasData(GetMainSpendingCategories());
            builder.Entity<Saving>();
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
                    Id = Guid.Parse("DD015F02-7BB5-426C-9787-92CDEC52ABE7"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.EUR,
                    Rate = 0.032,
                    ReverseRate = 31.59
                },
                new()
                {
                    Id = Guid.Parse("D6F50313-3B89-45AE-9A9D-3577EF0230C3"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.027,
                    ReverseRate = 36.95
                },
                new()
                {
                    Id = Guid.Parse("508B0DEC-789B-48DD-B782-3B384BB79FAD"),
                    FromCurrency = Enums.CurrencyCode.UAH,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.027,
                    ReverseRate = 36.95
                },
                new()
                {
                    Id = Guid.Parse("51EB5043-ECDE-4857-A27D-89AF00265485"),
                    FromCurrency = Enums.CurrencyCode.USD,
                    ToCurrency = Enums.CurrencyCode.EUR,
                    Rate = 0.93,
                    ReverseRate = 1.07
                },
                new()
                {
                    Id = Guid.Parse("725B5521-CA03-4109-B230-5F17A0EA99DD"),
                    FromCurrency = Enums.CurrencyCode.USD,
                    ToCurrency = Enums.CurrencyCode.GBP,
                    Rate = 0.8,
                    ReverseRate = 1.25
                },
                new()
                {
                    Id = Guid.Parse("392CB8C4-A96D-4CD8-BDD5-5C28A928F22B"),
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
