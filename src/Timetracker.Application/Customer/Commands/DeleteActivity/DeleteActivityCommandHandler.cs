// <copyright file="DeleteActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public sealed class
    DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Result<CustomerResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteActivityCommandHandler(
        IMapper mapper,
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(
        DeleteActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);

        if (customer is null)
        {
            return new Result<CustomerResponse>(
                new NotFoundException(
                    request.CustomerId.ToString(),
                    nameof(Domain.CustomerAggregate.Customer)));
        }

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);

        if (activity is null)
        {
            return new Result<CustomerResponse>(
                new NotFoundException(
                    request.ActivityId.ToString(),
                    nameof(Activity)));
        }

        customer.RemoveActivity(activity);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponse>(customer);
    }
}