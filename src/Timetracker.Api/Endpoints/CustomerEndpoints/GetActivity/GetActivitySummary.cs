// <copyright file="GetActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetActivity;

public class GetActivitySummary : Summary<GetActivityEndpoint>
{
    public GetActivitySummary()
    {
        Summary = "Get activity for a customer";
        Description = "Use this endpoint to get activity for a customer";
        ExampleRequest = new GetActivityRequest(Guid.NewGuid(), Guid.NewGuid());
        Response(
            200,
            "Activity for customer",
            MediaTypeNames.Application.Json,
            new ActivityResponse(ActivityId.New(), "Activity name"));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer or Activity not found");
    }
}