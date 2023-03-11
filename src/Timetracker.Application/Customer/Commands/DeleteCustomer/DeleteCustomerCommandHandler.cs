// <copyright file="DeleteCustomerCommandHandler.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteCustomerCommandHandler(IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.FirstOrDefaultAsync(
            new GetByIdSpecification(request.Id),
            cancellationToken);

        if (customer == null)
        {
            return;
        }

        await _repository.DeleteAsync(customer, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}