// <copyright file="UpdateActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Commands.UpdateActivity;

public record UpdateActivityCommand
    (Guid CustomerId, Guid ActivityId, string Name) : IRequest<CustomerDto>;