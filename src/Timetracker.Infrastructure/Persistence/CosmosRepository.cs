// <copyright file="CosmosRepository.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Infrastructure.Persistence;

public class CosmosRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public CosmosRepository(CosmosDbContext cosmosDbContext)
        : base(cosmosDbContext)
    {
    }

    public CosmosRepository(
        CosmosDbContext CosmosDbContext,
        ISpecificationEvaluator specificationEvaluator)
        : base(CosmosDbContext, specificationEvaluator)
    {
    }
}