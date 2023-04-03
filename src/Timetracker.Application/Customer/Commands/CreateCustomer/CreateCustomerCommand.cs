// <copyright file="CreateCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Name,
    string Number,
    List<ActivityCommandDto> Activities,
    UserId UserId) :
    ICommand<ErrorOr<CustomerResponse>>;

public record ActivityCommandDto(string Name);