// <copyright file="CreateCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Mapping;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public sealed class
    CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand,
        ErrorOr<CustomerResponse>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _customerRepository;

    public CreateCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = Domain.CustomerAggregate.Customer.Create(
            request.Name,
            request.Number,
            request.UserId);

        var newCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

        if (request.Activities != null && request.Activities.Any())
        {
            foreach (var requestActivity in request.Activities)
                newCustomer.AddActivity(Activity.Create(requestActivity.Name));
        }

        await _customerRepository.SaveChangesAsync(cancellationToken);

        return newCustomer.Map();
    }
}