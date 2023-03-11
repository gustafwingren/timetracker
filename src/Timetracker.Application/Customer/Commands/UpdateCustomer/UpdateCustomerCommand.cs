using MediatR;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Commands.UpdateCustomer;

public record UpdateCustomerCommand(Guid Id, string Name, string Number) : IRequest<CustomerDto>,
    ICommandRequest;