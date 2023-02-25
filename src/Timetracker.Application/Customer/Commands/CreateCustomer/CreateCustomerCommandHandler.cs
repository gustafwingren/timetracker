// <copyright file="CreateCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _customerRepository;

    public CreateCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Domain.CustomerAggregate.Customer.Create(request.Name, request.Number);

        var newCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

        if (newCustomer == null)
        {
            // TODO: Return Error
        }

        await _customerRepository.SaveChangesAsync(cancellationToken);
    }
}