// <copyright file="TimesheetTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.Common.Ids;
using Timetracker.Domain.CustomerAggregate;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Domain.TimesheetAggregate;
using Timetracker.Domain.TimesheetAggregate.Entities;
using Timetracker.Domain.TimesheetAggregate.ValueObjects;

namespace Timetracker.Domain.Tests.TimesheetAggregate;

public class TimesheetTest
{
    [Fact]
    public void Create_WithValidData_ShouldCreateTimesheet()
    {
        // Act
        var timesheet = Timesheet.Create(new DateTime(2023, 02, 23));

        // Assert
        Assert.NotNull(timesheet);
        Assert.NotNull(timesheet.Id);
        Assert.Empty(timesheet.Items);
        Assert.Equal(new DateTime(2023, 02, 23), timesheet.Date);
    }

    [Fact]
    public void AddItem_WithValidData_ShouldAddItemToTimesheet()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Act
        timesheet.AddItem(TimesheetItem.Create(customer, TimeSpan.FromHours(2)));

        // Assert
        Assert.NotEmpty(timesheet.Items);
        Assert.Collection(
            timesheet.Items,
            i =>
            {
                Assert.Null(i.Name);
                Assert.Equal(customer.Id, i.CustomerId);
                Assert.Equal(TimeSpan.FromHours(2), i.TimeAmount);
                Assert.Equal(customer.Activities.FirstOrDefault()?.Id, i.ActivityId);
            },
            i =>
            {
                Assert.Null(i.ActivityId);
                Assert.Equal(customer.Id, i.CustomerId);
                Assert.Equal(TimeSpan.FromHours(1), i.TimeAmount);
                Assert.Equal("timesheetItemName", i.Name);
            },
            i =>
            {
                Assert.Null(i.ActivityId);
                Assert.Null(i.Name);
                Assert.Equal(customer.Id, i.CustomerId);
                Assert.Equal(TimeSpan.FromHours(2), i.TimeAmount);
            });
    }

    [Fact]
    public void AddItem_WithInvalidData_ShouldThrow()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Assert/Act
        Assert.Throws<ArgumentNullException>(() => timesheet.AddItem(null!));
    }

    [Fact]
    public void RemoveItem_WithValidData_ShouldAddItemToTimesheet()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Act
        timesheet.RemoveItem(timesheet.Items.First());

        // Assert
        Assert.Single(timesheet.Items);
    }

    [Fact]
    public void RemoveItem_WithInValidData_ShouldThrow()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Assert/Act
        Assert.Throws<ArgumentNullException>(() => timesheet.RemoveItem(null!));
    }

    [Fact]
    public void UpdateTimesheetItemActivity_WithValidData_ShouldUpdateTimesheetItemCorrectly()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Act
        timesheet.UpdateTimesheetItemActivity(
            timesheet.Items.Last().Id,
            customer.Activities.First().Id);

        // Assert
        Assert.NotEmpty(timesheet.Items);
        Assert.Collection(
            timesheet.Items,
            i => { Assert.Equal(customer.Activities.First().Id, i.ActivityId); },
            i => { Assert.Equal(customer.Activities.First().Id, i.ActivityId); });
    }

    [Theory]
    [InlineData(true, false, typeof(ArgumentException))]
    [InlineData(false, true, typeof(ArgumentException))]
    public void UpdateTimesheetItemActivity_WithInvalidData_ShouldThrow(
        bool useOkTimeSheetItemId,
        bool useOkActivityId,
        Type exceptionType)
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Assert/Act
        Assert.Throws(
            exceptionType,
            () =>
            {
                timesheet.UpdateTimesheetItemActivity(
                    (useOkTimeSheetItemId ? timesheet.Items.First().Id : TimesheetItemId.Empty)!,
                    (useOkActivityId ? customer.Activities.First().Id : ActivityId.Empty)!);
            });
    }

    [Fact]
    public void UpdateTimesheetItemName_WithValidData_ShouldUpdateTimesheetItemCorrectly()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Act
        timesheet.UpdateTimesheetItemName(timesheet.Items.Last().Id, "newTimesheetItemName");

        // Assert
        Assert.Collection(
            timesheet.Items,
            i => { Assert.Null(i.Name); },
            i => { Assert.Equal("newTimesheetItemName", i.Name); });
    }

    [Theory]
    [InlineData(false, null, typeof(ArgumentNullException))]
    [InlineData(true, null, typeof(ArgumentNullException))]
    [InlineData(true, "", typeof(ArgumentException))]
    public void UpdateTimesheetItemName_WithInvalidData_ShouldThrow(
        bool useOkTimeSheetItemId,
        string? newName,
        Type exceptionType)
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Assert/Act
        Assert.Throws(
            exceptionType,
            () =>
            {
                timesheet.UpdateTimesheetItemName(
                    (useOkTimeSheetItemId ? timesheet.Items.First().Id : TimesheetItemId.Empty)!,
                    newName!);
            });
    }

    [Fact]
    public void UpdateTimesheetItemTimeAmount_WithValidData_ShouldUpdateTimesheetItemCorrectly()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Act
        timesheet.UpdateTimesheetItemTimeAmount(timesheet.Items.Last().Id, TimeSpan.FromHours(5));

        // Assert
        Assert.Collection(
            timesheet.Items,
            i => { Assert.Equal(TimeSpan.FromHours(2), i.TimeAmount); },
            i => { Assert.Equal(TimeSpan.FromHours(5), i.TimeAmount); });
    }

    [Fact]
    public void UpdateTimesheetItemTimeAmount_WithInvalidData_ShouldThrow()
    {
        // Arrange
        var customer = CreateDefaultCustomer();
        var timesheet = CreateDefaultTimesheet(customer);

        // Assert/Act
        Assert.Throws<ArgumentException>(
            () => timesheet.UpdateTimesheetItemTimeAmount(
                TimesheetItemId.Empty,
                TimeSpan.FromHours(5)));
    }

    private static Customer CreateDefaultCustomer()
    {
        var customer = Customer.Create("name", "customerNr", UserId.New());
        customer.AddActivity(Activity.Create("activityName"));

        return customer;
    }

    private static Timesheet CreateDefaultTimesheet(Customer customer)
    {
        var timesheet = Timesheet.Create(new DateTime(2023, 02, 23));
        timesheet.AddItem(
            TimesheetItem.Create(
                customer,
                TimeSpan.FromHours(2),
                customer.Activities.FirstOrDefault()));
        timesheet.AddItem(
            TimesheetItem.Create(customer, TimeSpan.FromHours(1), null, "timesheetItemName"));

        return timesheet;
    }
}