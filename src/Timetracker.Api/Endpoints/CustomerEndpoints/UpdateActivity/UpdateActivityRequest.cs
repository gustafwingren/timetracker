// <copyright file="UpdateActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public record UpdateActivityRequest(CustomerId CustomerId, ActivityId ActivityId, string Name);