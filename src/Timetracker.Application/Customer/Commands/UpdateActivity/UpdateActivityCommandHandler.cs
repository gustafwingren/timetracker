// <copyright file="UpdateActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Errors;
using Timetracker.Application.Mapping;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public class
    UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, ErrorOr<ActivityResponse>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateActivityCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ActivityResponse>> Handle(
        UpdateActivityCommand request,
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

        customer.UpdateActivityName(activity.Id, request.Name);

        await _repository.SaveChangesAsync(cancellationToken);

        return
            customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId).Map();
    }
}