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
            client.BaseAddress = new Uri("https://localhost:7257/api/");
        });
        return services;
    }
    public static IServiceCollection ConfigureIOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration);
        return services;
    }
}