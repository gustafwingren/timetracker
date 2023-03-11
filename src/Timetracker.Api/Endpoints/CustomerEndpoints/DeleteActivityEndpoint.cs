// <copyright file="DeleteActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.DeleteActivity;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpDelete("customers/{CustomerId:Guid}/activities/{ActivityId:Guid}")]
[Authorize]
public sealed class DeleteActivityEndpoint : Endpoint<DeleteActivityRequest, CustomerDto>
{
    private readonly ISender _sender;

    public DeleteActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(DeleteActivityRequest req, CancellationToken ct)
    {
        var command = new DeleteActivityCommand(req.CustomerId, req.ActivityId);
        var customer = await _sender.Send(command, ct);

        await SendOkAsync(customer, ct);
    }
}