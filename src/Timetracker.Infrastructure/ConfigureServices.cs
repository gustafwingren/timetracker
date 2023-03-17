using Microsoft.Extensions.DependencyInjection;

namespace Timetracker.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}