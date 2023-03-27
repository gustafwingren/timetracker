// <copyright file="GetActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetActivity;

public record GetActivityRequest(CustomerId CustomerId, ActivityId ActivityId);