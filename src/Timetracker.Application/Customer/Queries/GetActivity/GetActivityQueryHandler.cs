// <copyright file="GetActivityQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Errors;
using Timetracker.Application.Mapping;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, ErrorOr<ActivityResponse>>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public GetActivityQueryHandler(
        IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ActivityResponse>> Handle(
        GetActivityQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

        if (customer == null)
        {
            return Errors.Customer.NotFound;
        }

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        if (activity == null)
        {
            return Activity.NotFound;
        }

        return activity.Map();
    }
}