using Bookstore.Client.Services;

namespace Bookstore.Client;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureHttp(this IServiceCollection services)
    {
        services.AddSingleton<IBookService,BookService>();

        // services.AddHttpClient<IBookService, BookService>(client =>
        // {
        //     client.BaseAddress = new Uri("https://localhost:7257/api/");
        // });
        return services;
    }
}