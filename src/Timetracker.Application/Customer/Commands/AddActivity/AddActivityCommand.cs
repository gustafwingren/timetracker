// <copyright file="AddActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public record AddActivityCommand(CustomerId Id, string Name) : IRequest<CustomerResponse>;