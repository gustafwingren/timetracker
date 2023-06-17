// <copyright file="GetCustomersQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Mapping;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public sealed class
    GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery,
        ErrorOr<PagedResponse<CustomerResponse>>>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer>
        _customerRepository;

    public GetCustomersQueryHandler(
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<PagedResponse<CustomerResponse>>> Handle(
        GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.ListAsync(
            new GetCustomersSpecification(
                request.UserId,
                request.SearchString,
                request.Page,
                request.PageSize),
            cancellationToken);

        var customerCount = await _customerRepository.CountAsync(
            new GetCustomersSpecification(request.UserId, request.SearchString),
            cancellationToken);
        var customerResponses = customers.Select(x => x.Map());

        return new PagedResponse<CustomerResponse>(customerResponses.ToList(), customerCount);
    }
}