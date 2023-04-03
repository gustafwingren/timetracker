// <copyright file="UpdateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.UpdateActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public sealed class UpdateActivityEndpoint : Endpoint<UpdateActivityRequest, ActivityResponse>
{
    private readonly ISender _sender;

    public UpdateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("customers/{@cId}/activities/{@aId}", x => new { x.CustomerId, x.ActivityId, });
    }

    public override async Task HandleAsync(UpdateActivityRequest req, CancellationToken ct)
    {
        var command = new UpdateActivityCommand(req.CustomerId, req.ActivityId, req.Name);
        var activity = await _sender.Send(command, ct);

        await SendInterceptedAsync(activity, cancellation: ct);
    }
}