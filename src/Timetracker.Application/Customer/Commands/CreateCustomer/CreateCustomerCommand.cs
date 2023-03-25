// <copyright file="CreateCustomerCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Domain.Common.Ids;
using Timetracker.Shared.Contracts.Responses;
using ActivityDto = Timetracker.Shared.Contracts.Requests.ActivityDto;

namespace Timetracker.Application.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Name,
    string Number,
    List<ActivityDto> Activities,
    UserId UserId) :
    IRequest<CustomerDto>,
    ICommandRequest;