// <copyright file="CreateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.AddActivity;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

public sealed class CreateActivityEndpoint : Endpoint<CreateActivityRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public CreateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("customers/{CustomerId:Guid}/activities");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(CreateActivityRequest req, CancellationToken ct)
    {
        var command = new AddActivityCommand(new CustomerId(req.CustomerId), req.Name);
        var customer = await _sender.Send(command, ct);

        await SendInterceptedAsync(customer, 200, ct);
    }
}