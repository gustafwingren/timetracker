using Ardalis.Specification;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Infrastructure.Repository;

public class ListRepository<T> : IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    private static readonly List<T> _items = new();

    private readonly List<IEvaluator> evaluators = new();

    public ListRepository()
    {
        evaluators.AddRange(
            new IEvaluator[]
            {
                WhereEvaluator.Instance,
                OrderEvaluator.Instance,
                PaginationEvaluator.Instance,
            });
    }

    public Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = new())
        where TId : notnull
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetBySpecAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> GetBySpecAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        return Task.FromResult(ApplySpecification(specification).FirstOrDefault());
    }

    public Task<TResult?> FirstOrDefaultAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<T?> SingleOrDefaultAsync(
        ISingleResultSpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        return Task.FromResult(ApplySpecification(specification).SingleOrDefault());
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>(
        ISingleResultSpecification<T, TResult> specification,
        CancellationToken cancellationToken = new())
    {
        return Task.FromResult(ApplySpecification(specification).SingleOrDefault());
    }

    public Task<List<T>> ListAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> ListAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        var queryResult = ApplySpecification(specification).ToList();

        return specification.PostProcessingAction == null
            ? queryResult
            : specification.PostProcessingAction(queryResult).ToList();
    }

    public Task<List<TResult>> ListAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = new())
    {
        _items.Add(entity);
        return Task.FromResult(_items.LastOrDefault());
    }

    public Task<IEnumerable<T>> AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = new())
    {
        _items.Remove(entity);
        _items.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return Task.FromResult(1);
    }

    /// <summary>
    ///     Filters the entities  of <typeparamref name="T" />, to those that match the encapsulated query
    ///     logic of the
    ///     <paramref name="specification" />.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered entities as an <see cref="IQueryable{T}" />.</returns>
    protected virtual IQueryable<T> ApplySpecification(
        ISpecification<T> specification,
        bool evaluateCriteriaOnly = false)
    {
        return GetQuery(_items.AsQueryable(), specification, evaluateCriteriaOnly);
    }

    /// <summary>
    ///     Filters all entities of <typeparamref name="T" />, that matches the encapsulated query logic of
    ///     the
    ///     <paramref name="specification" />, from the database.
    ///     <para>
    ///         Projects each entity into a new form, being <typeparamref name="TResult" />.
    ///     </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered projected entities as an <see cref="IQueryable{T}" />.</returns>
    protected virtual IQueryable<TResult> ApplySpecification<TResult>(
        ISpecification<T, TResult> specification)
    {
        return GetQuery(_items.AsQueryable(), specification);
    }

    public virtual IQueryable<TResult> GetQuery<T, TResult>(
        IQueryable<T> query,
        ISpecification<T, TResult> specification)
        where T : class
    {
        if (specification is null)
        {
            throw new ArgumentNullException("Specification is required");
        }

        if (specification.Selector is null)
        {
            throw new SelectorNotFoundException();
        }

        query = GetQuery(query, (ISpecification<T>)specification);

        return query.Select(specification.Selector);
    }

    public virtual IQueryable<T> GetQuery<T>(
        IQueryable<T> query,
        ISpecification<T> specification,
        bool evaluateCriteriaOnly = false)
        where T : class
    {
        if (specification is null)
        {
            throw new ArgumentNullException("Specification is required");
        }

        var evaluators = evaluateCriteriaOnly
            ? this.evaluators.Where(x => x.IsCriteriaEvaluator)
            : this.evaluators;

        foreach (var evaluator in evaluators) query = evaluator.GetQuery(query, specification);

        return query;
    }
}