// <copyright file="ValidationBehavior.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using Timetracker.Application.Common.Interfaces;

namespace Timetracker.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandRequest
    where TResponse : class, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(vr => vr.Errors.Any())
            .SelectMany(vr => vr.Errors)
            .ToList();

        if (!failures.Any())
        {
            return await next();
        }

        var validationResult = new ValidationException(failures);

        return validationResult as TResponse ?? throw new NullReferenceException();
    }
}