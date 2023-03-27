// <copyright file="CreateActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Summaries.Customer;

public class CreateActivitySummary : Summary<CreateActivityEndpoint>
{
    public CreateActivitySummary()
    {
        Summary = "Create activity";
        Description = "Use this endpoint to add a Activity to an existing Customer";
        ExampleRequest = new CreateActivityRequest(CustomerId.New(), "Name of Activity");
        Response(
            200,
            "ok response with body",
            example: new CustomerResponse(
                CustomerId.New(),
                "Name of Customer",
                "Customernumber",
                new List<ActivityResponse> { new(ActivityId.New(), "Name of Activity"), }));
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "Customer not found");
    }
}