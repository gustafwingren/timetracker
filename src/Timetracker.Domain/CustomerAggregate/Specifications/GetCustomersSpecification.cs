// <copyright file="GetCustomersSpecification.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Domain.CustomerAggregate.Specifications;

public sealed class GetCustomersSpecification : Specification<Customer>
{
    public GetCustomersSpecification(UserId userId, int? page = null, int? pageSize = null)
    {
        Query.Where(x => x.UserId == userId);

        if (page == null || pageSize == null)
        {
            return;
        }

        Query.Skip((page.Value - 1) * pageSize.Value);

        Query.Take(pageSize.Value);
    }
}