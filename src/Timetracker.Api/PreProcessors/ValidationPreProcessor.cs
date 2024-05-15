// // <copyright file="ValidationPreProcessor.cs" company="gustafwingren">
// // Copyright (c) gustafwingren. All rights reserved.
// // </copyright>
//
// using FastEndpoints;
// using Microsoft.AspNetCore.Mvc.Infrastructure;
//
// namespace Timetracker.Api.PreProcessors;
//
// public class ValidationPreProcessor : IGlobalPreProcessor
// {
//     public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
//     {
//         if (context.HasValidationFailures)
//         {
//             if (!context.HttpContext.ResponseStarted())
//             {
//                 var problemDetailsFactory =
//                     context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
//
//                 var validationFailures = context.ValidationFailures.GroupBy(x => x.PropertyName)
//                     .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).ToArray());
//
//                 var validationProblemDetails =
//                     problemDetailsFactory.CreateValidationProblemDetails(
//                         context.HttpContext,
//                         validationFailures,
//                         400);
//
//                 context.HttpContext.Response.HttpContext.MarkResponseStart();
//                 context.HttpContext.Response.StatusCode = validationProblemDetails.Status ?? 400;
//                 await context.HttpContext.Response.WriteAsJsonAsync(
//                     validationProblemDetails,
//                     options: null,
//                     "application/problem+json",
//                     ct);
//             }
//         }
//     }
// }

