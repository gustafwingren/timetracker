using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetracker.Application.Customer.Commands.CreateCustomer;
using Timetracker.Shared.Dtos;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateEndpoint;

public class Create : EndpointBaseAsync.WithRequest<CreateRequest>.WithActionResult<CustomerDto>
{
    private readonly ISender _sender;

    public Create(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("/customers")]
    public override async Task<ActionResult<CustomerDto>> HandleAsync(
        CreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var customer = await _sender.Send(
            new CreateCustomerCommand(request.Name, request.Number),
            cancellationToken);

        return Ok(customer);
    }
}