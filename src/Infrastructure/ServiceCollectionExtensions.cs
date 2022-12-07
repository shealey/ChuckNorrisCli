using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string chuckNorrisApiUrl)
    {
        services.AddHttpClient(nameof(ChuckNorrisClient), c =>
        {
            c.BaseAddress = new Uri(chuckNorrisApiUrl);
        });

        return services
            .AddSingleton<IChuckNorrisClient, ChuckNorrisClient>()
            .AddSingleton<ICache, Cache>();
    }
}