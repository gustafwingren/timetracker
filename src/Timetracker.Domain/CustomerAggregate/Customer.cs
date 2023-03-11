// <copyright file="Customer.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Domain.CustomerAggregate;

public sealed class Customer : BaseEntity<CustomerId>, IAggregateRoot
{
    private readonly List<Activity> _activities = new();

    private Customer(CustomerId customerId, string name, string customerNr)
        : base(customerId)
    {
        Name = name;
        CustomerNr = customerNr;
    }

    public IEnumerable<Activity> Activities => _activities.AsReadOnly();

    public string Name { get; private set; }

    public string CustomerNr { get; private set; }

    public static Customer Create(string name, string customerNr)
    {
        Guard.Against.NullOrEmpty(name);
        Guard.Against.NullOrEmpty(customerNr);
        return new Customer(CustomerId.CreateUniqueId(), name, customerNr);
    }

    public void AddActivity(Activity activity)
    {
        Guard.Against.Null(activity, nameof(activity));
        _activities.Add(activity);
    }

    public void RemoveActivity(Activity activity)
    {
        Guard.Against.Null(activity);
        _activities.Remove(activity);
    }

    public void UpdateName(string newName)
    {
        Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    }

    public void UpdateCustomerNr(string newCustomerNr)
    {
        CustomerNr = Guard.Against.NullOrEmpty(newCustomerNr, nameof(newCustomerNr));
    }

    public void UpdateActivityName(ActivityId activityId, string name)
    {
        Guard.Against.Null(activityId, nameof(activityId));
        Guard.Against.NullOrEmpty(name, nameof(name));

        var activity = _activities.FirstOrDefault(a => a.Id == activityId);

        activity?.UpdateName(name);
    }
}