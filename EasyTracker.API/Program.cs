using System.Security.Claims;
using System.Text;
using Azure.Identity;
using EasyTracker.API.Config;
using EasyTracker.BLL.Config;
using EasyTracker.BLL.Interfaces;
using EasyTracker.BLL.Services;
using EasyTracker.DAL.Data;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;
using EasyTracker.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (
        _,
        _,
        configuration) => configuration.WriteTo.Console());

// if (builder.Environment.IsProduction())
// {
//     builder.Configuration.AddAzureKeyVault(
//         new Uri("https://easy-tracker.vault.azure.net/"),
//         new DefaultAzureCredential()
//     );
// }

builder.Services.AddCors(
    options =>
        options.AddDefaultPolicy(
            policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        )
);

builder.Services
    .AddControllers()
    .AddJsonOptions(
        options =>
            options.JsonSerializerOptions.PropertyNamingPolicy = System
                .Text
                .Json
                .JsonNamingPolicy
                .CamelCase
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Name = HeaderNames.Authorization,
                Description =
                    "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });

        options.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            });
    }
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<ISalaryRepository, SalaryRepository>();
builder.Services.AddTransient<ISpendingCategoryRepository, SpendingCategoryRepository>();
builder.Services.AddTransient<ISpendingRepository, SpendingRepository>();
builder.Services.AddTransient<IBaseCurrencyRateRepository, BaseCurrencyRateRepository>();
builder.Services.AddTransient<ICurrencyRateRepository, CurrencyRateRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMainSpendingCategoryRepository, MainSpendingCategoryRepository>();
builder.Services.AddTransient<ICurrencyDataRepository, CurrencyDataRepository>();

builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddTransient<ISpendingService, SpendingService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISpendingCategoryService, SpendingCategoryService>();
builder.Services.AddTransient<ICurrencyDataService, CurrencyDataService>();
builder.Services.AddTransient<IJwtGenerator, JwtGenerator>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<Settings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddDbContext<EasyTrackerDbContext>(
    options => options.UseSqlServer(connectionString),
    ServiceLifetime.Transient
);

builder.Services.Configure<CurrencyAPISettings>(
    builder.Configuration.GetSection(nameof(CurrencyAPISettings)));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

builder.Services
    .AddIdentity<User, IdentityRole>(options => options.User.RequireUniqueEmail = false)
    .AddEntityFrameworkStores<EasyTrackerDbContext>()
    .AddDefaultTokenProviders();

var identityBuilder = builder.Services.AddIdentityCore<User>();

identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
identityBuilder
    .AddEntityFrameworkStores<EasyTrackerDbContext>()
    .AddSignInManager<SignInManager<User>>()
    .AddDefaultTokenProviders();

var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:TokenKey"])
);
builder.Services
    .AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    )
    .AddJwtBearer(
        options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = key,
            };
        }
    );

builder.Services.Configure<IdentityOptions>(
    options =>
    {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = false;
    }
);

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUser>(
    services =>
    {
        var httpContextAccessor = services.GetService<IHttpContextAccessor>();

        var userClaims = httpContextAccessor?.HttpContext?.User;

        return new UserAccessor
        {
            UserName = userClaims.FindFirstValue(ClaimTypes.NameIdentifier),
        };
    });

var app = builder.Build();

app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EasyTrackerDbContext>();

    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
