// <copyright file="UpdateCustomerSummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public class UpdateCustomerSummary : Summary<UpdateCustomerEndpoint>
{
    public UpdateCustomerSummary()
    {
        Summary = "Update a customer";
        Description = "Use this endpoint to update a customer";
        ExampleRequest = new UpdateCustomerRequest(CustomerId.New(), "New name", "New number");
        Response(
            200,
            "Customer updated",
            MediaTypeNames.Application.Json,
            new CustomerResponse(
                CustomerId.New(),
                "New name",
                "New number",
                new List<ActivityResponse> { new(ActivityId.New(), "Activity name"), }));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer not found");
    }
}