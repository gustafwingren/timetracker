using ErrorOr;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public record UpdateCustomerCommand(CustomerId Id, string Name, string Number) :
    ICommand<ErrorOr<CustomerResponse>>;