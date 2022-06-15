﻿// <auto-generated />
using System;
using EasyTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    [DbContext(typeof(EasyTrackerDbContext))]
    partial class EasyTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyTracker.DAL.Models.BaseCurrencyRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromCurrency")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("ToCurrency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseCurrencyRate");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseCurrencyRate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("675301fc-2816-46eb-a0ae-47bb52ed4a19"),
                            FromCurrency = 0,
                            Rate = 1.0,
                            ToCurrency = 0
                        },
                        new
                        {
                            Id = new Guid("4be152c9-8166-490e-a6a8-a760daea62cb"),
                            FromCurrency = 1,
                            Rate = 1.0,
                            ToCurrency = 1
                        },
                        new
                        {
                            Id = new Guid("840cf9ee-d0d3-4a65-b133-38b80b4de011"),
                            FromCurrency = 2,
                            Rate = 1.0,
                            ToCurrency = 2
                        },
                        new
                        {
                            Id = new Guid("8e77b222-1d90-4a08-b503-ade87cb7eafc"),
                            FromCurrency = 3,
                            Rate = 1.0,
                            ToCurrency = 3
                        },
                        new
                        {
                            Id = new Guid("379faee5-bde2-4cb6-8405-2e8e92f163bb"),
                            FromCurrency = 0,
                            Rate = 0.034000000000000002,
                            ToCurrency = 1
                        },
                        new
                        {
                            Id = new Guid("b57128e9-e448-46cd-bfba-afef4d25985c"),
                            FromCurrency = 1,
                            Rate = 29.5,
                            ToCurrency = 0
                        },
                        new
                        {
                            Id = new Guid("dd015f02-7bb5-426c-9787-92cdec52abe7"),
                            FromCurrency = 0,
                            Rate = 0.032000000000000001,
                            ToCurrency = 2
                        },
                        new
                        {
                            Id = new Guid("cb288c3f-f483-4259-8eb7-e6353d2a14ce"),
                            FromCurrency = 2,
                            Rate = 31.59,
                            ToCurrency = 0
                        },
                        new
                        {
                            Id = new Guid("d6f50313-3b89-45ae-9a9d-3577ef0230c3"),
                            FromCurrency = 0,
                            Rate = 0.027,
                            ToCurrency = 3
                        },
                        new
                        {
                            Id = new Guid("6cc3b4e8-8535-4e83-b349-dc52e8ec1efb"),
                            FromCurrency = 3,
                            Rate = 36.950000000000003,
                            ToCurrency = 0
                        },
                        new
                        {
                            Id = new Guid("51eb5043-ecde-4857-a27d-89af00265485"),
                            FromCurrency = 1,
                            Rate = 0.93000000000000005,
                            ToCurrency = 2
                        },
                        new
                        {
                            Id = new Guid("45f2cced-7f30-4dd8-830c-35b6139de59d"),
                            FromCurrency = 2,
                            Rate = 1.0700000000000001,
                            ToCurrency = 1
                        },
                        new
                        {
                            Id = new Guid("725b5521-ca03-4109-b230-5f17a0ea99dd"),
                            FromCurrency = 1,
                            Rate = 0.80000000000000004,
                            ToCurrency = 3
                        },
                        new
                        {
                            Id = new Guid("701ec533-ea40-42ae-8ad0-fe934b9f76c4"),
                            FromCurrency = 3,
                            Rate = 1.25,
                            ToCurrency = 1
                        },
                        new
                        {
                            Id = new Guid("392cb8c4-a96d-4cd8-bdd5-5c28a928f22b"),
                            FromCurrency = 2,
                            Rate = 0.84999999999999998,
                            ToCurrency = 3
                        },
                        new
                        {
                            Id = new Guid("159dc525-ff91-49bd-abb5-510e6b614e82"),
                            FromCurrency = 3,
                            Rate = 1.1699999999999999,
                            ToCurrency = 2
                        });
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.CurrencyBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Currency")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("CurrencyBalance");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.MainSpendingCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainSpendingCategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea9208e8-3838-49ce-80ad-468cea820b86"),
                            CategoryName = "Food",
                            ImageSrc = "fastfood"
                        },
                        new
                        {
                            Id = new Guid("bac73f2d-5456-4b26-a7eb-387852cfee66"),
                            CategoryName = "Transport",
                            ImageSrc = "train"
                        },
                        new
                        {
                            Id = new Guid("e3c2a39d-ac7e-477c-aed1-d6586e6c27d6"),
                            CategoryName = "Health",
                            ImageSrc = "healing"
                        },
                        new
                        {
                            Id = new Guid("0449468f-bc04-4423-97e4-2e56826f5cc1"),
                            CategoryName = "Other",
                            ImageSrc = "info"
                        },
                        new
                        {
                            Id = new Guid("a3e814b2-5698-4d4e-be03-772b295e47ce"),
                            CategoryName = "Restaurants",
                            ImageSrc = "restaurant"
                        },
                        new
                        {
                            Id = new Guid("2553d9c5-f104-49a3-80af-a27eb32fc274"),
                            CategoryName = "Technics",
                            ImageSrc = "android"
                        });
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Saving", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Saving");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Spending", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<Guid>("SpendingCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SpendingCategoryId");

                    b.ToTable("Spending");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.SpendingCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PlannedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SpendingCategory");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MainCurrency")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.CurrencyRate", b =>
                {
                    b.HasBaseType("EasyTracker.DAL.Models.BaseCurrencyRate");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("CurrencyRate");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.CurrencyBalance", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", "User")
                        .WithMany("CurrencyBalances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Salary", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", "User")
                        .WithMany("Salaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Saving", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", "User")
                        .WithMany("Savings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.Spending", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.SpendingCategory", "SpendingCategory")
                        .WithMany("Spendings")
                        .HasForeignKey("SpendingCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpendingCategory");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.SpendingCategory", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", "User")
                        .WithMany("SpendingCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyTracker.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.CurrencyRate", b =>
                {
                    b.HasOne("EasyTracker.DAL.Models.User", "User")
                        .WithMany("CurrencyRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.SpendingCategory", b =>
                {
                    b.Navigation("Spendings");
                });

            modelBuilder.Entity("EasyTracker.DAL.Models.User", b =>
                {
                    b.Navigation("CurrencyBalances");

                    b.Navigation("CurrencyRates");

                    b.Navigation("Salaries");

                    b.Navigation("Savings");

                    b.Navigation("SpendingCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
