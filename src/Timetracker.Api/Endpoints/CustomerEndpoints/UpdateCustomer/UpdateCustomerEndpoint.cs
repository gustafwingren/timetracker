// <copyright file="UpdateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.UpdateCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public UpdateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("customers/{@cId}", x => new { x.Id, });
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var customer = await _sender.Send(
            new UpdateCustomerCommand(req.Id, req.Name, req.Number),
            ct);

        await SendInterceptedAsync(customer, cancellation: ct);
    }
}