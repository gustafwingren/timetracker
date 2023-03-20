// <copyright file="GetActivityQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using MediatR;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, ActivityDto>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public GetActivityQueryHandler(IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ActivityDto> Handle(
        GetActivityQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        Guard.Against.Null(activity);

        return new ActivityDto(activity.Id.Value, activity.Name);
    }
}