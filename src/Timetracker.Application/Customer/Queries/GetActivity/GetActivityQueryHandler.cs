// <copyright file="GetActivityQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, ActivityResponse>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public GetActivityQueryHandler(
        IMapper mapper,
        IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ActivityResponse> Handle(
        GetActivityQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        Guard.Against.Null(activity);

        return _mapper.Map<ActivityResponse>(activity);
    }
}