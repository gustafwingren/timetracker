// <copyright file="DeleteActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public sealed class
    DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, CustomerResponse>
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

    public async Task<CustomerResponse> Handle(
        DeleteActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);

        Guard.Against.Null(customer);

        var activity = customer.Activities.FirstOrDefault(x => x.Id == request.ActivityId);
        Guard.Against.Null(activity);

        customer.RemoveActivity(activity);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponse>(customer);
    }
}