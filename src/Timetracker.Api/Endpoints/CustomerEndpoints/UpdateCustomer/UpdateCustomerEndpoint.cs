// <copyright file="UpdateCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Api.Extensions;
using Timetracker.Application.Customer.Commands.UpdateCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, IResult>
{
    private readonly ISender _sender;

    public UpdateCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("customers/{@cId}", x => new { x.Id, });
    }

    public override async Task<IResult> ExecuteAsync(
        UpdateCustomerRequest req,
        CancellationToken ct)
    {
        var customer = await _sender.Send(
            new UpdateCustomerCommand(req.Id, req.Name, req.Number),
            ct);

        return HttpContext.CreateOkResponse(customer);
    }
}