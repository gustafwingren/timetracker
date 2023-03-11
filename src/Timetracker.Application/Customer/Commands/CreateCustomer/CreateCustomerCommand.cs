// <copyright file="CreateCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(string Name, string Number) : IRequest<CustomerDto>,
    ICommandRequest;