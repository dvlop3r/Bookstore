using Bookstore.Application.Interfaces;
using Bookstore.Contracts.Settings;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        return services;
    }
    public static IServiceCollection ConfigureDbContext(
        this IServiceCollection services,
        AppSettings settings)
    {
        services.AddDbContext<AppDbContext>(dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseSqlServer(settings.DatabaseSettings.AppDbContext, options =>
            {
                options.EnableRetryOnFailure(settings.DatabaseSettings.MaxRetryCount, TimeSpan.FromSeconds(settings.DatabaseSettings.MaxRetryDelay), null);
                // options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                options.CommandTimeout(settings.DatabaseSettings.Timeout);
                });
                // dbContextOptionsBuilder.EnableDetailedErrors();
                // dbContextOptionsBuilder.EnableSensitiveDataLogging();
                // dbContextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        return services;
    }
}