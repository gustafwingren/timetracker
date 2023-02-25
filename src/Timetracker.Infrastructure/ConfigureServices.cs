using Microsoft.Extensions.DependencyInjection;
using Timetracker.Infrastructure.Repository;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IReadRepository<>), typeof(ListRepository<>));
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(ListRepository<>));

        return serviceCollection;
    }
}