// <copyright file="GetCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Queries.GetCustomer;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpGet("customers/{id:guid}")]
[Authorize]
public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerDto>
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