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
    public static IServiceCollection ConfigureElasticsearch(
        this IServiceCollection services,
        ElasticSearchSettings elasticSearchSettings)
    {
        var settings = new ConnectionSettings(new Uri(elasticSearchSettings.Url))
        .BasicAuthentication(elasticSearchSettings.User, elasticSearchSettings.Password)
                .PrettyJson()
                .DefaultIndex(elasticSearchSettings.IndexName)
                .DefaultMappingFor<Book>(m => m);

        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);

        client.Indices.Create(elasticSearchSettings.IndexName, index => index.Map<Book>(m => m.AutoMap()));

        return services;
    }
}