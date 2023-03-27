// <copyright file="DoesActivityExistOnCustomer.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Domain.CustomerAggregate.Specifications;

public sealed class DoesActivityExistOnCustomer : SingleResultSpecification<Customer>
{
    public DoesActivityExistOnCustomer(CustomerId customerId, ActivityId activityId)
    {
        Query
            .Where(x => x.Id == customerId)
            .Where(x => x.Activities.Any(a => a.Id == activityId));
    }
}