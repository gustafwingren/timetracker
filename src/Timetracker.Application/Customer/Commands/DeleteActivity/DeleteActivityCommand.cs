// <copyright file="DeleteActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public record DeleteActivityCommand
    (CustomerId CustomerId, ActivityId ActivityId) : ICommand<ErrorOr<CustomerResponse>>;