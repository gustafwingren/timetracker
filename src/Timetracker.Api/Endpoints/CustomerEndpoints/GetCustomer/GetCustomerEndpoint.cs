// <copyright file="GetCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetCustomer;

public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public GetCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("customers/{@cId}", x => new { x.Id, });
    }

    public override async Task HandleAsync(GetCustomerRequest req, CancellationToken ct)
    {
        var customer = await _sender.Send(new GetCustomerQuery(req.Id), ct);

        await SendInterceptedAsync(customer, cancellation: ct);
    }
}