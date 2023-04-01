// <copyright file="GetAllCustomersSummary.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetAllCustomers;

public class GetAllCustomersSummary : Summary<GetAllCustomersEndpoint>
{
    public GetAllCustomersSummary()
    {
        Summary = "Get all customers";
        Description = "Use this endpoint to get all customers";
        ExampleRequest = new EmptyRequest();
        Response(
            200,
            "Customers for current user",
            MediaTypeNames.Application.Json,
            new List<CustomerResponse>
            {
                new(
                    CustomerId.New(),
                    "Customer name",
                    "Customer number",
                    new List<ActivityResponse> { new(ActivityId.New(), "Activity name"), }),
            });
        Response(400, "Bad request");
        Response(401, "Unauthorized");
    }
}