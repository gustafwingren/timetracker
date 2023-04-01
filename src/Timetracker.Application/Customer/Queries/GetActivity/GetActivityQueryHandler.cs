// <copyright file="GetActivityQueryHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, Result<ActivityResponse>>
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

    public async Task<Result<ActivityResponse>> Handle(
        GetActivityQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

        if (customer == null)
        {
            return new Result<ActivityResponse>(
                new NotFoundException(
                    request.CustomerId.ToString(),
                    nameof(Domain.CustomerAggregate.Customer)));
        }

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        if (activity == null)
        {
            return new Result<ActivityResponse>(
                new NotFoundException(
                    request.ActivityId.ToString(),
                    nameof(Activity)));
        }

        return _mapper.Map<ActivityResponse>(activity);
    }
}