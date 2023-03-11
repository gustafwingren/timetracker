// <copyright file="DeleteCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;

namespace Timetracker.Application.Customer.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid Id) : IRequest;