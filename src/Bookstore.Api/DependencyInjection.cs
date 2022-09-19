using Bookstore.Contracts.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

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
        services.ConfigureApiVersioning();

        // adds options pattern
        services.Configure<AppSettings>(configuration);
        
        return services;
    }

    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        services.AddSwaggerGen(c =>
        {
            //Hardcoding api version documentation is not a good practice because
            //of multiple versions, we use ConfigureSwaggerOptions class instead"
            https://localhost:5001/swagger/index.html?urls.primaryName=V1
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookstoreWebAPI", Version = "v1" });
            c.SwaggerDoc("v2", new OpenApiInfo { Title = "BookstoreWebAPI", Version = "v2" });
        });
        //services.ConfigureOptions<ConfigureSwaggerOptions>();

        return services;
    }
}