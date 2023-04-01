// <copyright file="UpdateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Api.Extensions;
using Timetracker.Application.Customer.Commands.UpdateActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public sealed class UpdateActivityEndpoint : Endpoint<UpdateActivityRequest, IResult>
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

    public override async Task<IResult> ExecuteAsync(
        UpdateActivityRequest req,
        CancellationToken ct)
    {
        var command = new UpdateActivityCommand(req.CustomerId, req.ActivityId, req.Name);
        var activity = await _sender.Send(command, ct);

        return HttpContext.CreateOkResponse(activity);
    }
}