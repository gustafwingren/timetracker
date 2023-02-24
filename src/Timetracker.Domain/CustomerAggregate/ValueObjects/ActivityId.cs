using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.ValueObjects;

public sealed class ActivityId : ValueObject
{
    public Guid Value { get; }

    private ActivityId(Guid value)
    {
        Value = value;
    }

    public static ActivityId CreateUniqueId() => new(Guid.NewGuid());
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}