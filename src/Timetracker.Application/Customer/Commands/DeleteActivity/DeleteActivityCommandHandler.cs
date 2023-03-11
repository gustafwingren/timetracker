// <copyright file="DeleteActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public sealed class
    DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, CustomerDto>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteActivityCommandHandler(IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(
        DeleteActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.FirstOrDefaultAsync(
            new GetByIdSpecification(request.CustomerId),
            cancellationToken);

        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id.Value == request.ActivityId);
        Guard.Against.Null(activity);

        customer.RemoveActivity(activity);

        await _repository.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            customer.Id.Value,
            customer.Name,
            customer.CustomerNr,
            customer.Activities.Select(x => new ActivityDto(x.Id.Value, x.Name)).ToList());
    }
}