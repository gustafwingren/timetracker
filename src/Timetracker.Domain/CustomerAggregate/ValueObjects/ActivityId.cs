// <copyright file="ActivityId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.ValueObjects;

public sealed class ActivityId : ValueObject
{
    private ActivityId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ActivityId CreateUniqueId()
    {
        return new ActivityId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}