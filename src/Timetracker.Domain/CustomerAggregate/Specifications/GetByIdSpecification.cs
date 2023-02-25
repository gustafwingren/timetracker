// <copyright file="GetByIdSpecification.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace Timetracker.Domain.CustomerAggregate.Specifications;

public sealed class GetByIdSpecification : SingleResultSpecification<Customer>
{
    public GetByIdSpecification(Guid id)
    {
        Query
            .Where(c => c.Id.Value == id);
    }
}