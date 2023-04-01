// <copyright file="UpdateActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public class
    UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Result<ActivityResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateActivityCommandHandler(
        IMapper mapper,
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<ActivityResponse>> Handle(
        UpdateActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);

        if (customer is null)
        {
            return new Result<ActivityResponse>(
                new NotFoundException(
                    request.CustomerId.ToString(),
                    nameof(Domain.CustomerAggregate.Customer)));
        }

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        if (activity is null)
        {
            return new Result<ActivityResponse>(
                new NotFoundException(
                    request.ActivityId.ToString(),
                    nameof(Activity)));
        }

        customer.UpdateActivityName(activity.Id, request.Name);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ActivityResponse>(
            customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId));
    }
}