// <copyright file="DeleteCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public record DeleteCustomerCommand(CustomerId Id) : IRequest;