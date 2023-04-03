// <copyright file="GetActivityQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Queries.GetActivity;

public record GetActivityQuery
    (CustomerId CustomerId, ActivityId ActivityId) : IRequest<ErrorOr<ActivityResponse>>;