// <copyright file="ActivityIdTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.CustomerAggregate.Valueobjects;

public class ActivityIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var activityId1 = ActivityId.New();
        var activityId2 = ActivityId.New();

        // Assert
        Assert.NotEqual(activityId1, activityId2);
    }
}