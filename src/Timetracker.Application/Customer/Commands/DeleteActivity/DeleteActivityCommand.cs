// <copyright file="DeleteActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public record DeleteActivityCommand
    (CustomerId CustomerId, ActivityId ActivityId) : IRequest<CustomerResponse>;