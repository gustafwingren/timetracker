// <copyright file="DeleteActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Errors;
using Timetracker.Application.Mapping;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public sealed class
    DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, ErrorOr<CustomerResponse>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteActivityCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(
        DeleteActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);

        if (customer is null)
        {
            return Errors.Customer.NotFound;
        }

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        if (activity is null)
        {
            return Activity.NotFound;
        }

        customer.RemoveActivity(activity);

        await _repository.SaveChangesAsync(cancellationToken);

        return customer.Map();
    }
}