// <copyright file="DoesActivityExistOnCustomer.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace Timetracker.Domain.CustomerAggregate.Specifications;

public sealed class DoesActivityExistOnCustomer : SingleResultSpecification<Customer>
{
    public DoesActivityExistOnCustomer(Guid customerId, Guid activityId)
    {
        Query
            .Where(x => x.Id.Value == customerId)
            .Where(x => x.Activities.Any(a => a.Id.Value == activityId));
    }
}