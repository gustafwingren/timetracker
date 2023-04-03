// <copyright file="GetCustomerQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Mapping;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ErrorOr<CustomerResponse>>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer>
        _customerRepository;

    public GetCustomerQueryHandler(
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customer =
            await _customerRepository.GetByIdAsync(
                request.Id,
                cancellationToken);

        if (customer == null)
        {
            return Errors.Customer.NotFound;
        }

        return customer.Map();
    }
}