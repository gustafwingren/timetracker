// <copyright file="DeleteCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using LanguageExt.Common;
using MediatR;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<int>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (customer == null)
        {
            return new Result<int>(
                new NotFoundException(
                    request.Id.ToString(),
                    nameof(Domain.CustomerAggregate.Customer)));
        }

        await _repository.DeleteAsync(customer, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return 1;
    }
}