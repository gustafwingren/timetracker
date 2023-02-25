// <copyright file="TimesheetIdTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.TimesheetAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.TimesheetAggregate.ValueObjects;

public class TimesheetIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var timesheetId1 = TimesheetId.CreateUniqueId();
        var timesheetId2 = TimesheetId.CreateUniqueId();

        // Assert
        Assert.NotEqual(timesheetId1, timesheetId2);
    }
}