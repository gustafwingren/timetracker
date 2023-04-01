// <copyright file="GetCustomerSummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetCustomer;

public class GetCustomerSummary : Summary<GetCustomerEndpoint>
{
    public GetCustomerSummary()
    {
        Summary = "Get a customer";
        Description = "Use this endpoint to get a customer";
        ExampleRequest = new GetCustomerRequest(CustomerId.New());
        Response(
            200,
            "Customer",
            MediaTypeNames.Application.Json,
            new CustomerResponse(
                CustomerId.New(),
                "Customer Name",
                "Customer number",
                new List<ActivityResponse> { new(ActivityId.New(), "Activity name"), }));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
        Response(404, "Customer not found");
    }
}