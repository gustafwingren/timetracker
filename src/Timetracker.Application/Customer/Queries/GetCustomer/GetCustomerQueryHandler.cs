// <copyright file="GetCustomerQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Dtos;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _customerRepository;

    public GetCustomerQueryHandler(
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customer =
            await _customerRepository.SingleOrDefaultAsync(
                new GetByIdSpecification(request.Id),
                cancellationToken);

        if (customer == null)
        {
            // TODO: Return error
        }

        return new CustomerDto
        {
            Id = customer.Id.Value,
            Name = customer.Name,
            Number = customer.CustomerNr,
        };
    }
}