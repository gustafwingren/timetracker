using Timetracker.Shared;

namespace Timetracker.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
    public Guid Value { get; }

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId CreateUniqueId() => new(Guid.NewGuid());
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}