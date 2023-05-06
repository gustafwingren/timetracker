using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Infrastructure.GraphClient;
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

        serviceCollection.AddTransient(typeof(IUserClient), typeof(UserClient));

        return serviceCollection;
    }
}