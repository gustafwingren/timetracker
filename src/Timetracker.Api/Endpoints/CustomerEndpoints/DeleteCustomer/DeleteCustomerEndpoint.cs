// <copyright file="DeleteCustomerEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Api.Extensions;
using Timetracker.Application.Customer.Commands.DeleteCustomer;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteCustomer;

public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest, IResult>
{
    private readonly ISender _sender;

    public DeleteCustomerEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("customers/{@cId}", x => new { x.Id, });
    }

    public override async Task<IResult> ExecuteAsync(
        DeleteCustomerRequest req,
        CancellationToken ct)
    {
        var command = new DeleteCustomerCommand(req.Id);
        var result = await _sender.Send(command, ct);

        return HttpContext.CreateOkResponse(result);
    }
}