// <copyright file="BaseEntity.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared;

public abstract class BaseEntity<T>
    where T : notnull
{
    protected BaseEntity(T id)
    {
        Id = id;
    }

    public T Id { get; set; }
}