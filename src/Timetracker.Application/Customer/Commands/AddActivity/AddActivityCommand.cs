// <copyright file="AddActivityCommand.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Commands.AddActivity;

public record AddActivityCommand(Guid Id, string Name) : IRequest<CustomerDto>;