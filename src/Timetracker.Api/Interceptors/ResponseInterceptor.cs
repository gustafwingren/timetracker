// <copyright file="ResponseExtensions.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using FastEndpoints;
using FluentValidation.Results;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace Timetracker.Api.Interceptors;

public class ResponseInterceptor : IResponseInterceptor
{
    public async Task InterceptResponseAsync(
        object response,
        int statusCode,
        HttpContext ctx,
        IReadOnlyCollection<ValidationFailure> failures,
        CancellationToken ct)
    {
        if (response is IErrorOr { IsError: true, } error)
        {
            if (ctx.ResponseStarted())
            {
                return;
            }

            var problemDetailsFactory =
                ctx.RequestServices.GetRequiredService<ProblemDetailsFactory>();
            ProblemDetails problemDetails;

            if (error.Errors.All(x => x.Type == ErrorType.Validation))
            {
                var validationFailures = error.Errors.GroupBy(x => x.Code)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.Description).ToArray());

                var validationProblemDetails =
                    problemDetailsFactory.CreateValidationProblemDetails(
                        ctx,
                        validationFailures,
                        400);

                ctx.Response.HttpContext.MarkResponseStart();
                ctx.Response.StatusCode = validationProblemDetails.Status ?? 400;
                await ctx.Response.WriteAsJsonAsync(
                    validationProblemDetails,
                    options: null,
                    "application/problem+json",
                    ct);
                return;
            }

            if (error.Errors.Any(x => x.Type == ErrorType.Unexpected))
            {
                var unexpectedError =
                    error.Errors.FirstOrDefault(x => x.Type == ErrorType.Unexpected);
                problemDetails = problemDetailsFactory.CreateProblemDetails(
                    ctx,
                    500,
                    unexpectedError.Code,
                    null,
                    unexpectedError.Description);

                ctx.Response.HttpContext.MarkResponseStart();
                ctx.Response.StatusCode = problemDetails.Status ?? 500;
                await ctx.Response.WriteAsJsonAsync(
                    problemDetails,
                    options: null,
                    "application/problem+json",
                    ct);
                return;
            }

            var firstError = error.Errors[0];

            var firstErrorStatusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

            problemDetails = problemDetailsFactory.CreateProblemDetails(
                ctx,
                firstErrorStatusCode,
                firstError.Code,
                null,
                firstError.Description);

            ctx.Response.HttpContext.MarkResponseStart();
            ctx.Response.StatusCode = problemDetails.Status ?? 500;
            await ctx.Response.WriteAsJsonAsync(
                problemDetails,
                options: null,
                "application/problem+json",
                ct);
        }
    }
}