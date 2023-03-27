// <copyright file="UpdateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.UpdateActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

[HttpPut("customers/{CustomerId:CustomerId}/activities/{ActivityId:Guid}")]
[Authorize]
public sealed class UpdateActivityEndpoint : Endpoint<UpdateActivityRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public UpdateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(UpdateActivityRequest req, CancellationToken ct)
    {
        var command = new UpdateActivityCommand(req.CustomerId, req.ActivityId, req.Name);
        var customer = await _sender.Send(command, ct);

        await SendOkAsync(customer, ct);
    }
}