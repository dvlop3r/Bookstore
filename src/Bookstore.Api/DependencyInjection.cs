using Bookstore.Api.Filters;
using Bookstore.Contracts.Settings;

namespace Bookstore.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Secong approach to handle exceptions
        // services.AddControllers(options => options.Filters.Add(new GlobalExceptionFilter()));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // adds options pattern
        services.Configure<AppSettings>(configuration);
        
        return services;
    }
}