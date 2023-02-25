// <copyright file="IRepository.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace Timetracker.Shared.Interfaces;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}