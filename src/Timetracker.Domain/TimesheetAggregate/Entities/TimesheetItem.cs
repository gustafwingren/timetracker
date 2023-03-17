// <copyright file="TimesheetItem.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using Timetracker.Domain.CustomerAggregate;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Domain.TimesheetAggregate.ValueObjects;
using Timetracker.Shared;

namespace Timetracker.Domain.TimesheetAggregate.Entities;

public sealed class TimesheetItem : BaseEntity<TimesheetItemId>
{
    private TimesheetItem(
        TimesheetItemId id,
        CustomerId customerId,
        TimeSpan timeAmount,
        ActivityId? activityId = null,
        string? name = null)
        : base(id)
    {
        CustomerId = customerId;
        TimeAmount = timeAmount;
        ActivityId = activityId;
        Name = name;
    }

    public CustomerId CustomerId { get; }

    public ActivityId? ActivityId { get; private set; }

    public string? Name { get; private set; }

    public TimeSpan TimeAmount { get; private set; }

    public static TimesheetItem Create(
        Customer customer,
        TimeSpan timeAmount,
        Activity? activity = null,
        string? name = null)
    {
        return new TimesheetItem(
            TimesheetItemId.New(),
            customer.Id,
            timeAmount,
            activity?.Id,
            name);
    }

    public void UpdateActivity(ActivityId activityId)
    {
        Guard.Against.Null(activityId, nameof(activityId));
        ActivityId = activityId;
    }

    public void UpdateName(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }

    public void UpdateTimeAmount(TimeSpan timeAmount)
    {
        Guard.Against.Null(timeAmount, nameof(timeAmount));
        TimeAmount = timeAmount;
    }
}