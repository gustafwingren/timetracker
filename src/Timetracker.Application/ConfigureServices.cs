// <copyright file="ConfigureServices.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Timetracker.Application.Common.Behaviors;

namespace Timetracker.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly);
        serviceCollection.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return serviceCollection;
    }
}