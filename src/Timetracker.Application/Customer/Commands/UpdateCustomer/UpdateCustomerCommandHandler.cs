using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Shared.Interfaces;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.CustomerAggregate.Customer> _repository;

    public UpdateCustomerCommandHandler(
        IMapper mapper,
        IRepository<Domain.CustomerAggregate.Customer> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CustomerResponse> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(
            request.Id,
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

        return _mapper.Map<CustomerResponse>(customer);
    }
}