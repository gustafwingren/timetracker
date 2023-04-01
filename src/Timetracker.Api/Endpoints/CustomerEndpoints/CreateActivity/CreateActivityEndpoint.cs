// <copyright file="CreateActivityEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Timetracker.Api.Extensions;
using Timetracker.Application.Customer.Commands.AddActivity;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

public sealed class CreateActivityEndpoint : Endpoint<CreateActivityRequest, IResult>
{
    private readonly ISender _sender;

    public CreateActivityEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("customers/{@cId}/activities", x => new { x.Id, });
    }

    public override async Task<IResult> ExecuteAsync(
        CreateActivityRequest req,
        CancellationToken ct)
    {
        var command = new AddActivityCommand(req.Id, req.Name);
        var customer = await _sender.Send(command, ct);

        return HttpContext.CreateCreatedResponse(customer);
    }
}