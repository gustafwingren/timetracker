// <copyright file="AddActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public sealed class
    AddActivityCommandHandler : IRequestHandler<AddActivityCommand, CustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public AddActivityCommandHandler(
        IMapper mapper,
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CustomerResponse> Handle(
        AddActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        Guard.Against.Null(customer);

        customer.AddActivity(Activity.Create(request.Name));

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponse>(customer);
    }
}