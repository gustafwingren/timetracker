// <copyright file="GetAllCustomersEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Queries.GetCustomers;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpGet("customers")]
[Authorize]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<List<CustomerDto>>
{
    private readonly ISender _sender;

    public GetAllCustomersEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(
        CancellationToken cancellationToken)
    {
        var customers = await _sender.Send(new GetCustomersQuery(), cancellationToken);

        await SendOkAsync(customers, cancellationToken);
    }
}