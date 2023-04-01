// <copyright file="DeleteActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteActivity;

public class DeleteActivitySummary : Summary<DeleteActivityEndpoint>
{
    public DeleteActivitySummary()
    {
        Summary = "Delete activity";
        Description = "Use this endpoint to delete an activity.";
        ExampleRequest = new DeleteActivityRequest(
            CustomerId.New(),
            ActivityId.New());
        Response(
            200,
            "Activity deleted",
            MediaTypeNames.Application.Json,
            new CustomerResponse(
                CustomerId.New(),
                "CustomerName",
                "CustomerNumber",
                new List<ActivityResponse> { new(ActivityId.New(), "ActivityName"), }));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer or Activity not found");
    }
}