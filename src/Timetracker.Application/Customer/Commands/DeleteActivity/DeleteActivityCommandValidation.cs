// <copyright file="DeleteActivityCommandValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public sealed class DeleteActivityCommandValidation : AbstractValidator<DeleteActivityCommand>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public DeleteActivityCommandValidation(
        IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;

        RuleFor(x => x.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .MustAsync(CustomerMustExist).WithMessage("Customer must exist");

        RuleFor(x => x.ActivityId)
            .NotNull().WithMessage("ActivityId cannot be null");

        RuleFor(x => x)
            .MustAsync(ActivityMustExist).WithMessage("Activity does not exist on customer");
    }

    private async Task<bool> CustomerMustExist(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _repository.AnyAsync(new GetByIdSpecification(id), cancellationToken);
    }

    private async Task<bool> ActivityMustExist(
        DeleteActivityCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _repository.AnyAsync(
            new DoesActivityExistOnCustomer(command.CustomerId, command.ActivityId),
            cancellationToken);
    }
}