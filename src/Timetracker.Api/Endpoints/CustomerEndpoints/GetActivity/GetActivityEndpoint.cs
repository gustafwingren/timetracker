// <copyright file="GetActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetActivity;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

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
        Get("customers/{CustomerId:Guid}/activity/{ActivityId:Guid}");
    }

    public override async Task HandleAsync(GetActivityRequest req, CancellationToken ct)
    {
        var query = new GetActivityQuery(
            new CustomerId(req.CustomerId),
            new ActivityId(req.ActivityId));

        var activity = await _sender.Send(query, ct);

        await SendInterceptedAsync(activity, cancellation: ct);
    }
}