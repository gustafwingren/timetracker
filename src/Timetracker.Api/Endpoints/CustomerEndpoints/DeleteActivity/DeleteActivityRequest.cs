// <copyright file="DeleteActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteActivity;

public record DeleteActivityRequest(CustomerId CustomerId, ActivityId ActivityId);