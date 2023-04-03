// <copyright file="ValidationPreProcessor.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using FluentValidation.Results;
using Hellang.Middleware.ProblemDetails;

namespace Timetracker.Api.PreProcessors;

public class ValidationPreProcessor : IGlobalPreProcessor
{
    public async Task PreProcessAsync(
        object req,
        HttpContext ctx,
        List<ValidationFailure> failures,
        CancellationToken ct)
    {
        if (failures.Any())
        {
            if (!ctx.ResponseStarted())
            {
                var problemDetailsFactory =
                    ctx.RequestServices.GetRequiredService<ProblemDetailsFactory>();

                var validationFailures = failures.GroupBy(x => x.PropertyName)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).ToArray());

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
            }
        }
    }
}