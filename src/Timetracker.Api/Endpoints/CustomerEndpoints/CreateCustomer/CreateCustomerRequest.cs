// <copyright file="CreateCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateCustomer;

public record CreateCustomerRequest(
    string Name,
    string Number,
    List<CreateCustomerRequest.ActivityRequest>? Activities)
{
    public record ActivityRequest(string Name);
}