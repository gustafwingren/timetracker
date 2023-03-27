// <copyright file="ConfigureServices.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Timetracker.Application.Common.Behaviors;

namespace Timetracker.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddMediatR(
            cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            }
        );

        return serviceCollection;
    }
}