// <copyright file="GetAcitivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Queries.GetActivity;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared.Contracts.Requests;
using ActivityDto = Timetracker.Shared.Contracts.Responses.ActivityDto;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpGet("customers/{customerId:guid}/activity/{activityId:guid}")]
[Authorize]
public class GetActivityEndpoint : Endpoint<GetActivityRequest, ActivityDto>
{
    private readonly ISender _sender;

    public GetActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<ActivityDto> ExecuteAsync(
        GetActivityRequest req,
        CancellationToken ct)
    {
        var query = new GetActivityQuery(
            new CustomerId(req.CustomerId),
            new ActivityId(req.ActivityId));

        var activity = await _sender.Send(query, ct);

        return activity;
    }
}