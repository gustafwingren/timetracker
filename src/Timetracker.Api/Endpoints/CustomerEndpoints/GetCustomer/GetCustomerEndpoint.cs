// <copyright file="GetCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetCustomer;

[HttpGet("customers/{id:CustomerId}")]
[Authorize]
public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public GetCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(
        GetCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var customer = await _sender.Send(new GetCustomerQuery(request.Id), cancellationToken);

        if (customer == null)
        {
            await SendNotFoundAsync(cancellationToken);
        }

        await SendOkAsync(customer, cancellationToken);
    }
}