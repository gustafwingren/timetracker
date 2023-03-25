// <copyright file="CustomerConfiguration.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timetracker.Domain.Common.Ids;
using Timetracker.Domain.CustomerAggregate;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToContainer("Customer")
            .HasPartitionKey(x => x.Id)
            .OwnsMany(x => x.Activities);

        builder.Property(x => x.Id)
            .HasConversion(
                new ValueConverter<CustomerId, Guid>(c => c.Value, guid => new CustomerId(guid)));

        builder.Property(x => x.UserId)
            .HasConversion(
                new ValueConverter<UserId, Guid>(c => c.Value, guid => new UserId(guid)));
    }
}