using Bookstore.Contracts.Settings;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Global exception handling filter
        //builder.Services.AddControllers(options => options.Filters.Add(new GlobalExceptionFilter()));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // adds options pattern
        services.Configure<AppSettings>(configuration);
        
        return services;
    }
}