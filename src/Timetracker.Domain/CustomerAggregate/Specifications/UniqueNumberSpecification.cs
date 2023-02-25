// <copyright file="UniqueNumberSpecification.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace Timetracker.Domain.CustomerAggregate.Specifications;

public sealed class UniqueNumberSpecification : Specification<Customer>
{
    public UniqueNumberSpecification(string number)
    {
        Query.Where(c => c.CustomerNr == number);
    }
}