// <copyright file="CosmosDbContext.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Timetracker.Domain.CustomerAggregate;

namespace Timetracker.Infrastructure.Persistence;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CosmosDbContext).Assembly);
    }
}