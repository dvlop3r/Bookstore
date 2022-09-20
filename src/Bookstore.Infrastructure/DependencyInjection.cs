using System.Text;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Services;
using Bookstore.Contracts.Settings;
using Bookstore.Infrastructure.Repositories;
using BuberDinner.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        AppSettings appSettings)
    {

        services.AddScoped<IBookRepository,BookRepository>();
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.ConfigureDbContext(appSettings);
        services.ConfigureAuthentication(appSettings.JwtSettings);
        return services;
    }
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, AppSettings settings)
    {
        services.AddDbContext<AppDbContext>(dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseSqlServer(settings.DatabaseSettings.AppDbContext, options =>
            {
                options.EnableRetryOnFailure(settings.DatabaseSettings.MaxRetryCount, TimeSpan.FromSeconds(settings.DatabaseSettings.MaxRetryDelay), null);
                options.MigrationsAssembly("Bookstore.Infrastructure");
                options.CommandTimeout(settings.DatabaseSettings.Timeout);
                });
                // dbContextOptionsBuilder.EnableDetailedErrors();
                // dbContextOptionsBuilder.EnableSensitiveDataLogging();
                // dbContextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        return services;
    }
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
    {
        services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });
        return services;
    }
}