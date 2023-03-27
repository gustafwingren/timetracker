// <copyright file="GetAllCustomersEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetCustomers;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetAllCustomers;

[HttpGet("customers")]
[Authorize]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<List<CustomerResponse>>
{
    private readonly ISender _sender;

    public GetAllCustomersEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(
        CancellationToken cancellationToken)
    {
        var userId = HttpContext.User.GetObjectId();

        if (userId == null)
        {
            await SendUnauthorizedAsync(cancellationToken);
        }

        var customers = await _sender.Send(
            new GetCustomersQuery(new UserId(Guid.Parse(userId))),
            cancellationToken);

        await SendOkAsync(customers, cancellationToken);
    }
}