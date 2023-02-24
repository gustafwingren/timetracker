using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.CustomerAggregate.Valueobjects;

public class ActivityIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var activityId1 = ActivityId.CreateUniqueId();
        var activityId2 = ActivityId.CreateUniqueId();

        // Assert
        Assert.NotEqual(activityId1, activityId2);
    }
}