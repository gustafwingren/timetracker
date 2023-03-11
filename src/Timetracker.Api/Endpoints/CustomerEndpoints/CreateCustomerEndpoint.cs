// <copyright file="CreateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.CreateCustomer;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpPost("customers")]
[Authorize]
public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerDto>
{
    private readonly ISender _sender;

    public CreateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(
        CreateCustomerRequest req,
        CancellationToken ct)
    {
        var customer = await _sender.Send(
            new CreateCustomerCommand(req.Name, req.Number),
            ct);

        await SendOkAsync(customer, ct);
    }
}