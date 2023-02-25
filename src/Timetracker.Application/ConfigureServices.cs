// <copyright file="ConfigureServices.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace Timetracker.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));

        return serviceCollection;
    }
}