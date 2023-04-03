// <copyright file="DeleteCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ErrorOr<int>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<int>> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (customer == null)
        {
            return Errors.Customer.NotFound;
        }

        await _repository.DeleteAsync(customer, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return 1;
    }
}