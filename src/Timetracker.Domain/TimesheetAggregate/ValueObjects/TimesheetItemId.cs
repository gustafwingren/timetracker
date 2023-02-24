using Timetracker.Shared;

namespace Timetracker.Domain.TimesheetAggregate.ValueObjects;

public class TimesheetItemId : ValueObject
{
    public Guid Value { get; }

    private TimesheetItemId(Guid value)
    {
        Value = value;
    }

    public static TimesheetItemId CreateUniqueId() => new(Guid.NewGuid());
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}