// <copyright file="CreateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.AddActivity;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpPost("customers/{Id:Guid}/activities")]
[Authorize]
public sealed class CreateActivityEndpoint : Endpoint<CreateActivityRequest, CustomerDto>
{
    private readonly ISender _sender;

    public CreateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<CustomerDto> ExecuteAsync(
        CreateActivityRequest req,
        CancellationToken ct)
    {
        var command = new AddActivityCommand(req.Id, req.Name);
        var customer = await _sender.Send(command, ct);

        return customer;
    }
}