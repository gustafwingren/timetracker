// <copyright file="DeleteCustomerCommandValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandValidation : AbstractValidator<DeleteCustomerCommand>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _readRepository;

    public DeleteCustomerCommandValidation(
        IReadRepository<Domain.CustomerAggregate.Customer> readRepository)
    {
        _readRepository = readRepository;

        RuleFor(req => req.Id)
            .NotNull().WithMessage("Must provide an Id")
            .MustAsync(CustomerMustExist).WithMessage("Customer does not exist");
    }

    private async Task<bool> CustomerMustExist(CustomerId id, CancellationToken cancellationToken)
    {
        return await _readRepository.GetByIdAsync(id, cancellationToken) != null;
    }
}