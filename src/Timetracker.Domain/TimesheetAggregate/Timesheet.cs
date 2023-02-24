using Ardalis.GuardClauses;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Domain.TimesheetAggregate.Entities;
using Timetracker.Domain.TimesheetAggregate.ValueObjects;
using Timetracker.Shared;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Domain.TimesheetAggregate;

public sealed class Timesheet : BaseEntity<TimesheetId>, IAggregateRoot
{
    private readonly List<TimesheetItem> _items = new();
    public IEnumerable<TimesheetItem> Items => _items.AsReadOnly();
    
    public DateTime Date { get; }

    private Timesheet(TimesheetId id, DateTime date)
    {
        Id = id;
        Date = date;
    }

    public static Timesheet Create(DateTime date) => new(TimesheetId.CreateUniqueId(), date);

    public void AddItem(TimesheetItem item)
    {
        Guard.Against.Null(item, nameof(item));
        _items.Add(item);
    }

    public void RemoveItem(TimesheetItem item)
    {
        Guard.Against.Null(item, nameof(item));
        _items.Remove(item);
    }

    public void UpdateTimesheetItemActivity(TimesheetItemId timesheetItemId, ActivityId activityId)
    {
        Guard.Against.Null(timesheetItemId, nameof(timesheetItemId));
        Guard.Against.Null(activityId, nameof(activityId));

        var timesheetItem = _items.FirstOrDefault(t => t.Id == timesheetItemId);

        timesheetItem?.UpdateActivity(activityId);
    }
    
    public void UpdateTimesheetItemName(TimesheetItemId timesheetItemId, string name)
    {
        Guard.Against.Null(timesheetItemId, nameof(timesheetItemId));
        Guard.Against.NullOrEmpty(name, nameof(name));

        var timesheetItem = _items.FirstOrDefault(t => t.Id == timesheetItemId);

        timesheetItem?.UpdateName(name);
    }
    
    public void UpdateTimesheetItemTimeAmount(TimesheetItemId timesheetItemId, TimeSpan timeAmount)
    {
        Guard.Against.Null(timesheetItemId, nameof(timesheetItemId));
        Guard.Against.Null(timeAmount, nameof(timeAmount));

        var timesheetItem = _items.FirstOrDefault(t => t.Id == timesheetItemId);

        timesheetItem?.UpdateTimeAmount(timeAmount);
    }
}