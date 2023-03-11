// <copyright file="AddActivityHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using MediatR;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public sealed class AddActivityHandler : IRequestHandler<AddActivityCommand, CustomerDto>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public AddActivityHandler(IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(
        AddActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.FirstOrDefaultAsync(
            new GetByIdSpecification(request.Id),
            cancellationToken);

        Guard.Against.Null(customer);

        customer.AddActivity(Activity.Create(request.Name));

        await _repository.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            customer.Id.Value,
            customer.Name,
            customer.CustomerNr,
            customer.Activities.Select(x => new ActivityDto(x.Id.Value, x.Name)).ToList());
    }
}