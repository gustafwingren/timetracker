// <copyright file="UpdateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.UpdateCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

[HttpPut("customers/{id:CustomerId}")]
[Authorize]
public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public UpdateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(UpdateCustomerRequest request, CancellationToken ct)
    {
        var customer = await _sender.Send(
            new UpdateCustomerCommand(request.Id, request.Name, request.Number),
            ct);

        if (customer == null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendOkAsync(customer, ct);
    }
}