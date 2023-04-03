// <copyright file="ValidationBehavior.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Reflection;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Timetracker.Application.Common.Interfaces;

namespace Timetracker.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    where TResponse : IErrorOr
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
        if (!_validators.Any())
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

        return TryCreateResponseFromErrors(failures, out var response)
            ? response
            : throw new ValidationException(failures);
    }

    private static bool TryCreateResponseFromErrors(
        List<ValidationFailure> validationFailures,
        out TResponse response)
    {
        var errors = validationFailures.ConvertAll(
            x => Error.Validation(
                x.PropertyName,
                x.ErrorMessage));

        response = (TResponse?)typeof(TResponse)
            .GetMethod(
                nameof(ErrorOr<object>.From),
                BindingFlags.Static | BindingFlags.Public,
                new[] { typeof(List<Error>), })?
            .Invoke(null, new[] { errors, })!;

        return response is not null;
    }
}