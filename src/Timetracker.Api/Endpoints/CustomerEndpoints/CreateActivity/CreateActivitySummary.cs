// <copyright file="CreateActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

public class CreateActivitySummary : Summary<CreateActivityEndpoint>
{
    public CreateActivitySummary()
    {
        Summary = "Create activity";
        Description = "Use this endpoint to add a Activity to an existing Customer";
        ExampleRequest = new CreateActivityRequest(Guid.NewGuid(), "Name of Activity");
        Response(
            201,
            "Activity created",
            example: new CustomerResponse(
                CustomerId.New(),
                "Name of Customer",
                "Customernumber",
                new List<ActivityResponse> { new(ActivityId.New(), "Name of Activity"), }));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer not found");
    }
}