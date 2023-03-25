// <copyright file="CreateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Timetracker.Application.Customer.Commands.CreateCustomer;
using Timetracker.Domain.Common.Ids;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;
using ActivityDto = Timetracker.Shared.Contracts.Requests.ActivityDto;

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
        var userId = HttpContext.User.GetObjectId();

        if (userId == null)
        {
            throw new UnauthorizedAccessException();
        }

        var customer = await _sender.Send(
            new CreateCustomerCommand(
                req.Name,
                req.Number,
                req.Activities.Select(x => new ActivityDto(x.Name)).ToList(),
                new UserId(Guid.Parse(userId))),
            ct);

        await SendOkAsync(customer, ct);
    }
}