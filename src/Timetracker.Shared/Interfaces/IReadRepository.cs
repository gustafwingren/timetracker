using Ardalis.Specification;

namespace Timetracker.Shared.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot 
{
}