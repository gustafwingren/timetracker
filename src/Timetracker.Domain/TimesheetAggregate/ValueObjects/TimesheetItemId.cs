// <copyright file="TimesheetItemId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Shared;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

public class TimesheetItemId : ValueObject
{
    private TimesheetItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TimesheetItemId CreateUniqueId()
    {
        return new TimesheetItemId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}