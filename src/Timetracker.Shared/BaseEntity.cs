namespace Timetracker.Shared;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}