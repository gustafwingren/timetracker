// <copyright file="TimesheetId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Shared;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

public sealed class TimesheetId : ValueObject
{
    private TimesheetId(Guid guid)
    {
        Value = guid;
    }

    public Guid Value { get; }

    public static TimesheetId CreateUniqueId()
    {
        return new TimesheetId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}