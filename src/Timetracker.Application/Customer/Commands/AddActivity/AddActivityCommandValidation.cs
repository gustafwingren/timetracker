// <copyright file="AddActivityCommandValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public sealed class AddActivityCommandValidation : AbstractValidator<AddActivityCommand>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public AddActivityCommandValidation(
        IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(CustomerMustExist).WithMessage("Customer must exist");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name cannot be null")
            .NotEmpty().WithMessage("Name cannot be empty");
    }

    private async Task<bool> CustomerMustExist(
        CustomerId id,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken) != null;
    }
}