// <copyright file="CreateCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public sealed class
    CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _customerRepository;

    public CreateCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = Domain.CustomerAggregate.Customer.Create(
            request.Name,
            request.Number,
            request.UserId);

        var newCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

        if (newCustomer == null)
        {
            throw new NullReferenceException();
        }

        if (request.Activities.Any())
        {
            foreach (var requestActivity in request.Activities)
                newCustomer.AddActivity(Activity.Create(requestActivity.Name));
        }

        await _customerRepository.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            newCustomer.Id.Value,
            newCustomer.Name,
            newCustomer.CustomerNr,
            newCustomer.Activities.Select(x => new ActivityDto(x.Id.Value, x.Name)).ToList());
    }
}