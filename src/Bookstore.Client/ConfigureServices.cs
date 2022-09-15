using Bookstore.Client.Services;
using Bookstore.Client.Settings;
using Microsoft.Extensions.DependencyInjection;

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
}