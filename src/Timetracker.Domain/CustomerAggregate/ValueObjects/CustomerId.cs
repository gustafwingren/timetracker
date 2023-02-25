// <copyright file="CustomerId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
    private CustomerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static CustomerId CreateUniqueId()
    {
        return new CustomerId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}