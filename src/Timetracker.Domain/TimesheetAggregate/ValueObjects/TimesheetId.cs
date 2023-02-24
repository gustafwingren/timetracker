using Timetracker.Shared;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

public sealed class TimesheetId : ValueObject
{
    public Guid Value { get; }
    
    private TimesheetId(Guid guid)
    {
        Value = guid;
    }

    public static TimesheetId CreateUniqueId() => new(Guid.NewGuid());
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}