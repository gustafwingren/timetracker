// <copyright file="UpdateActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public class UpdateActivitySummary : Summary<UpdateActivityEndpoint>
{
    public UpdateActivitySummary()
    {
        Summary = "Update activity";
        Description = "Use this endpoint to update an activity";
        ExampleRequest = new UpdateActivityRequest(CustomerId.New(), ActivityId.New(), "New name");
        Response(
            200,
            "Updated customer",
            MediaTypeNames.Application.Json,
            new ActivityResponse(ActivityId.New(), "New name"));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer or Activity not found");
    }
}