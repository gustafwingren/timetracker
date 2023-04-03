// <copyright file="UpdateActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public record UpdateActivityCommand
(
    CustomerId CustomerId,
    ActivityId ActivityId,
    string Name) : ICommand<ErrorOr<ActivityResponse>>;