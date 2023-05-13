// <copyright file="GetAllCustomersEndpoint.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FastEndpoints;
using MediatR;
using Microsoft.Identity.Web;
using Timetracker.Application.Contracts;
using Timetracker.Application.Customer.Queries.GetCustomers;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetAllCustomers;

public class
    GetAllCustomersEndpoint : Endpoint<GetAllCustomersRequest, PagedResponse<CustomerResponse>>
{
    private readonly ISender _sender;

    public GetAllCustomersEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("customers");
    }

    public override async Task HandleAsync(GetAllCustomersRequest request, CancellationToken ct)
    {
        var userId = HttpContext.User.GetObjectId();

        if (userId == null)
        {
            await SendUnauthorizedAsync(ct);
        }

        var customers = await _sender.Send(
            new GetCustomersQuery(new UserId(Guid.Parse(userId)), request.Page, request.PageSize),
            ct);

        await SendInterceptedAsync(customers, cancellation: ct);
    }
}