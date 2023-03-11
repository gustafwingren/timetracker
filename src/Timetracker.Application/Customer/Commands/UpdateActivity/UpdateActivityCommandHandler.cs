// <copyright file="UpdateActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, CustomerDto>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateActivityCommandHandler(IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(
        UpdateActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.FirstOrDefaultAsync(
            new GetByIdSpecification(request.CustomerId),
            cancellationToken);
        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id.Value == request.ActivityId);
        Guard.Against.Null(activity);

        customer.UpdateActivityName(activity.Id, request.Name);

        await _repository.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            customer.Id.Value,
            customer.Name,
            customer.CustomerNr,
            customer.Activities.Select(x => new ActivityDto(x.Id.Value, x.Name)).ToList());
    }
}