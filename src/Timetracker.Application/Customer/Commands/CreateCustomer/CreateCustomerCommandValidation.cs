// <copyright file="CreateCustomerCommandValidation.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using FluentValidation;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public sealed class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer>
        _customerRepository;

    public CreateCustomerCommandValidation(
        IReadRepository<Domain.CustomerAggregate.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(req => req.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required");

        RuleFor(req => req.Number)
            .NotNull().WithMessage("Number is required")
            .NotEmpty().WithMessage("Number is required")
            .MustAsync(BeUniqueNumber).WithMessage("The specified number already exists");

        RuleForEach(req => req.Activities)
            .ChildRules(
                a => a.RuleFor(x => x.Name)
                    .NotNull().WithMessage("ActivityName is required")
                    .NotEmpty().WithMessage("ActivityName is required"));

        RuleFor(req => req.UserId)
            .NotNull().WithMessage("UserId is required")
            .NotEmpty().WithMessage("UserId is required");
    }

    private async Task<bool> BeUniqueNumber(string number, CancellationToken cancellationToken)
    {
        return await _customerRepository.FirstOrDefaultAsync(
            new UniqueNumberSpecification(number),
            cancellationToken) == null;
    }
}