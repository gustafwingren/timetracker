using FluentValidation;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
{
    private readonly IReadRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateCustomerCommandValidation(
        IReadRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Number)
            .NotNull().WithMessage("Number is required")
            .NotEmpty().WithMessage("Number is required");

        RuleFor(x => x.Id)
            .MustAsync(CustomerMustExist).WithMessage("Customer must exist");
    }

    private async Task<bool> CustomerMustExist(
        CustomerId id,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken) != null;
    }
}