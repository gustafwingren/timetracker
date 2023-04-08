// <copyright file="DeleteActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.DeleteActivity;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteActivity;

public sealed class DeleteActivityEndpoint : Endpoint<DeleteActivityRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public DeleteActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete(
            "customers/{CustomerId:Guid}/activities/{ActivityId:Guid}");
    }

    public override async Task HandleAsync(DeleteActivityRequest req, CancellationToken ct)
    {
        var command = new DeleteActivityCommand(
            new CustomerId(req.CustomerId),
            new ActivityId(req.ActivityId));
        var customer = await _sender.Send(command, ct);

        await SendInterceptedAsync(customer, cancellation: ct);
    }
}