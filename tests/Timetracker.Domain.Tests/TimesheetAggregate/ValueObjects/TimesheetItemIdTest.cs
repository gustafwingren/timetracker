// <copyright file="TimesheetItemIdTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.TimesheetAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.TimesheetAggregate.ValueObjects;

public class TimesheetItemIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var timesheetItemId1 = TimesheetItemId.New();
        var timesheetItemId2 = TimesheetItemId.New();

        // Assert
        Assert.NotEqual(timesheetItemId1, timesheetItemId2);
    }
}