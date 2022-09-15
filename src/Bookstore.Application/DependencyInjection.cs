using MediatR;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;
using System.Reflection;
using Bookstore.Application.ValidationBehavior;
using FluentValidation;
using Bookstore.Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Nest;
using Bookstore.Domain.Entities;
using Bookstore.Application.Services;

namespace Bookstore.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services, AppSettings settings)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.ConfigureMapster();
        services.ConfigurePipelineBehaviour();
        services.ConfigureElasticsearch(settings.ElasticsearchSettings);
        services.ConfigureStorage();
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
    public static IServiceCollection ConfigurePipelineBehaviour(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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
    public static IServiceCollection ConfigureStorage(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, StorageService>();
        return services;
    }
}
