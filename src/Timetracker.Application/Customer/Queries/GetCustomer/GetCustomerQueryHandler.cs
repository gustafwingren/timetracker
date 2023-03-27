// <copyright file="GetCustomerQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer>
        _customerRepository;

    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(
        IMapper mapper,
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customer =
            await _customerRepository.GetByIdAsync(
                request.Id,
                cancellationToken);

        if (customer == null)
        {
            // TODO: Return error
        }

        return _mapper.Map<CustomerResponse>(customer);
    }
}