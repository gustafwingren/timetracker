// <copyright file="CreateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.Identity.Web;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Commands.CreateCustomer;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateCustomer;

public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerResponse>
{
    private readonly ISender _sender;

    public CreateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("customers");
    }

    public override async Task HandleAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var userId = HttpContext.User.GetObjectId();

        if (userId == null)
        {
            await SendUnauthorizedAsync(ct);
        }

        var customer = await _sender.Send(
            new CreateCustomerCommand(
                req.Name,
                req.Number,
                req.Activities?.Select(x => new ActivityCommandDto(x.Name)).ToList(),
                new UserId(Guid.Parse(userId))),
            ct);

        await SendInterceptedAsync(customer, cancellation: ct);
    }
}