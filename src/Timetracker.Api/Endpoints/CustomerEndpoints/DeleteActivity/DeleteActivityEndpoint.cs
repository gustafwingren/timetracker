// <copyright file="DeleteActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.DeleteActivity;

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
            "customers/{@cId}/activities/{@aId}",
            x => new { x.CustomerId, x.ActivityId, });
    }

    public override async Task HandleAsync(DeleteActivityRequest req, CancellationToken ct)
    {
        var command = new DeleteActivityCommand(req.CustomerId, req.ActivityId);
        var customer = await _sender.Send(command, ct);

        await SendInterceptedAsync(customer, cancellation: ct);
    }
}