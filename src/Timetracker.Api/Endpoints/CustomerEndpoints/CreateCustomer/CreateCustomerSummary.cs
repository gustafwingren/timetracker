// <copyright file="CreateCustomerSummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateCustomer;

public class CreateCustomerSummary : Summary<CreateCustomerEndpoint>
{
    public CreateCustomerSummary()
    {
        Summary = "Create customer";
        Description = "Use this endpoint to add a Customer";
        ExampleRequest = new CreateCustomerRequest(
            "Name of Customer",
            "CustomerNumber",
            new List<CreateCustomerRequest.ActivityRequest> { new("Name of Activity"), });
        Response(
            201,
            "Customer created",
            MediaTypeNames.Application.Json,
            new CustomerResponse(
                CustomerId.New(),
                "Name of Customer",
                "CustomerNumber",
                new List<ActivityResponse> { new(ActivityId.New(), "Name of Activity"), }));
        Response(
            400,
            "Bad request");
        Response(
            401,
            "Unauthorized");
    }
}