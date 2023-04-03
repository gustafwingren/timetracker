// <copyright file="CustomerResponseMap.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Application.Contracts;

namespace Timetracker.Application.Mapping;

public static class CustomerResponseMap
{
    public static CustomerResponse Map(this Domain.CustomerAggregate.Customer customer)
    {
        return new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.CustomerNr,
            customer.Activities.Select(x => x.Map()));
    }
}