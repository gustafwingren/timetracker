// <copyright file="UpdateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Timetracker.Application.Customer.Commands.UpdateCustomer;
using Timetracker.Shared.Contracts.Requests;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Api.Endpoints.CustomerEndpoints;

[HttpPut("customers/{id:Guid}")]
[Authorize]
public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerDto>
{
    private readonly ISender _sender;

    public UpdateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override async Task HandleAsync(
        UpdateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var customer = await _sender.Send(
            new UpdateCustomerCommand(request.Id, request.Name, request.Number),
            cancellationToken);

        if (customer == null)
        {
            await SendNotFoundAsync(cancellationToken);
        }


        await SendOkAsync(customer, cancellationToken);
    }
}