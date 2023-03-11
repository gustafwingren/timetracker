// <copyright file="UpdateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.UpdateActivity;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpPut("customers/{CustomerId:Guid}/activities/{ActivityId:Guid}")]
[Authorize]
public sealed class UpdateActivityEndpoint : Endpoint<UpdateActivityRequest, CustomerDto>
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