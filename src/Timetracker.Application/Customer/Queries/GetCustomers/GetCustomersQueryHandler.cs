// <copyright file="GetCustomersQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public sealed class
    GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerResponse>>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer>
        _customerRepository;

    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(
        IMapper mapper,
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerResponse>> Handle(
        GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.ListAsync(
            new GetCustomersSpecification(request.UserId),
            cancellationToken);

        return _mapper.Map<List<CustomerResponse>>(customers);
    }
}