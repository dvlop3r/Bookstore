using Bookstore.Client.Services;
using Bookstore.Client.Settings;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookstore.Client;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureHttp(this IServiceCollection services)
    {
        services.AddSingleton<IBookService,BookService>();

        services.AddHttpClient<IBookService, BookService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:44336/api/bookstore");
        });
        return services;
    }
    public static IServiceCollection ConfigureIOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration);
        return services;
    }
    public static IServiceCollection ConfigureStorageServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileStorageService, FileStorageService>();
        return services;
    }
    public static IServiceCollection ConfigureMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
        typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
        // register the mapper as Singleton service for my application
        var mapperConfig = new Mapper(typeAdapterConfig);
        services.AddSingleton<IMapper>(mapperConfig);
        return services;
    }
}