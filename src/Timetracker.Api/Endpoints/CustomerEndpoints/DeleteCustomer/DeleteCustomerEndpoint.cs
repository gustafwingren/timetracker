// <copyright file="DeleteCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.DeleteCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteCustomer;

[HttpDelete("customers/{id:CustomerId}")]
[Authorize]
public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest>
{
    private readonly ISender _sender;

    public DeleteCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(DeleteCustomerRequest req, CancellationToken ct)
    {
        var command = new DeleteCustomerCommand(req.Id);
        await _sender.Send(command, ct);

        await SendOkAsync(ct);
    }
}