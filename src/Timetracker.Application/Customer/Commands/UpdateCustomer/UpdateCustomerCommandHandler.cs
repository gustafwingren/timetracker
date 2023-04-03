using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Mapping;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public class
    UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<CustomerResponse>>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateCustomerCommandHandler(
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (customer == null)
        {
            return Errors.Customer.NotFound;
        }

        customer.UpdateName(request.Name);
        customer.UpdateCustomerNr(request.Number);

        await _repository.UpdateAsync(customer, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return customer.Map();
    }
}