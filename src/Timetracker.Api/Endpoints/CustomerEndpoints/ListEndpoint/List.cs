using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetracker.Application.Customer.Queries.GetCustomers;
using Timetracker.Shared.Dtos;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.ListEndpoint;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<List<CustomerDto>>
{
    private readonly ISender _sender;

    public List(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("/customers")]
    public override async Task<ActionResult<List<CustomerDto>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var customers = await _sender.Send(new GetCustomersQuery(), cancellationToken);

        return customers;
    }
}