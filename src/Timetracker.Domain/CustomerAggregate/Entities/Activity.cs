// <copyright file="Activity.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.Entities;

public sealed class Activity : BaseEntity<ActivityId>
{
    private Activity(ActivityId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public static Activity Create(string name)
    {
        return new Activity(ActivityId.CreateUniqueId(), name);
    }

    public void UpdateName(string name)
    {
        Guard.Against.NullOrEmpty(name);
        Name = name;
    }
}