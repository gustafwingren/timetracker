// <copyright file="DeleteActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.DeleteActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteActivity;

[HttpDelete("customers/{CustomerId:CustomerId}/activities/{ActivityId:ActivityId}")]
[Authorize]
public sealed class DeleteActivityEndpoint : Endpoint<DeleteActivityRequest, CustomerResponse>
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