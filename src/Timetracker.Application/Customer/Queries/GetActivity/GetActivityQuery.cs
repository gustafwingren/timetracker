// <copyright file="GetActivityQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.CustomerAggregate.ValueObjects;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public record GetActivityQuery
    (CustomerId CustomerId, ActivityId ActivityId) : IRequest<ActivityDto>;