using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timetracker.Infrastructure.Persistence;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddCosmos<CosmosDbContext>(
            configuration["CosmosDB:ConnectionString"] ?? string.Empty,
            configuration["CosmosDB:DatabaseName"] ?? string.Empty,
            options => { });

        serviceCollection.AddTransient(typeof(IReadRepository<>), typeof(CosmosRepository<>));
        serviceCollection.AddTransient(typeof(IRepository<>), typeof(CosmosRepository<>));

        return serviceCollection;
    }
}