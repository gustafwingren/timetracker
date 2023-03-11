using Ardalis.GuardClauses;
using MediatR;
using Timetracker.Domain.CustomerAggregate.Specifications;
using Timetracker.Shared.Contracts.Responses;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateCustomerCommandHandler(IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.FirstOrDefaultAsync(
            new GetByIdSpecification(request.Id),
            cancellationToken);

        if (customer == null)
        {
            // TODO: Return correct error 
            throw new NotFoundException(
                request.Id.ToString(),
                nameof(Domain.CustomerAggregate.Customer));
        }

        customer.UpdateName(request.Name);
        customer.UpdateCustomerNr(request.Number);

        await _repository.UpdateAsync(customer, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            customer.Id.Value,
            customer.Name,
            customer.CustomerNr,
            customer.Activities.Select(x => new ActivityDto(x.Id.Value, x.Name)).ToList());
    }
}