using Ardalis.GuardClauses;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.Entities;

public sealed class Activity : BaseEntity<ActivityId>
{
    public string Name { get; private set; }

    private Activity(ActivityId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Activity Create(string name) => new(ActivityId.CreateUniqueId(), name);

    public void UpdateName(string name)
    {
        Guard.Against.NullOrEmpty(name);
        Name = name;
    }
}