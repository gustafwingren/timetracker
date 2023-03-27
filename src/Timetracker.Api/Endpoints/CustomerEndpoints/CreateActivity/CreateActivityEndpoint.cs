// <copyright file="CreateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.AddActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

[HttpPost("customers/{Id:Guid}/activities")]
[Authorize]
public sealed class CreateActivityEndpoint : Endpoint<CreateActivityRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public CreateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(CreateActivityRequest req, CancellationToken ct)
    {
        var command = new AddActivityCommand(req.Id, req.Name);
        var customer = await _sender.Send(command, ct);

        await SendOkAsync(customer, ct);
    }
}