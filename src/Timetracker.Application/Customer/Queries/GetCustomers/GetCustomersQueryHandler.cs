// <copyright file="GetCustomersQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Dtos;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public sealed class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _customerRepository;

    public GetCustomersQueryHandler(
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> Handle(
        GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.ListAsync(
            new GetCustomersSpecification(),
            cancellationToken);

        return customers.Select(
            c => new CustomerDto
            {
                Id = c.Id.Value,
                Name = c.Name,
                Number = c.CustomerNr,
            }).ToList();
    }
}