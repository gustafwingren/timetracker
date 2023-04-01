// <copyright file="GetAllCustomersEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Timetracker.Api.Extensions;
using Timetracker.Application.Customer.Queries.GetCustomers;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetAllCustomers;

[HttpGet("customers")]
[Authorize]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<IResult>
{
    private readonly ISender _sender;

    public GetAllCustomersEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<IResult> ExecuteAsync(CancellationToken ct)
    {
        var userId = HttpContext.User.GetObjectId();

        if (userId == null)
        {
            return Results.Unauthorized();
        }

        var customers = await _sender.Send(
            new GetCustomersQuery(new UserId(Guid.Parse(userId))),
            ct);

        return HttpContext.CreateOkResponse(customers);
    }
}