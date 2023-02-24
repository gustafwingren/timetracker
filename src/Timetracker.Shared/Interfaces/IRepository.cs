using Ardalis.Specification;

namespace Timetracker.Shared.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}