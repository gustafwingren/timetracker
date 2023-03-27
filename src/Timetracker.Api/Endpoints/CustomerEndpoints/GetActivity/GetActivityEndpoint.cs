// <copyright file="GetActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetActivity;

[HttpGet("customers/{customerId:CustomerId}/activity/{activityId:ActivityId}")]
[Authorize]
public class GetActivityEndpoint : Endpoint<GetActivityRequest, ActivityResponse>
{
    private readonly ISender _sender;

    public GetActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(GetActivityRequest req, CancellationToken ct)
    {
        var query = new GetActivityQuery(
            req.CustomerId,
            req.ActivityId);

        var activity = await _sender.Send(query, ct);

        await SendOkAsync(activity, ct);
    }
}