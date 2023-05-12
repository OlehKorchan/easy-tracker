using EasyTracker.DAL.Models;
using EasyTracker.DAL.Models.ML;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyTracker.DAL.Data;

public class EasyTrackerDbContext : IdentityDbContext<User>
{
    public EasyTrackerDbContext(DbContextOptions<EasyTrackerDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<CurrencyBalance>()
            .HasIndex(cb => new { cb.Currency, cb.UserId })
            .IsUnique();

        builder.Entity<SpendingCategory>();
        builder
            .Entity<MainSpendingCategory>()
            .HasData(GetMainSpendingCategories());
        builder.Entity<MainSpendingCategory>().Property(msc => msc.CategoryName).HasMaxLength(32);
        builder.Entity<MainSpendingCategory>().Property(msc => msc.Description).HasMaxLength(300);

        builder.Entity<Salary>().Property(s => s.Comment).HasMaxLength(300);
        builder.Entity<Saving>();
        builder.Entity<Spending>();
        builder.Entity<Spending>().Property(s => s.Comment).HasMaxLength(300);
        builder.Entity<CurrencyRate>();
        builder
            .Entity<BaseCurrencyRate>()
            .HasData(GetBaseCurrencyRates());

        builder.Entity<User>().Property(p => p.UserName).HasMaxLength(256);
        builder
            .Entity<User>()
            .HasMany(u => u.CurrencyBalances)
            .WithOne(cb => cb.User)
            .HasForeignKey(cb => cb.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<User>()
            .HasMany(u => u.CurrencyRates)
            .WithOne(cr => cr.User)
            .HasForeignKey(cr => cr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<User>()
            .HasMany(u => u.Savings)
            .WithOne(sc => sc.User)
            .HasForeignKey(sc => sc.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ModelInput>();

        base.OnModelCreating(builder);
    }

    private static IEnumerable<BaseCurrencyRate> GetBaseCurrencyRates()
    {
        return new List<BaseCurrencyRate>
        {
            new()
            {
                Id = Guid.Parse("675301FC-2816-46EB-A0AE-47BB52ED4A19"),
                FromCurrency = Enums.CurrencyCode.UAH,
                ToCurrency = Enums.CurrencyCode.UAH,
                Rate = 1,
            },
            new()
            {
                Id = Guid.Parse("4BE152C9-8166-490E-A6A8-A760DAEA62CB"),
                FromCurrency = Enums.CurrencyCode.USD,
                ToCurrency = Enums.CurrencyCode.USD,
                Rate = 1,
            },
            new()
            {
                Id = Guid.Parse("840CF9EE-D0D3-4A65-B133-38B80B4DE011"),
                FromCurrency = Enums.CurrencyCode.EUR,
                ToCurrency = Enums.CurrencyCode.EUR,
                Rate = 1,
            },
            new()
            {
                Id = Guid.Parse("8E77B222-1D90-4A08-B503-ADE87CB7EAFC"),
                FromCurrency = Enums.CurrencyCode.GBP,
                ToCurrency = Enums.CurrencyCode.GBP,
                Rate = 1,
            },
            new()
            {
                Id = Guid.Parse("379FAEE5-BDE2-4CB6-8405-2E8E92F163BB"),
                FromCurrency = Enums.CurrencyCode.UAH,
                ToCurrency = Enums.CurrencyCode.USD,
                Rate = 0.034,
            },
            new()
            {
                Id = Guid.Parse("B57128E9-E448-46CD-BFBA-AFEF4D25985C"),
                FromCurrency = Enums.CurrencyCode.USD,
                ToCurrency = Enums.CurrencyCode.UAH,
                Rate = 29.50,
            },
            new()
            {
                Id = Guid.Parse("DD015F02-7BB5-426C-9787-92CDEC52ABE7"),
                FromCurrency = Enums.CurrencyCode.UAH,
                ToCurrency = Enums.CurrencyCode.EUR,
                Rate = 0.032,
            },
            new()
            {
                Id = Guid.Parse("CB288C3F-F483-4259-8EB7-E6353D2A14CE"),
                FromCurrency = Enums.CurrencyCode.EUR,
                ToCurrency = Enums.CurrencyCode.UAH,
                Rate = 31.59,
            },
            new()
            {
                Id = Guid.Parse("D6F50313-3B89-45AE-9A9D-3577EF0230C3"),
                FromCurrency = Enums.CurrencyCode.UAH,
                ToCurrency = Enums.CurrencyCode.GBP,
                Rate = 0.027,
            },
            new()
            {
                Id = Guid.Parse("6CC3B4E8-8535-4E83-B349-DC52E8EC1EFB"),
                FromCurrency = Enums.CurrencyCode.GBP,
                ToCurrency = Enums.CurrencyCode.UAH,
                Rate = 36.95,
            },
            new()
            {
                Id = Guid.Parse("51EB5043-ECDE-4857-A27D-89AF00265485"),
                FromCurrency = Enums.CurrencyCode.USD,
                ToCurrency = Enums.CurrencyCode.EUR,
                Rate = 0.93,
            },
            new()
            {
                Id = Guid.Parse("45F2CCED-7F30-4DD8-830C-35B6139DE59D"),
                FromCurrency = Enums.CurrencyCode.EUR,
                ToCurrency = Enums.CurrencyCode.USD,
                Rate = 1.07,
            },
            new()
            {
                Id = Guid.Parse("725B5521-CA03-4109-B230-5F17A0EA99DD"),
                FromCurrency = Enums.CurrencyCode.USD,
                ToCurrency = Enums.CurrencyCode.GBP,
                Rate = 0.8,
            },
            new()
            {
                Id = Guid.Parse("701EC533-EA40-42AE-8AD0-FE934B9F76C4"),
                FromCurrency = Enums.CurrencyCode.GBP,
                ToCurrency = Enums.CurrencyCode.USD,
                Rate = 1.25,
            },
            new()
            {
                Id = Guid.Parse("392CB8C4-A96D-4CD8-BDD5-5C28A928F22B"),
                FromCurrency = Enums.CurrencyCode.EUR,
                ToCurrency = Enums.CurrencyCode.GBP,
                Rate = 0.85,
            },
            new()
            {
                Id = Guid.Parse("159DC525-FF91-49BD-ABB5-510E6B614E82"),
                FromCurrency = Enums.CurrencyCode.GBP,
                ToCurrency = Enums.CurrencyCode.EUR,
                Rate = 1.17,
            },
        };
    }

    private static IEnumerable<MainSpendingCategory> GetMainSpendingCategories()
    {
        return new List<MainSpendingCategory>
        {
            new()
            {
                Id = Guid.Parse("EA9208E8-3838-49CE-80AD-468CEA820B86"),
                CategoryName = "Food",
                ImageSrc = "fastfood",
            },
            new()
            {
                Id = Guid.Parse("BAC73F2D-5456-4B26-A7EB-387852CFEE66"),
                CategoryName = "Transport",
                ImageSrc = "train",
            },
            new()
            {
                Id = Guid.Parse("E3C2A39D-AC7E-477C-AED1-D6586E6C27D6"),
                CategoryName = "Health",
                ImageSrc = "healing",
            },
            new()
            {
                Id = Guid.Parse("0449468F-BC04-4423-97E4-2E56826F5CC1"),
                CategoryName = "Other",
                ImageSrc = "info",
            },
            new()
            {
                Id = Guid.Parse("A3E814B2-5698-4D4E-BE03-772B295E47CE"),
                CategoryName = "Restaurants",
                ImageSrc = "restaurant",
            },
            new()
            {
                Id = Guid.Parse("2553D9C5-F104-49A3-80AF-A27EB32FC274"),
                CategoryName = "Technics",
                ImageSrc = "android",
            },
        };
    }
}
