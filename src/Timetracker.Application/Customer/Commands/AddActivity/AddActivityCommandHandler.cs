// <copyright file="AddActivityCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Mapping;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public sealed class
    AddActivityCommandHandler : IRequestHandler<AddActivityCommand, ErrorOr<CustomerResponse>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public AddActivityCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(
        AddActivityCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (customer == null)
        {
            return Errors.Customer.NotFound;
        }

        customer.AddActivity(Activity.Create(request.Name));

        await _repository.SaveChangesAsync(cancellationToken);

        return customer.Map();
    }
}