// <copyright file="CreateCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Name,
    string Number,
    List<ActivityCommandDto> Activities,
    UserId UserId) :
    IRequest<CustomerResponse>,
    ICommandRequest;

public record ActivityCommandDto(string Name);