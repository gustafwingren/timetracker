// <copyright file="CustomerTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.Common.Ids;
using Timetracker.Domain.CustomerAggregate;
using Timetracker.Domain.CustomerAggregate.Entities;

namespace Timetracker.Domain.Tests.CustomerAggregate;

public class CustomerTest
{
    [Fact]
    public void CreateCustomer_WithValidData_ShouldCreate()
    {
        // Act
        var expectedCustomer = Customer.Create("name", "customerNr", UserId.New());

        // Assert
        Assert.NotNull(expectedCustomer);
        Assert.NotNull(expectedCustomer.Id);
        Assert.Equal("name", expectedCustomer.Name);
        Assert.Equal("customerNr", expectedCustomer.CustomerNr);
    }

    [Fact]
    public void AddActivity_WithValidData_ShouldContainCorrectActivity()
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        customer.AddActivity(Activity.Create("activityName"));

        // Assert
        Assert.NotNull(customer);
        Assert.NotEmpty(customer.Activities);
        Assert.Collection(customer.Activities, a => Assert.Equal("activityName", a.Name));
    }

    [Fact]
    public void AddActivity_WithInvalidData_ShouldThrowException()
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        Assert.Throws<ArgumentNullException>(() => customer.AddActivity(null!));
    }

    [Fact]
    public void UpdateName_WithValidData_ShouldUpdateCorrectly()
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        customer.UpdateName("newName");

        // Assert
        Assert.Equal("newName", customer.Name);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentNullException))]
    [InlineData("", typeof(ArgumentException))]
    public void UpdateName_WithInvalidData_ShouldThrowException(string? name, Type exceptionType)
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        Assert.Throws(exceptionType, () => customer.UpdateName(name!));
    }

    [Fact]
    public void UpdateCustomerNr_WithValidData_ShouldUpdateCorrectly()
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        customer.UpdateCustomerNr("newCustomerNr");

        // Assert
        Assert.Equal("newCustomerNr", customer.CustomerNr);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentNullException))]
    [InlineData("", typeof(ArgumentException))]
    public void UpdateCustomerNr_WithInvalidData_ShouldThrowException(
        string? customerNr,
        Type exceptionType)
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());

        // Act
        Assert.Throws(exceptionType, () => customer.UpdateCustomerNr(customerNr!));
    }

    [Fact]
    public void UpdateActivityName_WithValidData_ShouldUpdateCorrectly()
    {
        // Arrange
        var customer = Customer.Create("name", "customerNr", UserId.New());
        customer.AddActivity(Activity.Create("activityName"));
        var activityId = customer.Activities.FirstOrDefault();

        // Act
        customer.UpdateActivityName(activityId!.Id, "newActivityName");

        // Assert
        Assert.NotEmpty(customer.Activities);
        Assert.Collection(customer.Activities, a => Assert.Equal("newActivityName", a.Name));
    }
}