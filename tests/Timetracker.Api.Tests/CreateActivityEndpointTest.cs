// <copyright file="CreateActivityEndpointTest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using NSubstitute;
using Timetracker.Api.Endpoints.CustomerEndpoints;
using Timetracker.Application.Customer.Commands.AddActivity;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Tests;

public class CreateActivityEndpointTest
{
    private readonly ISender _sender;
    private readonly CreateActivityEndpoint _sut;

    public CreateActivityEndpointTest()
    {
        _sender = Substitute.For<ISender>();
        _sut = new CreateActivityEndpoint(_sender);
    }

    [Fact]
    public async Task ExecuteAsync_HappyFlow()
    {
        // Arrange
        var request = new CreateActivityRequest(Guid.NewGuid(), "NewActivity");
        _sender.Send(default).ReturnsForAnyArgs(
            new CustomerDto(
                request.Id,
                "CustomerName",
                "CustomerNumber",
                new List<ActivityDto> { new(Guid.NewGuid(), "NewActivity"), }));

        // Act
        var result = await _sut.ExecuteAsync(request, default);

        // Assert
        Assert.NotNull(result);
        await _sender.Received().Send(Arg.Any<AddActivityCommand>());
    }
}