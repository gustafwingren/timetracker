// <copyright file="UpdateActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, CustomerResponse>
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

    public async Task<CustomerResponse> Handle(
        UpdateActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);
        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);
        Guard.Against.Null(activity);

        customer.UpdateActivityName(activity.Id, request.Name);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponse>(customer);
    }
}