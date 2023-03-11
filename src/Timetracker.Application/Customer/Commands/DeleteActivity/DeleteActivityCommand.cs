// <copyright file="DeleteActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Commands.DeleteActivity;

public record DeleteActivityCommand(Guid CustomerId, Guid ActivityId) : IRequest<CustomerDto>;