// <copyright file="ResponseExtensions.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Hellang.Middleware.ProblemDetails;
using LanguageExt.Common;
using Timetracker.Application.Common.Interfaces;

namespace Timetracker.Api.Extensions;

public static class ResponseExtensions
{
    public static IResult CreateCreatedResponse<T>(
        this HttpContext context,
        Result<T> result)
        where T : BaseResponse
    {
        return result.Match(
            resultOfT => Results.Created($"/{resultOfT.Guid}", resultOfT),
            exception =>
            {
                var factory = context.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                var problemDetails =
                    factory.CreateExceptionProblemDetails(context, exception);
                return Results.Problem(problemDetails);
            });
    }

    public static IResult CreateOkResponse<T>(this HttpContext context, Result<T> result)
        where T : notnull
    {
        return result.Match(
            Results.Ok,
            exception =>
            {
                var factory = context.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                var problemDetails =
                    factory.CreateExceptionProblemDetails(context, exception);
                return Results.Problem(problemDetails);
            });
    }
}