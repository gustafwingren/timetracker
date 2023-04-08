// <copyright file="DeleteCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Customer.Commands.DeleteCustomer;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteCustomer;

public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest>
{
    private readonly ISender _sender;

    public DeleteCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("customers/{Id:Guid}");
    }

    public override async Task HandleAsync(DeleteCustomerRequest req, CancellationToken ct)
    {
        var command = new DeleteCustomerCommand(new CustomerId(req.Id));
        var result = await _sender.Send(command, ct);

        await SendInterceptedAsync(result, cancellation: ct);
    }
}