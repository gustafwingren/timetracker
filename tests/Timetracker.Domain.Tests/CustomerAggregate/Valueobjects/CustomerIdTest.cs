using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.CustomerAggregate.Valueobjects;

public class CustomerIdTest
{
    [Fact]
    public void CreateUniqueId_ShouldBeUnique()
    {
        // Act
        var customerId1 = CustomerId.CreateUniqueId();
        var customerId2 = CustomerId.CreateUniqueId();

        // Assert
        Assert.NotEqual(customerId1, customerId2);
    }
}