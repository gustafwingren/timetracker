// <copyright file="CustomerIdTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.CustomerAggregate.Valueobjects;

public class CustomerIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var customerId1 = CustomerId.New();
        var customerId2 = CustomerId.New();

        // Assert
        Assert.NotEqual(customerId1, customerId2);
    }
}