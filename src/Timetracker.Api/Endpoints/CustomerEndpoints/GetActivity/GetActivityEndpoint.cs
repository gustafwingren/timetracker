// <copyright file="GetActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetActivity;

public class GetActivityEndpoint : Endpoint<GetActivityRequest, ActivityResponse>
{
    private readonly ISender _sender;

    public GetActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("customers/{@cId}/activity/{@aId}", x => new { x.CustomerId, x.ActivityId, });
    }

    public override async Task HandleAsync(GetActivityRequest req, CancellationToken ct)
    {
        var query = new GetActivityQuery(
            req.CustomerId,
            req.ActivityId);

        var activity = await _sender.Send(query, ct);

        await SendInterceptedAsync(activity, cancellation: ct);
    }
}