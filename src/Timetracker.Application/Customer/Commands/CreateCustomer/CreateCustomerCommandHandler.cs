// <copyright file="CreateCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public sealed class
    CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand,
        CustomerResponse>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(
        IMapper mapper,
        IRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(
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

        return _mapper.Map<CustomerResponse>(newCustomer);
    }
}