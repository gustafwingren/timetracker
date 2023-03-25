// <copyright file="CreateActivitySummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using Timetracker.Api.Endpoints.CustomerEndpoints;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;
using ActivityDto = Timetracker.Shared.Contracts.Responses.ActivityDto;

namespace Timetracker.Api.Summaries.Customer;

public class CreateActivitySummary : Summary<CreateActivityEndpoint>
{
    public CreateActivitySummary()
    {
        Summary = "Create activity";
        Description = "Use this endpoint to add a Activity to an existing Customer";
        ExampleRequest = new CreateActivityRequest(Guid.NewGuid(), "Name of Activity");
        Response(
            200,
            "ok response with body",
            example: new CustomerDto(
                Guid.NewGuid(),
                "Name of Customer",
                "Customernumber",
                new List<ActivityDto> { new(Guid.NewGuid(), "Name of Activity"), }));
        Response<ErrorResponse>(400, "validation failure");
        Response(404, "Customer not found");
    }
}